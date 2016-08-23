using System;

using Autodesk.AutoCAD.DatabaseServices;

namespace tsign2
{
    public class SignUser : User
    {
        public ObjectId ObjectId;
        public string Blockname;

        public SignUser(ObjectId id, string blockname, string rawname) : base(rawname)
        {
            ObjectId = id;
            Blockname = blockname;
        }
    }
}
