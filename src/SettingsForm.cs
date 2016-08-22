using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace tsign2
{
    public partial class SettingsForm : Form
    {
        private readonly Config config;

        public SettingsForm(Config config)
        {
            InitializeComponent();

            this.config = config;

            LoadSettings(config);
        }

        private void LoadSettings(Settings s)
        {
            signsFileTextBox.Text = s.SignsFile;
            dateTextHeightTextBox.Text = s.DateTextHeight.ToString();
            dateTextFormatTextBox.Text = s.DateTextFormat;
            autoSizeCheckBox.Checked = s.IsAutoSize;
            replaceCharSrcTextBox.Text = s.ReplaceCharSrc;
            replaceCharDstTextBox.Text = s.ReplaceCharDst;

            createMultiSheetsPdfCheckBox.Checked = s.CreateMultiSheetsPdf;
            deleteOneSheetPdfCheckBox.Enabled = createMultiSheetsPdfCheckBox.Checked;
            deleteOneSheetPdfCheckBox.Checked = s.DeleteOneSheetPdf;

            fileBySheetNameRadioButton.Checked = !s.FileBySheetNumber;
            fileBySheetNumberRadioButton.Checked = s.FileBySheetNumber;
            separatorFileNumberTextBox.Text = s.SeparatorFileNumber;
            prefixFileNumberTextBox.Text = s.PrefixFileNumber;

            bookmarkDontCreateRadioButton.Checked = s.BookmarksInPdf == BookmarksInPdf.DontCreate;
            bookmarkBySheetNameRadioButton.Checked = s.BookmarksInPdf == BookmarksInPdf.BySheetName;
            bookmarkBySheetNumberRadioButton.Checked = s.BookmarksInPdf == BookmarksInPdf.BySheetNumber;
            prefixBookmarkNumberTextBox.Text = s.BookmarkPrefix;

            warningSideExcessCheckBox.Checked = s.WarningIfSideExcess;
            allowSideExcessSizeTextBox.Text = s.AllowSideExcessSize.ToString();
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK) {
                if (replaceCharSrcTextBox.Text.Length != replaceCharDstTextBox.Text.Length) {
                    MessageBox.Show("Не совпадает кол-во заменяемых символов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    replaceCharSrcTextBox.Focus();
                    e.Cancel = true;
                    return;
                }
                if (dateTextHeightTextBox.Text.Contains(',')) {
                    dateTextHeightTextBox.Text = dateTextHeightTextBox.Text.Replace(',', '.');
                }
                double dateTextHeight;
                if (!double.TryParse(dateTextHeightTextBox.Text, NumberStyles.Float, NumberFormatInfo.InvariantInfo, out dateTextHeight)) {
                    MessageBox.Show("Недопустимое значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTextHeightTextBox.Focus();
                    e.Cancel = true;
                    return;
                }
                double allowSideExcessSize;
                if (!double.TryParse(allowSideExcessSizeTextBox.Text, NumberStyles.Float, NumberFormatInfo.InvariantInfo, out allowSideExcessSize)) {
                    MessageBox.Show("Недопустимое значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    allowSideExcessSizeTextBox.Focus();
                    e.Cancel = true;
                    return;
                }

                config.SignsFile = signsFileTextBox.Text;
                config.DateTextHeight = dateTextHeight;
                config.DateTextFormat = dateTextFormatTextBox.Text;
                config.IsAutoSize = autoSizeCheckBox.Checked;
                config.ReplaceCharSrc = replaceCharSrcTextBox.Text;
                config.ReplaceCharDst = replaceCharDstTextBox.Text;

                config.FileBySheetNumber = fileBySheetNumberRadioButton.Checked;
                config.SeparatorFileNumber = separatorFileNumberTextBox.Text;
                config.PrefixFileNumber = prefixFileNumberTextBox.Text;
                config.CreateMultiSheetsPdf = createMultiSheetsPdfCheckBox.Checked;
                config.DeleteOneSheetPdf = deleteOneSheetPdfCheckBox.Checked;

                config.BookmarksInPdf = bookmarkDontCreateRadioButton.Checked ?
                    BookmarksInPdf.DontCreate : bookmarkBySheetNameRadioButton.Checked ?
                    BookmarksInPdf.BySheetName :
                    BookmarksInPdf.BySheetNumber;
                config.BookmarkPrefix = prefixBookmarkNumberTextBox.Text;

                config.WarningIfSideExcess = warningSideExcessCheckBox.Checked;
                config.AllowSideExcessSize = allowSideExcessSize;

                config.Save();
            }
        }

        private void createMultiSheetsPdfCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            deleteOneSheetPdfCheckBox.Enabled = createMultiSheetsPdfCheckBox.Checked;
            if (!deleteOneSheetPdfCheckBox.Enabled) {
                deleteOneSheetPdfCheckBox.Checked = false;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            var s = new Settings();

            LoadSettings(s);
        }
    }
}
