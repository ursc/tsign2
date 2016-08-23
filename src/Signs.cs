using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;

namespace tsign2
{
    public class Signs
    {
        private readonly Database db;
        public Database Db
        {
            get
            {
                return db;
            }
        }

        private readonly Config config;

        public readonly DateTime LastWriteTime;

        private List<SignUser> users;

        private SignUser[] allUsers;
        public SignUser[] AllUsers
        {
            get {
                if (allUsers == null) {
                    allUsers = users.ToArray();
                }
                return allUsers;
            }
        }

        public Signs(Config config)
        {
            this.config = config;

            users = new List<SignUser>();

            var filename = config.SignsFile;

            var localFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(filename));

            Update(localFilename, filename);

            if (!File.Exists(localFilename)) {
                return;
            }

            LastWriteTime = File.GetLastWriteTime(localFilename);

            db = new Database(false, true);
            db.ReadDwgFile(localFilename, System.IO.FileShare.Read, true, "");

            LoadSigns();
        }

        private void Update(string localFilename, string filename)
        {
            if (File.Exists(filename)) {
                if (File.Exists(localFilename) && File.GetLastWriteTime(filename) == File.GetLastWriteTime(localFilename)) {
                    return;
                }
                File.Copy(filename, localFilename, true);
            }
        }

        private void LoadSigns()
        {
            using (var tr = db.TransactionManager.StartTransaction()) {
                var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead, false);
                var btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);
                foreach (ObjectId objId in btr) {
                    var br = tr.GetObject(objId, OpenMode.ForRead, false) as BlockReference;
                    if (br != null) {
                        var dbtr = (BlockTableRecord)tr.GetObject(br.BlockTableRecord, OpenMode.ForRead, false);
                        if (!dbtr.Name.StartsWith("*")) {
                            var cname = CorrectName(dbtr.Name);
                            var user = new SignUser(objId, dbtr.Name, cname);
                            users.Add(user);
                        }
                    }
                }
                users = users.OrderBy(o => o.Fullname).ToList();
            }
        }

        // TODO : исправить замену символов
        public string CorrectName(string name)
        {
            var rname = name;
            for (int i = 0; i < config.ReplaceCharSrc.Length; i++) {
                rname = rname.Replace(config.ReplaceCharSrc[i], config.ReplaceCharDst[i]);
            }

            return rname;
        }

        public SignUser[] GetSignUsers(string name)
        {
            var cname = CorrectName(name);

            if (cname.IndexOf(' ') == -1) {
                return users.Where(u => u.Lastname == cname).ToArray();
            }
            var l = cname.Length;
            return users.Where(u => u.Fullname.Substring(0, l) == cname).ToArray();
        }
    }
}
