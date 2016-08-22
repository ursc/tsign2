using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Forms = System.Windows.Forms;

using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.PlottingServices;

namespace tsign2
{
    public class SheetPlotter
    {
        private readonly Document doc;
        private readonly Config config;

        public string fileNamePdf;

        public SheetPlotter(Document doc, Config config)
        {
            this.doc = doc;
            this.config = config;

            fileNamePdf = GetFileNamePdf(doc.Name);
        }

        private string GetFileNamePdf(string filename)
        {
            var name = Path.GetFileNameWithoutExtension(filename);
            var match = Regex.Match(name, "(-л|_л| )");
            return match.Success ? name.Substring(0, match.Index) : name;
        }

        public void AllLayoutPlot()
        {
            short bgPlot = (short)Application.GetSystemVariable("BACKGROUNDPLOT");
            Application.SetSystemVariable("BACKGROUNDPLOT", 0);

            var dlock = doc.LockDocument();
            try {
                var db = doc.Database;
                using (var tr = db.TransactionManager.StartTransaction()) {
                    var layouts = Utils.GetPaperLayouts(db, tr);
                    try {
                        LayoutsPlot(tr, layouts);
                    } catch (System.Exception ex) {
                        Forms.MessageBox.Show(ex.Message, "Ошибка", Forms.MessageBoxButtons.OK, Forms.MessageBoxIcon.Error);
                    }

                    tr.Commit();
                }
            } finally {
                dlock.Dispose();
                Application.SetSystemVariable("BACKGROUNDPLOT", bgPlot);
            }

            doc.Editor.Regen();
        }

