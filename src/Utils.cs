using System;
using System.Collections.Generic;
using System.Linq;

using Autodesk.AutoCAD.DatabaseServices;

namespace tsign2
{
    public class Utils
    {
        private Utils() { }

        static public IEnumerable<Layout> GetPaperLayouts(Database db, Transaction tr)
        {
            var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead, false);

            var btrIdModel = bt[BlockTableRecord.ModelSpace];
            var layouts = new List<Layout>();
            foreach (ObjectId btrId in bt) {
                if (btrId == btrIdModel) {
                    continue;
                }
                var btr = (BlockTableRecord)tr.GetObject(btrId, OpenMode.ForRead);
                if (!btr.IsLayout) {
                    continue;
                }
                var layout = (Layout)tr.GetObject(btr.LayoutId, OpenMode.ForRead);
                layouts.Add(layout);
            }

            return layouts.OrderBy(o => o.TabOrder);
        }
    }
}
