using System;
using System.IO;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;

namespace tsign2
{
    public class Addin : IExtensionApplication
    {
        private static Signs signs;
        private static Config config;

        public void Terminate()
        {
        }
        public void Initialize()
        {
            config = Config.LoadConfig("tsign2.bin");
        }

        [CommandMethod("tsign2")]
        public void tsign2()
        {
            var acadWindow = Application.MainWindow;
            var doc = Application.DocumentManager.MdiActiveDocument;
            if (Path.GetFileName(doc.Name) == doc.Name) {
                doc.Editor.WriteMessage("\nПуть к файлу " + doc.Name + " не определён");
                return;
            }

            var oldLocation = acadWindow.Location;
            var oldSize = acadWindow.Size;

            if (config.IsAutoSize) {

                CommandEventHandler f = null;
                f = (object sender, CommandEventArgs e) => {
                    if (e.GlobalCommandName.EndsWith("CLEANSCREENON")) {
                        doc.SendStringToExecute("_.TSIGN2ACADSIZE\n", true, false, false);
                    } else if (e.GlobalCommandName.EndsWith("TSIGN2ACADSIZE")) {
                        doc.SendStringToExecute("_.TSIGN2SHOW\n", true, false, false);
                    } else if (e.GlobalCommandName.EndsWith("TSIGN2SHOW")) {
                        doc.CommandEnded -= f;
                        doc.SendStringToExecute("_.CLEANSCREENOFF\n", true, false, false);
                        acadWindow.Location = oldLocation;
                        acadWindow.Size = oldSize;
                    }
                };

                doc.CommandEnded += f;
                doc.SendStringToExecute("_.CLEANSCREENON\n", true, false, false);
            } else {
                doc.SendStringToExecute("_.TSIGN2SHOW\n", true, false, false);
            }
        }

        [CommandMethod("tsign2show")]
        public void tsign2show()
        {
            if (signs == null) {
                signs = new Signs(config);
            }

            Form1 form = new Form1(signs, Application.DocumentManager.MdiActiveDocument, config);
            config.RestoreForm(form);
            form.ShowDialog();
            config.SaveForm(form);
            config.Save();
        }

        [CommandMethod("tsign2acadsize")]
        public void tsign2acadsize()
        {
            config.AutoSize();
            Application.MainWindow.Location = new System.Drawing.Point(0, 0);
            var newSize = new System.Drawing.Size(config.Location.X, config.Size.Height);
            if (Application.MainWindow.Size != newSize) {
                Application.MainWindow.Size = newSize;
            }
        }
    }
}