        private void LayoutsPlot(Transaction tr, IEnumerable<Layout> layouts)
        {
            var path = Path.GetDirectoryName(doc.Name);

            int i = 1, cnt = layouts.Count();
            var bookmarkFiles = new List<Bookmark>();
            foreach (var lo in layouts) {
                var suffix = config.FileBySheetNumber
                    ? string.Format("{0}{1:000}", config.PrefixFileNumber, lo.TabOrder)
                    : string.Format("{0}", lo.LayoutName);
                var filename = string.Format("{0}\\{1}{2}{3}.pdf", path, fileNamePdf, config.SeparatorFileNumber, suffix);

                var bookmark = config.BookmarksInPdf == BookmarksInPdf.BySheetNumber
                    ? string.Format("{0}{1:000}", config.BookmarkPrefix, lo.TabOrder)
                    : string.Format("{0}", lo.LayoutName);
                var bookmarkFile = new Bookmark(bookmark, filename);

                bookmarkFiles.Add(bookmarkFile);

                doc.Editor.WriteMessage(string.Format("\nplot [{0} из {1}], слой {2}. ", i++, cnt, lo.LayoutName));

                LayoutPlot(tr, lo, filename);
            }

            if (config.CreateMultiSheetsPdf) {
                MergePdf(bookmarkFiles);
            }

            if (config.DeleteOneSheetPdf) {
                foreach (var bf in bookmarkFiles) {
                    try {
                        File.Delete(bf.Filename);
                    } catch (Exception ex) {
                        Forms.MessageBox.Show(ex.Message, "Ошибка удаления файла", Forms.MessageBoxButtons.OK, Forms.MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LayoutPlot(Transaction tr, Layout lo, string filename)
        {
            LayoutManager.Current.CurrentLayout = lo.LayoutName;

            var plotDeviceName = "DWG To PDF.pc3";
            var styleSheetName = "monochrome.stb";

            var ext = MaxPolylineExtents(tr, lo);
            if (ext.MaxPoint == ext.MinPoint) {
                throw new System.Exception(lo.LayoutName + " - не найдены границы чертежа");
            }
            Point2d size = new Point2d(ext.MaxPoint.X - ext.MinPoint.X, ext.MaxPoint.Y - ext.MinPoint.Y);

            var vp = tr.GetObject(doc.Editor.CurrentViewportObjectId, OpenMode.ForRead, false) as Viewport;
            if (vp != null && vp.Number == 1) {
                using (var acView = doc.Editor.GetCurrentView()) {
                    acView.Width = size.X;
                    acView.Height = size.Y;
                    var half = size.DivideBy(2);
                    acView.CenterPoint = new Point2d(ext.MaxPoint.X - half.X, ext.MaxPoint.Y - half.Y);
                    doc.Editor.SetCurrentView(acView);
                }
            }

            using (var ps = new PlotSettings(lo.ModelType)) {
                ps.CopyFrom(lo);

                double x, y;
                x = y = 0;
                double minArea = double.MaxValue;
                string mediaName = string.Empty;
                MediaBounds mediaBounds;
                PlotRotation plotRotation = PlotRotation.Degrees000;

                PlotConfigManager.RefreshList(RefreshCode.All);
                PlotConfigManager.SetCurrentConfig(plotDeviceName);
                PlotConfigManager.CurrentConfig.RefreshMediaNameList();

                var names = PlotConfigManager.CurrentConfig.CanonicalMediaNames;
                foreach (var name in names) {
                    if (!name.ToUpper().StartsWith("USER")) {
                        continue;
                    }
                    var mb = PlotConfigManager.CurrentConfig.GetMediaBounds(name);
                    var rot000 = mb.PageSize.X >= size.X && mb.PageSize.Y >= size.Y;
                    var rot090 = mb.PageSize.X >= size.Y && mb.PageSize.Y >= size.X;
                    if (!rot000 && !rot090) {
                        continue;
                    }
                    var area = mb.PageSize.X * mb.PageSize.Y;
                    if (area <= minArea) {
                        if (rot000) {
                            plotRotation = PlotRotation.Degrees000;
                            x = size.X;
                            y = size.Y;
                        } else {
                            plotRotation = PlotRotation.Degrees090;
                            x = size.Y;
                            y = size.X;
                        }
                        minArea = area;
                        mediaName = name;
                        mediaBounds = mb;

                        x = (mb.PageSize.X - x) / 2 - mb.LowerLeftPrintableArea.X;
                        y = (mb.PageSize.Y - y) / 2 - mb.LowerLeftPrintableArea.Y;
                    }
                }

                if (mediaName == string.Empty) {
                    throw new System.Exception(
                        string.Format("{0} - не найден подходящий формат бумаги ({1:00},{2:00})", lo.LayoutName, size.X, size.Y));
                }

                if (config.WarningIfSideExcess && (x > config.AllowSideExcessSize || y > config.AllowSideExcessSize)) {
                    var msg = string.Format("{0} - ({1:00},{2:00}) {3}, для ({4:00},{5:00})", lo.LayoutName,
                        size.X, size.Y,
                        plotRotation == PlotRotation.Degrees000 ? "без поворота" : "с поворотом",
                        mediaBounds.PageSize.X, mediaBounds.PageSize.Y);
                    Forms.MessageBox.Show(msg, "Превышение формата бумаги", Forms.MessageBoxButtons.OK, Forms.MessageBoxIcon.Warning);
                }

                var psv = PlotSettingsValidator.Current;
                psv.SetPlotWindowArea(ps, ext);
                psv.SetPlotType(ps, Autodesk.AutoCAD.DatabaseServices.PlotType.Window);
                psv.SetPlotConfigurationName(ps, plotDeviceName, mediaName);
                psv.SetUseStandardScale(ps, true);
                psv.SetStdScaleType(ps, StdScaleType.StdScale1To1);
                psv.SetPlotPaperUnits(ps, PlotPaperUnit.Millimeters);

                psv.SetPlotRotation(ps, plotRotation);
                psv.SetPlotOrigin(ps, new Point2d(x, y));

                //psv.SetZoomToPaperOnUpdate(ps, true);

                //psv.RefreshLists(ps);
                psv.GetPlotStyleSheetList();
                psv.SetCurrentStyleSheet(ps, styleSheetName);

                ps.ScaleLineweights = false;
                ps.PrintLineweights = true;
                //ps.ShowPlotStyles = true;
                ps.ShadePlot = PlotSettingsShadePlotType.AsDisplayed;
                ps.ShadePlotResLevel = ShadePlotResLevel.Normal;
                ps.PlotPlotStyles = true;
                ps.DrawViewportsFirst = true;

                var pi = new PlotInfo();
                pi.Layout = lo.Id;// .ObjectId;
                pi.OverrideSettings = ps;

                var piv = new PlotInfoValidator();
                piv.MediaMatchingPolicy = MatchingPolicy.MatchEnabled;
                piv.Validate(pi);

                var ppi = new PlotPageInfo();

                using (PlotEngine pe = PlotFactory.CreatePublishEngine()) {
                    pe.BeginPlot(null, null);
                    pe.BeginDocument(pi, doc.Name, null, 1, true, filename);
                    pe.BeginPage(ppi, pi, true, null);
                    pe.BeginGenerateGraphics(null);
                    pe.EndGenerateGraphics(null);
                    pe.EndPage(null);
                    pe.EndDocument(null);
                    pe.EndPlot(null);
                }

                lo.CopyFrom(ps);
            }
        }

        private void MergePdf(IEnumerable<Bookmark> bookmarkFiles)
        {
            var path = Path.GetDirectoryName(doc.Name);
            var filename = Path.GetFileNameWithoutExtension(doc.Name) + ".pdf";
            filename = Path.Combine(path, filename);

            var outlines = new List<Dictionary<string, object>>();

            using (MemoryStream ms = new MemoryStream()) {
                using (var document = new iTextSharp.text.Document()) {
                    using (var copy = new iTextSharp.text.pdf.PdfCopy(document, ms)) {
                        document.Open();
                        int pageNumber = 1;
                        foreach (var bf in bookmarkFiles) {
                            using (var reader = new iTextSharp.text.pdf.PdfReader(bf.Filename)) {
                                var page = copy.GetImportedPage(reader, 1);
                                copy.AddPage(page);
                            }

                            var outline = new Dictionary<string, object>();
                            outlines.Add(outline);
                            outline["Title"] = bf.Title;
                            outline["Action"] = "GoTo";
                            outline["Page"] = String.Format("{0} Fit", pageNumber++);
                        }
                    }
                }

                if (config.BookmarksInPdf == BookmarksInPdf.DontCreate) {
                    File.WriteAllBytes(filename, ms.ToArray());
                    return;
                }

                var docReader = new iTextSharp.text.pdf.PdfReader(ms.ToArray());
                using (MemoryStream ms2 = new MemoryStream()) {
                    using (var stamper = new iTextSharp.text.pdf.PdfStamper(docReader, ms2)) {
                        stamper.Outlines = outlines;
                    }
                    File.WriteAllBytes(filename, ms2.ToArray());
                }
            }
        }

        private Extents2d MaxPolylineExtents(Transaction tr, Layout layout)
        {
            Extents3d ext;
            double area, maxArea = double.MinValue;
            var btr = (BlockTableRecord)tr.GetObject(layout.BlockTableRecordId, OpenMode.ForRead, false);
            foreach (ObjectId objId in btr) {
                var ent = tr.GetObject(objId, OpenMode.ForRead, false) as Entity;
                if (ent is Polyline) {
                    area = (ent as Polyline).Area;
                } else if (ent is Polyline2d) {
                    area = (ent as Polyline2d).Area;
                } else if (ent is Polyline3d) {
                    area = (ent as Polyline3d).Area;
                } else {
                    continue;
                }
                if (area > maxArea) {
                    maxArea = area;
                    ext = ent.GeometricExtents;
                }
            }
            if (maxArea == double.MinValue) {
                return new Extents2d();
            }
            return new Extents2d(ext.MinPoint.X, ext.MinPoint.Y, ext.MaxPoint.X, ext.MaxPoint.Y);
        }
    }
}
