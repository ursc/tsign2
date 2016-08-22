using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace tsign2
{
    public enum BookmarksInPdf { DontCreate, BySheetName, BySheetNumber };

    [Serializable()]
    public class Settings
    {
        public bool IsAutoSize;
        public bool CreateMultiSheetsPdf;
        public bool DeleteOneSheetPdf;
        public bool FileBySheetNumber;
        public string SeparatorFileNumber;
        public string PrefixFileNumber;
        public string SignsFile;
        public string ReplaceCharSrc;
        public string ReplaceCharDst;
        public double DateTextHeight;
        public string DateTextFormat;
        public BookmarksInPdf BookmarksInPdf;
        public string BookmarkPrefix;
        public bool WarningIfSideExcess;
        public double AllowSideExcessSize;

        public Settings()
        {
            IsAutoSize = false;
            CreateMultiSheetsPdf = true;
            DeleteOneSheetPdf = false;
            FileBySheetNumber = true;
            SeparatorFileNumber = "-";
            PrefixFileNumber = "л.";
            SignsFile = @"\\netshare\all\file.dwg";
            ReplaceCharSrc = "ёЁ";
            ReplaceCharDst = "еЕ";
            DateTextHeight = 2.5;
            DateTextFormat = "\\W0.65;";
            BookmarksInPdf = BookmarksInPdf.BySheetName;
            BookmarkPrefix = "";
            WarningIfSideExcess = true;
            AllowSideExcessSize = 10;
        }
    }

    [Serializable()]
    public class Config : Settings
    {
        public Point Location;
        public Size Size;
        public bool Maximized;

        [field: NonSerialized()]
        private static string configFileName;

        protected Config() : base()
        {
            Location = new Point(100, 100);
            Size = new Size(760, 485);
            Maximized = false;
        }

        public static Config LoadConfig(string filename)
        {
            configFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
            if (File.Exists(configFileName)) {
                var formatter = new BinaryFormatter();
                using (Stream stream = File.OpenRead(configFileName)) {
                    try {
                        return (Config)formatter.Deserialize(stream);
                    } catch {}
                }
            }

            return new Config();
        }

        public Settings DefaultSettings()
        {
            return new Settings();
        }

        public void AutoSize()
        {
            var workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;

            Size = new Size(760, workingArea.Height);
            Location = new Point(workingArea.Width - Size.Width, 0);
        }

        public void RestoreForm(Form form)
        {
            if (Maximized) {
                form.WindowState = FormWindowState.Maximized;
            }
            form.Location = Location;
            form.Size = Size;
        }

        public void SaveForm(Form form)
        {
            Maximized = form.WindowState == FormWindowState.Maximized;
            Size = Maximized ? form.RestoreBounds.Size : form.Size;
            Location = Maximized ? form.RestoreBounds.Location : form.Location;
        }

        public void Save()
        {
            var formatter = new BinaryFormatter();
            Stream stream = File.Create(configFileName);
            formatter.Serialize(stream, this);
            stream.Close();
        }
    }
}
