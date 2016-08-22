using System;

using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;

namespace tsign2
{
    public class SignInserter : SignFinder
    {
        public SignInserter(Signs signs, Document doc, Config config)
            : base(signs, doc, config)
        {
        }

        public void InsertSigns(string dateFormat)
        {
            var fmt = "{0:" + dateFormat + "}";
            if (!string.IsNullOrEmpty(config.DateTextFormat)) {
                fmt = "{{" + config.DateTextFormat + fmt + "}}";
            }

            using (var tr2 = signs.Db.TransactionManager.StartTransaction()) {
                using (var dlock = doc.LockDocument()) {
                    using (var tr = doc.Database.TransactionManager.StartTransaction()) {
                        int i = 1, cnt = LayoutManager.Current.LayoutCount - 1;
                        foreach (var data in Data) {
                            if (i == 1 || LayoutManager.Current.CurrentLayout != data.Layout.LayoutName) {
                                LayoutManager.Current.CurrentLayout = data.Layout.LayoutName;
                                doc.Editor.WriteMessage(string.Format("\nподпись [{0} из {1}], слой {2}. ", i, cnt, data.Layout.LayoutName));
                                i++;
                            }
                            if (data.IsDeleted) {
                                continue;
                            }

                            Table tbl = (Table)tr.GetObject(data.Table.Id, OpenMode.ForWrite, false);

                            InsertSign(tr, tr2, data);

                            tbl.SetTextHeight(data.RowIndex, data.ColumnDateIndex, config.DateTextHeight);
                            tbl.SetTextString(data.RowIndex, data.ColumnDateIndex, string.Format(fmt, data.Date));
                        }
                        tr.Commit();
                    }
                }
                tr2.Abort();
            }
            doc.Editor.UpdateScreen();
            doc.Editor.Regen();
        }

        private void InsertSign(Transaction tr, Transaction tr2, SignData data)
        {
            var bt = (BlockTable)tr.GetObject(doc.Database.BlockTableId, OpenMode.ForRead, false);
            var btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.PaperSpace], OpenMode.ForRead);
            var objId = findBlockRef(tr, btr, data.SignUser.Rawname);
            if (objId.Handle.Value == 0) {
                var acIdMap = new IdMapping();
                var bsObjCol = new ObjectIdCollection();
                var br2 = (BlockReference)tr2.GetObject(data.SignUser.ObjectId, OpenMode.ForRead, false);
                bsObjCol.Add(br2.ObjectId);
                bt.UpgradeOpen();
                doc.Database.WblockCloneObjects(bsObjCol, btr.ObjectId, acIdMap, DuplicateRecordCloning.Ignore, false);

                objId = findBlockRef(tr, btr, data.SignUser.Rawname);
                if (objId.Handle.Value > 0) {
                    var br = (BlockReference)tr.GetObject(objId, OpenMode.ForRead, false);
                    br.UpgradeOpen();
                    br.Position = data.SignPosition();
                    br.Rotation = data.Rotation();
                }
            } else {
                var br = (BlockReference)tr.GetObject(objId, OpenMode.ForRead, false);
                var br2 = (BlockReference)br.Clone();
                br2.Position = data.SignPosition();
                br2.Rotation = data.Rotation();
                btr.UpgradeOpen();
                btr.AppendEntity(br2);
                tr.AddNewlyCreatedDBObject(br2, true);
            }
            tr.TransactionManager.QueueForGraphicsFlush();
        }

        private ObjectId findBlockRef(Transaction tr, BlockTableRecord btr, string bname)
        {
            foreach (ObjectId objId in btr) {
                DBObject br = tr.GetObject(objId, OpenMode.ForRead, false);
                if (br != null && br is BlockReference) {
                    var dbtr = (BlockTableRecord)tr.GetObject((br as BlockReference).BlockTableRecord, OpenMode.ForRead, false);
                    if (bname.CompareTo(dbtr.Name) == 0) {
                        return objId;
                    }
                }
            }
            return new ObjectId();
        }

        public bool ZoomTo(int row)
        {
            var layout = Data[row].Layout;
            var tbl = Data[row].Table;
            var rotation = Data[row].Rotation();

            using (var tr = doc.Database.TransactionManager.StartTransaction()) {
                if (LayoutManager.Current.CurrentLayout != layout.LayoutName) {
                    LayoutManager.Current.CurrentLayout = layout.LayoutName;
                }

                var vp = tr.GetObject(doc.Editor.CurrentViewportObjectId, OpenMode.ForRead, false) as Viewport;
                if (vp == null || vp.Number != 1) {
                    tr.Commit();
                    return true;
                }

                var p1 = new Point3d(tbl.Width, -tbl.Height, 0);
                var v1 = p1.GetAsVector().RotateBy(rotation, Vector3d.ZAxis);

                var pos = tbl.Position.Add(v1.DivideBy(2.0));

                using (var acView = doc.Editor.GetCurrentView()) {
                    acView.Width = tbl.GeometricExtents.MaxPoint.X - tbl.GeometricExtents.MinPoint.X;
                    acView.Height = tbl.GeometricExtents.MaxPoint.Y - tbl.GeometricExtents.MinPoint.Y;
                    acView.CenterPoint = new Point2d(pos.X, pos.Y);
                    doc.Editor.SetCurrentView(acView);
                }
                tr.Commit();
            }
            doc.Editor.SetImpliedSelection(new ObjectId[0]);
            doc.Editor.UpdateScreen();
            //doc.Editor.Regen();

            return false;
        }
    }
}
