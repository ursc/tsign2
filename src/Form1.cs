using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace tsign2
{
    public partial class Form1 : Form
    {
        #region enums
        public enum State
        {
            OK = 0,
            WARNING = 1,
            ERROR = 2,
            CHECK = 3
        }
        #endregion

        #region properties
        private string dateFormat;
        public string DateFormat
        {
            get
            {
                return dateFormat;
            }
            set
            {
                if (dateFormat != value) {
                    dateFormat = value;
                    for (int i = 0; i < signsDataGridView.RowCount; i++) {
                        if (signInserter.Data[i].Date != DateTime.MinValue) {
                            signsDataGridView.Rows[i].Cells[ColDate.Index].Value = signInserter.Data[i].Date.ToString(dateFormat);
                        }
                    }
                }
            }
        }
        #endregion

        #region fields
        private readonly Config config;
        private readonly Dictionary<State, CellColor> cellColors;
        public readonly SignInserter signInserter;
        public readonly SheetPlotter sheetPlotter;
        private int currentSignRow;
        private int undefinedSigns;
        private int withoutDates;
        private int manualDates;
        private int deletedRows;
        private SignUser LastSignUser;
        #endregion

        public Form1(Signs signs, Autodesk.AutoCAD.ApplicationServices.Document doc, Config config)
        {
            InitializeComponent();

            this.config = config;

            Text = Path.GetFileName(config.SignsFile) + " : "
                + signs.LastWriteTime.ToString("dd.MM.yyyy HH:mm:ss") + "           [нажми F1]";

            cellColors = new Dictionary<State, CellColor>() {
                { State.OK,      new CellColor(0xA9FF7A, 0x96E06B) },
                { State.WARNING, new CellColor(0xFFE88E, 0xFFD859) },
                { State.ERROR,   new CellColor(0xFFADAD, 0xFF8C8C) },
                { State.CHECK,   new CellColor(0xFFFFFF, 0xF0F0F0) },
            };

            signsDataGridView.DefaultCellStyle.BackColor = cellColors[State.OK].BackColor;
            signsDataGridView.DefaultCellStyle.SelectionBackColor = cellColors[State.OK].SelectionBackColor;

            labelZoomError.BackColor = cellColors[State.ERROR].BackColor;

            SetDateFormat();

            signInserter = new SignInserter(signs, doc, config);
            sheetPlotter = new SheetPlotter(doc, config);

            pdfTextBox.Text = sheetPlotter.fileNamePdf;

            signsDataGridView.Rows.Clear();
            var layoutName = string.Empty;
            Autodesk.AutoCAD.DatabaseServices.Table table = null;
            int tableNumber = 0;
            var errors = new List<int>();
            foreach (var data in signInserter.Data) {
                if (layoutName != data.Layout.LayoutName) {
                    layoutName = data.Layout.LayoutName;
                    tableNumber = 0;
                }
                if (table != data.Table) {
                    table = data.Table;
                    tableNumber++;
                }
                var emptyDate = data.Date == DateTime.MinValue;
                var row = signsDataGridView.Rows.Add(
                    data.Layout.LayoutName,
                    tableNumber,
                    data.Action,
                    data.Fio,
                    data.SignUser,
                    emptyDate ? "" : data.Date.ToString(dateFormat)
                );

                if (data.SignUser == null || emptyDate) {
                    UpdateCellsColor(row);
                }
            }

            UpdateDocumentProperties();
            UpdateSignDataProperties();
        }

        void SetDateFormat()
        {
            DateFormat = dateYearCheckBox.Checked ? "dd.MM.yy" : "dd.MM.yyyy";
        }

        State ToState(SignDataType dtp)
        {
            switch (dtp) {
                case SignDataType.Error:
                    return State.ERROR;
                case SignDataType.Manual:
                    return State.WARNING;
                default:
                    return State.OK;
            }
        }

        void UpdateCellsColor(int row)
        {
            State state;
            var signData = signInserter.Data[row];
            var cells = signsDataGridView.Rows[row].Cells;
            foreach (DataGridViewCell cell in cells) {
                if (signData.IsDeleted) {
                    state = State.CHECK;
                } else if (cell.ColumnIndex == ColSign.Index) {
                    state = ToState(signData.SignUserType);
                } else if (cell.ColumnIndex == ColDate.Index) {
                    state = ToState(signData.DateType);
                } else {
                    state = State.OK;
                }
                cell.Style.BackColor = cellColors[state].BackColor;
                cell.Style.SelectionBackColor = cellColors[state].SelectionBackColor;
            }
        }

        void DeleteRow(int row)
        {
            signInserter.Data[row].IsDeleted = !signInserter.Data[row].IsDeleted;

            UpdateCellsColor(row);
            UpdateSignDataProperties();
        }

        void SetDate(int row, DateTime date, bool updateSignDataProperties)
        {
            signInserter.Data[row].DateType = SignDataType.Manual;
            signInserter.Data[row].Date = date;
            signsDataGridView.Rows[row].Cells[ColDate.Index].Value = signInserter.Data[row].Date.ToString(dateFormat);

            UpdateCellsColor(row);

            if (updateSignDataProperties) {
                UpdateSignDataProperties();
            }
        }

        void SetSign(int row, SignUser signUser)
        {
            if (LastSignUser != signUser) {
                LastSignUser = signUser;
            }
            signInserter.Data[row].SignUserType = SignDataType.Manual;
            signInserter.Data[row].SignUser = signUser;
            signsDataGridView.Rows[row].Cells[ColSign.Index].Value = signUser;
            
            UpdateCellsColor(row);

            UpdateSignDataProperties();
        }

        void AnyPropertyChanged()
        {
            var noError = undefinedSigns == 0 && withoutDates == 0;
            signButton.Enabled = signInserter.Data.Count > 0 && noError;
            dateReplaceButton.Enabled = manualDates > 0;
            dateReplaceAllButton.Enabled = signsDataGridView.RowCount > 0;
            pdfPlotButton.Enabled = noError && pdfTextBox.Text.Length > 0;
        }

        void UpdateDocumentProperties()
        {
            int layers = Autodesk.AutoCAD.DatabaseServices.LayoutManager.Current.LayoutCount - 1;
            int tableLayers = signInserter.Data.GroupBy(o => o.Layout).Count();
            int tables = signInserter.Data.GroupBy(o => o.Table).Count();
            int signs = signInserter.Data.Count();

            labelLayersValue.Text = layers.ToString();
            labelTableLayersValue.Text = tableLayers.ToString();
            labelTablesValue.Text = tables.ToString();
            labelSignsValue.Text = signs.ToString();

            labelTableLayersValue.BackColor = layers == tableLayers ? labelTableLayers.BackColor : cellColors[State.ERROR].BackColor;
            labelTablesValue.BackColor = tableLayers * 2 == tables ? labelTableLayers.BackColor : cellColors[State.WARNING].BackColor;
        }

        void UpdateSignDataProperties()
        {
            undefinedSigns = 0;
            withoutDates = 0;
            manualDates = 0;
            deletedRows = 0;

            foreach (var data in signInserter.Data) {
                if (data.DateType != SignDataType.Auto) {
                    manualDates++;
                }
                if (data.IsDeleted) {
                    deletedRows++;
                    continue;
                }
                if (data.SignUser == null) {
                    undefinedSigns++;
                }
                if (data.Date == DateTime.MinValue) {
                    withoutDates++;
                }
            }

            labelUndefinedValue.Text = undefinedSigns.ToString();
            labelUndefinedValue.BackColor = undefinedSigns == 0 ? labelTableLayers.BackColor : cellColors[State.ERROR].BackColor;

            labelWithoutDateValue.Text = withoutDates.ToString();
            labelWithoutDateValue.BackColor = withoutDates == 0 ? labelTableLayers.BackColor : cellColors[State.ERROR].BackColor;

            labelDeleted.Visible = labelDeletedValue.Visible = deletedRows > 0;
            labelDeletedValue.Text = deletedRows.ToString();
            labelDeletedValue.BackColor = deletedRows == 0 ? labelTableLayers.BackColor : cellColors[State.WARNING].BackColor;

            AnyPropertyChanged();
        }

        void ShowSignsComboBox(int rowIndex, Rectangle rect)
        {
            currentSignRow = rowIndex;

            signsComboBox.Visible = false;
            signsComboBox.Text = string.Empty;
            signsComboBox.Items.Clear();

            signsComboBox.Left = rect.Left + 2;
            signsComboBox.Top = rect.Top + 2;
            signsComboBox.Width = rect.Width + 1;
            signsComboBox.Height = rect.Height + 2;

            signsComboBox.Items.AddRange(signInserter.Data[rowIndex].SignUsers);
            if (signInserter.Data[rowIndex].SignUser == null && LastSignUser != null
                && signInserter.Data[rowIndex].SignUsers.Any(o => o == LastSignUser)) {
                    SetSign(currentSignRow, LastSignUser);
            }
            signsComboBox.Text = signInserter.Data[rowIndex].SignUser == null ? "" : signInserter.Data[rowIndex].SignUser.ToString();
            signsComboBox.Visible = true;
            signsComboBox.Focus();
        }

        void ShowSignsDateTimePicker(int rowIndex, Rectangle rect)
        {
            currentSignRow = rowIndex;

            signsDateTimePicker.Visible = false;
            signsDateTimePicker.CustomFormat = DateFormat;

            signsDateTimePicker.Left = rect.Left + 2;
            signsDateTimePicker.Top = rect.Top + 2;
            signsDateTimePicker.Width = rect.Width;
            signsDateTimePicker.Height = rect.Height + 4;

            DateTime dt;
            var date = signsDataGridView.Rows[rowIndex].Cells[ColDate.Index].Value.ToString();
            if (DateTime.TryParse(date, out dt)) {
                signsDateTimePicker.Value = dt;
            }

            signsDateTimePicker.Visible = true;
            signsDateTimePicker.Focus();
        }

        #region events
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            } else if (e.KeyCode == Keys.F2) {
                var f = new SettingsForm(config);
                f.ShowDialog();
            } else if (e.KeyCode == Keys.F1) {
                MessageBox.Show(@"  F2 - настройки
  Delete - удалить/восстановить строку
  Escape - закрыть окно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void signsDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) {
                var rows = signsDataGridView.SelectedRows;
                if (rows != null && rows.Count == 1) {
                    DeleteRow(rows[0].Index);
                }
            }
        }

        private void signsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var rows = signsDataGridView.SelectedRows;
            if (rows != null && rows.Count == 1) {
                labelZoomError.Visible = signInserter.ZoomTo(rows[0].Index);
            }
        }

        void signsDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hi = signsDataGridView.HitTest(e.X, e.Y);
            if (hi.Type != DataGridViewHitTestType.Cell) {
                signsDataGridView.ClearSelection();
            } else if (hi.ColumnIndex == ColSign.Index && signInserter.Data[hi.RowIndex].SignUserType != SignDataType.Auto) {
                var rect = signsDataGridView.GetCellDisplayRectangle(hi.ColumnIndex, hi.RowIndex, false);
                ShowSignsComboBox(hi.RowIndex, rect);
            } else if (hi.ColumnIndex == ColDate.Index && signInserter.Data[hi.RowIndex].DateType != SignDataType.Auto) {
                var rect = signsDataGridView.GetCellDisplayRectangle(hi.ColumnIndex, hi.RowIndex, false);
                ShowSignsDateTimePicker(hi.RowIndex, rect);
            }
        }

        private void signsComboBox_Leave(object sender, EventArgs e)
        {
            signsComboBox.Visible = false;
        }

        private void signsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (signsComboBox.Visible && signsDataGridView.Rows[currentSignRow].Cells[ColSign.Index].Value != signsComboBox.SelectedItem) {
                SetSign(currentSignRow, signsComboBox.SelectedItem as SignUser);
            }
        }

        private void signsDateTimePicker_Leave(object sender, EventArgs e)
        {
            if (signsDateTimePicker.Visible) {
                SetDate(currentSignRow, signsDateTimePicker.Value, true);
            }
            signsDateTimePicker.Visible = false;
        }

        private void signsDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            SetDate(currentSignRow, signsDateTimePicker.Value, true);
        }

        private void dateYearCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetDateFormat();
        }

        private void dateReplaceAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < signsDataGridView.RowCount; i++) {
                SetDate(i, dateTimePicker.Value, false);
            }
            UpdateSignDataProperties();
        }

        private void dateReplaceButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < signsDataGridView.RowCount; i++) {
                if (signInserter.Data[i].DateType != SignDataType.Auto) {
                    SetDate(i, dateTimePicker.Value, false);
                }
            }
            UpdateSignDataProperties();
        }

        private void signButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try {
                signInserter.InsertSigns(DateFormat);
            } finally {
                Cursor = DefaultCursor;
            }
        }

        private void pdfTextBox_TextChanged(object sender, EventArgs e)
        {
            sheetPlotter.fileNamePdf = pdfTextBox.Text;
            AnyPropertyChanged();
        }

        private void pdfPlotButton_Click(object sender, EventArgs e)
        {
            var PSTYLEMODE = Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("PSTYLEMODE");
            if (PSTYLEMODE.ToString().Equals("1")) {
                // конвертировать командой: _CONVERTPSTYLES
                MessageBox.Show("Используется цветозависимый стиль печати", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor = Cursors.WaitCursor;
            try {
                sheetPlotter.AllLayoutPlot();
            } finally {
                Cursor = DefaultCursor;
            }
        }
        #endregion
    }
}
