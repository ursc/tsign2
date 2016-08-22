using System;

using Autodesk.AutoCAD.DatabaseServices;

namespace tsign2
{
    public class SignUser : User
    {
        public ObjectId ObjectId;

        public SignUser(ObjectId id, string fullname) : base(fullname)
        {
            ObjectId = id;
        }
    }
}
