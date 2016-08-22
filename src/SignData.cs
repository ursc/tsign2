using System;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace tsign2
{
    public enum DateReplace { ALL, EMPTY, NONE }
    public enum SignDataType { Auto, Manual, Error };

    public class SignData : ICloneable
    {
        public int Id;
        public Layout Layout;
        public Table Table;
        public string Action;
        public string Fio;
        public SignUser[] SignUsers;
        public SignUser SignUser;
        public DateTime Date;
        public int RowIndex;
        public int ColumnSignIndex;
        public int ColumnDateIndex;
        public bool IsDeleted;

        public SignDataType SignUserType;
        public SignDataType DateType;

        public Point3d SignPosition()
        {
            double x = 0;
            for (int i = 0; i < ColumnSignIndex; i++) {
                x = x + Table.ColumnWidth(i);
            }

            double y = -Table.RowHeight(RowIndex);
            for (int i = 0; i < RowIndex; i++) {
                y = y - Table.RowHeight(i);
            }

            var offset = new Point3d(x + 1, y, 0);

            var v1 = offset.GetAsVector().RotateBy(Rotation(), Vector3d.ZAxis);
            return Table.Position.Add(v1);
        }

        public double Rotation()
        {
            var dir = Table.Direction;
            return Math.Acos(dir.X / Math.Sqrt(Math.Pow(dir.X, 2) + Math.Pow(dir.Y, 2)));
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
