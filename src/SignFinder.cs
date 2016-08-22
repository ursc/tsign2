using System;
using System.Text.RegularExpressions;

using System.Collections.Generic;
using System.Linq;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;

namespace tsign2
{
    public class SignFinder
    {
        protected readonly Signs signs;
        protected readonly Document doc;
        protected readonly Config config;

        private Regex rxMainInscription;
        private Regex rxAlpha;
        private Regex rxAlnum;
        private SignData signDataIzm;

        private readonly List<SignData> data;
        public List<SignData> Data
        {
            get { return data; }
        }

        public SignFinder(Signs signs, Document doc, Config config)
        {
            this.signs = signs;
            this.doc = doc;
            this.config = config;
            this.data = new List<SignData>();

            rxMainInscription = new Regex("Осн.*?надпись", RegexOptions.Compiled);
            rxAlpha = new Regex("^[a-zA-Zа-яА-Я]", RegexOptions.Compiled);
            rxAlnum = new Regex("^[a-zA-Zа-яА-Я0-9]", RegexOptions.Compiled);

            var db = doc.Database;
            using (var tr = db.TransactionManager.StartTransaction()) {
                var layouts = Utils.GetPaperLayouts(db, tr);
                foreach (var layout in layouts) {
                    var btr = (BlockTableRecord)tr.GetObject(layout.BlockTableRecordId, OpenMode.ForRead, false);
                    foreach (ObjectId objId2 in btr) {
                        FindTable(tr, layout, objId2);
                    }
                }
            }
            data = data.OrderBy(o => o.Layout.TabOrder << 16 | o.Id).ToList();
        }

        private void FindTable(Transaction tr, Layout layout, ObjectId objId)
        {
            var obj = tr.GetObject(objId, OpenMode.ForRead, false);
            if (obj is Table) {
                var tbl = obj as Table;
                if (tbl.NumColumns < 4) {
                    return;
                }

                if (!rxMainInscription.IsMatch(tbl.TableStyleName) && !tbl.TableStyleName.StartsWith("Согласовано")) {
                    return;
                }

                int number = -1, izm = -1;
                var data = new List<SignData>();
                for (var r = 0; r < tbl.NumRows; r++) {
                    var colFio = GetCellColumn(tbl, r, 1);
                    if (colFio >= tbl.NumColumns) {
                        continue;
                    }
                    var fio = tbl.GetTextString(r, colFio, 0, FormatOption.IgnoreMtextFormat);
                    if (string.IsNullOrEmpty(fio)) {
                        continue;
                    }
                    fio = fio.Trim();

                    var colSign = GetCellColumn(tbl, r, 2);
                    if (colSign >= tbl.NumColumns) {
                        continue;
                    }

                    var colDate = GetCellColumn(tbl, r, 3);
                    if (colDate >= tbl.NumColumns) {
                        continue;
                    }

                    var lastname = fio.Split(' ').First();
                    lastname = lastname.First().ToString().ToUpper() + lastname.Substring(1).ToLower();

                    var action = tbl.GetTextString(r, 0, 0, FormatOption.IgnoreMtextFormat);
                    if (!rxAlnum.Match(action).Success) {
                        continue;
                    }
                    if (action.StartsWith("Изм.") && number != -1 && r > 0) {
                        izm = r - 1;
                        continue;
                    }
                    if (int.TryParse(action, out number)) {
                        continue;
                    } else {
                        number = -1;
                    }

                    if (fio.StartsWith("Кол.") || !rxAlpha.Match(fio).Success) {
                        continue;
                    }

                    var dt = DateTime.MinValue;
                    var date = tbl.GetTextString(r, colDate, 0, FormatOption.IgnoreMtextFormat);
                    if (date.Length > 0) {
                        DateTime.TryParse(date, out dt);
                    }

                    var users = signs.GetSignUsers(lastname);

                    var signData = new SignData() {
                        Id = Data.Count(),
                        Action = action,
                        Date = dt,
                        DateType = dt == DateTime.MinValue ? SignDataType.Error : SignDataType.Auto,
                        Fio = fio,
                        Layout = layout,
                        SignUsers = users.Length == 0 ? signs.AllUsers : users,
                        SignUser = users.Length == 1 ? users[0] : null,
                        SignUserType = users.Length == 1 ? SignDataType.Auto : SignDataType.Error,
                        Table = tbl,
                        RowIndex = r,
                        ColumnSignIndex = colSign,
                        ColumnDateIndex = colDate
                    };
                    data.Add(signData);
                }
                if (data.Count == 0 && izm == -1) {
                    return;
                }

                if (rxMainInscription.IsMatch(tbl.TableStyleName) || data.Any(o => o.SignUsers.Length > 0 || o.Action.StartsWith("Check"))) {
                    if (izm != -1 && tbl.NumColumns >= 5) {
                        var first = data.FirstOrDefault(o => o.Action == "Разработал");
                        if (first == null && data.Count > 0) {
                            first = data[0];
                        }
                        if (first != null) {
                            signDataIzm = (SignData)first.Clone();
                        } else if (signDataIzm != null) {
                            signDataIzm = (SignData)signDataIzm.Clone();
                        }

                        if (signDataIzm != null) {
                            var colSign = 4;
                            var colDate = 5;
                            signDataIzm.Id = Data.Count();
                            signDataIzm.Action = "Изм.";
                            signDataIzm.RowIndex = izm;
                            signDataIzm.ColumnSignIndex = colSign;
                            signDataIzm.ColumnDateIndex = colDate;
                            signDataIzm.Layout = layout;
                            signDataIzm.Table = tbl;

                            var dt = DateTime.MinValue;
                            var date = tbl.GetTextString(izm, colDate, 0, FormatOption.IgnoreMtextFormat);
                            if (date.Length > 0) {
                                DateTime.TryParse(date, out dt);
                            }
                            signDataIzm.Date = dt;
                            signDataIzm.DateType = dt == DateTime.MinValue ? SignDataType.Error : SignDataType.Auto;

                            data.Insert(0, signDataIzm);
                        }
                    }
                    Data.AddRange(data);
                }
            } else if (obj is BlockReference) {
                var br = obj as BlockReference;
                var brId = br.IsDynamicBlock ? br.DynamicBlockTableRecord : br.BlockTableRecord;
                var btr = (BlockTableRecord)tr.GetObject(brId, OpenMode.ForRead, false);
                foreach (ObjectId objId2 in btr) {
                    FindTable(tr, layout, objId2);
                }
            }
        }

        private int GetCellColumn(Table tbl, int r, int c)
        {
            int col = 0;
            for (int i = 0; i < c; i++) {
                try {
                    var merged = tbl.IsMergedCell(r, col);
                    if (merged != null) {
                        col = merged.LastColumn;
                    }
                } catch { }
                col++;
            }
            return col;
        }
    }
}
