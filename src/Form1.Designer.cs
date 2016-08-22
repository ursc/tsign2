namespace tsign2
{
    partial class Form1
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.signsDataGridView = new System.Windows.Forms.DataGridView();
            this.ColLayout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateYearCheckBox = new System.Windows.Forms.CheckBox();
            this.dateReplaceAllButton = new System.Windows.Forms.Button();
            this.dateReplaceButton = new System.Windows.Forms.Button();
            this.signSeparator = new System.Windows.Forms.Panel();
            this.signButton = new System.Windows.Forms.Button();
            this.pdfSeparator = new System.Windows.Forms.Panel();
            this.pdfLabel = new System.Windows.Forms.Label();
            this.pdfTextBox = new System.Windows.Forms.TextBox();
            this.pdfPlotButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelZoomError = new System.Windows.Forms.Label();
            this.labelDeleted = new System.Windows.Forms.Label();
            this.labelDeletedValue = new System.Windows.Forms.Label();
            this.labelWithoutDate = new System.Windows.Forms.Label();
            this.labelUndefined = new System.Windows.Forms.Label();
            this.labelSigns = new System.Windows.Forms.Label();
            this.labelTables = new System.Windows.Forms.Label();
            this.labelLayers = new System.Windows.Forms.Label();
            this.labelTableLayers = new System.Windows.Forms.Label();
            this.labelLayersValue = new System.Windows.Forms.Label();
            this.labelTableLayersValue = new System.Windows.Forms.Label();
            this.labelTablesValue = new System.Windows.Forms.Label();
            this.labelSignsValue = new System.Windows.Forms.Label();
            this.labelUndefinedValue = new System.Windows.Forms.Label();
            this.labelWithoutDateValue = new System.Windows.Forms.Label();
            this.signsComboBox = new System.Windows.Forms.ComboBox();
            this.signsDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.signsDataGridView)).BeginInit();
            this.flowLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel.Controls.Add(this.signsDataGridView, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanel, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(738, 441);
            this.tableLayoutPanel.TabIndex = 15;
            // 
            // signsDataGridView
            // 
            this.signsDataGridView.AllowUserToAddRows = false;
            this.signsDataGridView.AllowUserToDeleteRows = false;
            this.signsDataGridView.AllowUserToResizeRows = false;
            this.signsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.signsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColLayout,
            this.ColTable,
            this.ColAction,
            this.ColFio,
            this.ColSign,
            this.ColDate});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.signsDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.signsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.signsDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.signsDataGridView.MultiSelect = false;
            this.signsDataGridView.Name = "signsDataGridView";
            this.signsDataGridView.ReadOnly = true;
            this.signsDataGridView.RowHeadersVisible = false;
            this.signsDataGridView.RowHeadersWidth = 40;
            this.signsDataGridView.RowTemplate.Height = 21;
            this.signsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.signsDataGridView.Size = new System.Drawing.Size(552, 441);
            this.signsDataGridView.TabIndex = 16;
            this.signsDataGridView.SelectionChanged += new System.EventHandler(this.signsDataGridView_SelectionChanged);
            this.signsDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.signsDataGridView_KeyDown);
            this.signsDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.signsDataGridView_MouseDown);
            // 
            // ColLayout
            // 
            this.ColLayout.FillWeight = 110F;
            this.ColLayout.HeaderText = "Слой";
            this.ColLayout.Name = "ColLayout";
            this.ColLayout.ReadOnly = true;
            this.ColLayout.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColLayout.Width = 110;
            // 
            // ColTable
            // 
            this.ColTable.FillWeight = 25F;
            this.ColTable.HeaderText = "#";
            this.ColTable.Name = "ColTable";
            this.ColTable.ReadOnly = true;
            this.ColTable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColTable.Width = 25;
            // 
            // ColAction
            // 
            this.ColAction.FillWeight = 120F;
            this.ColAction.HeaderText = "Действие";
            this.ColAction.Name = "ColAction";
            this.ColAction.ReadOnly = true;
            this.ColAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColAction.Width = 120;
            // 
            // ColFio
            // 
            this.ColFio.FillWeight = 85F;
            this.ColFio.HeaderText = "ФИО";
            this.ColFio.Name = "ColFio";
            this.ColFio.ReadOnly = true;
            this.ColFio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColFio.Width = 85;
            // 
            // ColSign
            // 
            this.ColSign.FillWeight = 110F;
            this.ColSign.HeaderText = "Подпись";
            this.ColSign.Name = "ColSign";
            this.ColSign.ReadOnly = true;
            this.ColSign.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColSign.Width = 110;
            // 
            // ColDate
            // 
            this.ColDate.FillWeight = 75F;
            this.ColDate.HeaderText = "Дата";
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
            this.ColDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDate.Width = 75;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel.Controls.Add(this.dateTimePicker);
            this.flowLayoutPanel.Controls.Add(this.dateYearCheckBox);
            this.flowLayoutPanel.Controls.Add(this.dateReplaceAllButton);
            this.flowLayoutPanel.Controls.Add(this.dateReplaceButton);
            this.flowLayoutPanel.Controls.Add(this.signSeparator);
            this.flowLayoutPanel.Controls.Add(this.signButton);
            this.flowLayoutPanel.Controls.Add(this.pdfSeparator);
            this.flowLayoutPanel.Controls.Add(this.pdfLabel);
            this.flowLayoutPanel.Controls.Add(this.pdfTextBox);
            this.flowLayoutPanel.Controls.Add(this.pdfPlotButton);
            this.flowLayoutPanel.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.flowLayoutPanel.Location = new System.Drawing.Point(553, 1);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(184, 439);
            this.flowLayoutPanel.TabIndex = 11;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "dd.MM.yy";
            this.dateTimePicker.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateTimePicker.Location = new System.Drawing.Point(1, 3);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(1, 3, 2, 3);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(183, 21);
            this.dateTimePicker.TabIndex = 16;
            // 
            // dateYearCheckBox
            // 
            this.dateYearCheckBox.Checked = true;
            this.dateYearCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dateYearCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateYearCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateYearCheckBox.Location = new System.Drawing.Point(3, 30);
            this.dateYearCheckBox.Name = "dateYearCheckBox";
            this.dateYearCheckBox.Size = new System.Drawing.Size(180, 19);
            this.dateYearCheckBox.TabIndex = 4;
            this.dateYearCheckBox.Text = "Формат года двузначный";
            this.dateYearCheckBox.UseVisualStyleBackColor = true;
            this.dateYearCheckBox.CheckedChanged += new System.EventHandler(this.dateYearCheckBox_CheckedChanged);
            // 
            // dateReplaceAllButton
            // 
            this.dateReplaceAllButton.AutoSize = true;
            this.dateReplaceAllButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateReplaceAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateReplaceAllButton.Location = new System.Drawing.Point(3, 55);
            this.dateReplaceAllButton.Name = "dateReplaceAllButton";
            this.dateReplaceAllButton.Size = new System.Drawing.Size(180, 25);
            this.dateReplaceAllButton.TabIndex = 17;
            this.dateReplaceAllButton.Text = "Заменить всё";
            this.dateReplaceAllButton.UseVisualStyleBackColor = true;
            this.dateReplaceAllButton.Click += new System.EventHandler(this.dateReplaceAllButton_Click);
            // 
            // dateReplaceButton
            // 
            this.dateReplaceButton.AutoSize = true;
            this.dateReplaceButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateReplaceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateReplaceButton.Location = new System.Drawing.Point(3, 86);
            this.dateReplaceButton.Name = "dateReplaceButton";
            this.dateReplaceButton.Size = new System.Drawing.Size(180, 25);
            this.dateReplaceButton.TabIndex = 18;
            this.dateReplaceButton.Text = "Вставить";
            this.dateReplaceButton.UseVisualStyleBackColor = true;
            this.dateReplaceButton.Click += new System.EventHandler(this.dateReplaceButton_Click);
            // 
            // signSeparator
            // 
            this.signSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.signSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signSeparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.signSeparator.Location = new System.Drawing.Point(3, 123);
            this.signSeparator.Margin = new System.Windows.Forms.Padding(3, 9, 3, 6);
            this.signSeparator.Name = "signSeparator";
            this.signSeparator.Size = new System.Drawing.Size(180, 4);
            this.signSeparator.TabIndex = 22;
            // 
            // signButton
            // 
            this.signButton.AutoSize = true;
            this.signButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.signButton.Location = new System.Drawing.Point(3, 136);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(180, 25);
            this.signButton.TabIndex = 10;
            this.signButton.Text = "Подписать";
            this.signButton.UseVisualStyleBackColor = true;
            this.signButton.Click += new System.EventHandler(this.signButton_Click);
            // 
            // pdfSeparator
            // 
            this.pdfSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pdfSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfSeparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pdfSeparator.Location = new System.Drawing.Point(3, 173);
            this.pdfSeparator.Margin = new System.Windows.Forms.Padding(3, 9, 3, 6);
            this.pdfSeparator.Name = "pdfSeparator";
            this.pdfSeparator.Size = new System.Drawing.Size(180, 4);
            this.pdfSeparator.TabIndex = 19;
            // 
            // pdfLabel
            // 
            this.pdfLabel.AutoSize = true;
            this.pdfLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pdfLabel.Location = new System.Drawing.Point(3, 183);
            this.pdfLabel.Name = "pdfLabel";
            this.pdfLabel.Size = new System.Drawing.Size(180, 15);
            this.pdfLabel.TabIndex = 21;
            this.pdfLabel.Text = "Начало имени PDF файла:";
            // 
            // pdfTextBox
            // 
            this.pdfTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pdfTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pdfTextBox.Location = new System.Drawing.Point(3, 201);
            this.pdfTextBox.Name = "pdfTextBox";
            this.pdfTextBox.Size = new System.Drawing.Size(180, 21);
            this.pdfTextBox.TabIndex = 20;
            this.pdfTextBox.TextChanged += new System.EventHandler(this.pdfTextBox_TextChanged);
            // 
            // pdfPlotButton
            // 
            this.pdfPlotButton.AutoSize = true;
            this.pdfPlotButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfPlotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pdfPlotButton.Location = new System.Drawing.Point(3, 228);
            this.pdfPlotButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.pdfPlotButton.Name = "pdfPlotButton";
            this.pdfPlotButton.Size = new System.Drawing.Size(180, 25);
            this.pdfPlotButton.TabIndex = 11;
            this.pdfPlotButton.Text = "Печать в PDF";
            this.pdfPlotButton.UseVisualStyleBackColor = true;
            this.pdfPlotButton.Click += new System.EventHandler(this.pdfPlotButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelZoomError, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelDeleted, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelDeletedValue, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelWithoutDate, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelUndefined, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelSigns, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelTables, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelLayers, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTableLayers, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelLayersValue, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTableLayersValue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTablesValue, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelSignsValue, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelUndefinedValue, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelWithoutDateValue, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 265);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(180, 136);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // labelZoomError
            // 
            this.labelZoomError.AutoSize = true;
            this.labelZoomError.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelZoomError.Location = new System.Drawing.Point(0, 119);
            this.labelZoomError.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelZoomError.Name = "labelZoomError";
            this.labelZoomError.Size = new System.Drawing.Size(136, 15);
            this.labelZoomError.TabIndex = 11;
            this.labelZoomError.Tag = "";
            this.labelZoomError.Text = "Не выполнен ZOOM";
            this.labelZoomError.Visible = false;
            // 
            // labelDeleted
            // 
            this.labelDeleted.AutoSize = true;
            this.labelDeleted.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDeleted.Location = new System.Drawing.Point(0, 102);
            this.labelDeleted.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelDeleted.Name = "labelDeleted";
            this.labelDeleted.Size = new System.Drawing.Size(136, 15);
            this.labelDeleted.TabIndex = 10;
            this.labelDeleted.Tag = "";
            this.labelDeleted.Text = "Удалено:";
            this.labelDeleted.Visible = false;
            // 
            // labelDeletedValue
            // 
            this.labelDeletedValue.AutoSize = true;
            this.labelDeletedValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDeletedValue.Location = new System.Drawing.Point(136, 102);
            this.labelDeletedValue.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelDeletedValue.Name = "labelDeletedValue";
            this.labelDeletedValue.Size = new System.Drawing.Size(44, 15);
            this.labelDeletedValue.TabIndex = 9;
            this.labelDeletedValue.Visible = false;
            // 
            // labelWithoutDate
            // 
            this.labelWithoutDate.AutoSize = true;
            this.labelWithoutDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelWithoutDate.Location = new System.Drawing.Point(0, 85);
            this.labelWithoutDate.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelWithoutDate.Name = "labelWithoutDate";
            this.labelWithoutDate.Size = new System.Drawing.Size(136, 15);
            this.labelWithoutDate.TabIndex = 9;
            this.labelWithoutDate.Tag = "";
            this.labelWithoutDate.Text = "Без даты:";
            // 
            // labelUndefined
            // 
            this.labelUndefined.AutoSize = true;
            this.labelUndefined.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelUndefined.Location = new System.Drawing.Point(0, 68);
            this.labelUndefined.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelUndefined.Name = "labelUndefined";
            this.labelUndefined.Size = new System.Drawing.Size(136, 15);
            this.labelUndefined.TabIndex = 6;
            this.labelUndefined.Tag = "";
            this.labelUndefined.Text = "Не определено:";
            // 
            // labelSigns
            // 
            this.labelSigns.AutoSize = true;
            this.labelSigns.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSigns.Location = new System.Drawing.Point(0, 51);
            this.labelSigns.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelSigns.Name = "labelSigns";
            this.labelSigns.Size = new System.Drawing.Size(136, 15);
            this.labelSigns.TabIndex = 5;
            this.labelSigns.Tag = "";
            this.labelSigns.Text = "Подписей:";
            // 
            // labelTables
            // 
            this.labelTables.AutoSize = true;
            this.labelTables.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTables.Location = new System.Drawing.Point(0, 34);
            this.labelTables.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelTables.Name = "labelTables";
            this.labelTables.Size = new System.Drawing.Size(136, 15);
            this.labelTables.TabIndex = 3;
            this.labelTables.Tag = "";
            this.labelTables.Text = "Таблиц (с подписями):";
            // 
            // labelLayers
            // 
            this.labelLayers.AutoSize = true;
            this.labelLayers.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLayers.Location = new System.Drawing.Point(0, 0);
            this.labelLayers.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelLayers.Name = "labelLayers";
            this.labelLayers.Size = new System.Drawing.Size(136, 15);
            this.labelLayers.TabIndex = 0;
            this.labelLayers.Text = "Слоёв (без Model):";
            // 
            // labelTableLayers
            // 
            this.labelTableLayers.AutoSize = true;
            this.labelTableLayers.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTableLayers.Location = new System.Drawing.Point(0, 17);
            this.labelTableLayers.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelTableLayers.Name = "labelTableLayers";
            this.labelTableLayers.Size = new System.Drawing.Size(136, 15);
            this.labelTableLayers.TabIndex = 2;
            this.labelTableLayers.Tag = "";
            this.labelTableLayers.Text = "Слоёв (с подписями):";
            // 
            // labelLayersValue
            // 
            this.labelLayersValue.AutoSize = true;
            this.labelLayersValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLayersValue.Location = new System.Drawing.Point(136, 0);
            this.labelLayersValue.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelLayersValue.Name = "labelLayersValue";
            this.labelLayersValue.Size = new System.Drawing.Size(44, 15);
            this.labelLayersValue.TabIndex = 1;
            // 
            // labelTableLayersValue
            // 
            this.labelTableLayersValue.AutoSize = true;
            this.labelTableLayersValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTableLayersValue.Location = new System.Drawing.Point(136, 17);
            this.labelTableLayersValue.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelTableLayersValue.Name = "labelTableLayersValue";
            this.labelTableLayersValue.Size = new System.Drawing.Size(44, 15);
            this.labelTableLayersValue.TabIndex = 7;
            // 
            // labelTablesValue
            // 
            this.labelTablesValue.AutoSize = true;
            this.labelTablesValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTablesValue.Location = new System.Drawing.Point(136, 34);
            this.labelTablesValue.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelTablesValue.Name = "labelTablesValue";
            this.labelTablesValue.Size = new System.Drawing.Size(44, 15);
            this.labelTablesValue.TabIndex = 4;
            // 
            // labelSignsValue
            // 
            this.labelSignsValue.AutoSize = true;
            this.labelSignsValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSignsValue.Location = new System.Drawing.Point(136, 51);
            this.labelSignsValue.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelSignsValue.Name = "labelSignsValue";
            this.labelSignsValue.Size = new System.Drawing.Size(44, 15);
            this.labelSignsValue.TabIndex = 6;
            // 
            // labelUndefinedValue
            // 
            this.labelUndefinedValue.AutoSize = true;
            this.labelUndefinedValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelUndefinedValue.Location = new System.Drawing.Point(136, 68);
            this.labelUndefinedValue.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelUndefinedValue.Name = "labelUndefinedValue";
            this.labelUndefinedValue.Size = new System.Drawing.Size(44, 15);
            this.labelUndefinedValue.TabIndex = 8;
            // 
            // labelWithoutDateValue
            // 
            this.labelWithoutDateValue.AutoSize = true;
            this.labelWithoutDateValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelWithoutDateValue.Location = new System.Drawing.Point(136, 85);
            this.labelWithoutDateValue.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelWithoutDateValue.Name = "labelWithoutDateValue";
            this.labelWithoutDateValue.Size = new System.Drawing.Size(44, 15);
            this.labelWithoutDateValue.TabIndex = 10;
            // 
            // signsComboBox
            // 
            this.signsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.signsComboBox.FormattingEnabled = true;
            this.signsComboBox.Location = new System.Drawing.Point(85, 253);
            this.signsComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.signsComboBox.Name = "signsComboBox";
            this.signsComboBox.Size = new System.Drawing.Size(121, 21);
            this.signsComboBox.TabIndex = 16;
            this.signsComboBox.Visible = false;
            this.signsComboBox.SelectedIndexChanged += new System.EventHandler(this.signsComboBox_SelectedIndexChanged);
            this.signsComboBox.Leave += new System.EventHandler(this.signsComboBox_Leave);
            // 
            // signsDateTimePicker
            // 
            this.signsDateTimePicker.CustomFormat = "dd.MM.yy";
            this.signsDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.signsDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.signsDateTimePicker.Location = new System.Drawing.Point(236, 239);
            this.signsDateTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.signsDateTimePicker.Name = "signsDateTimePicker";
            this.signsDateTimePicker.Size = new System.Drawing.Size(148, 21);
            this.signsDateTimePicker.TabIndex = 17;
            this.signsDateTimePicker.Visible = false;
            this.signsDateTimePicker.ValueChanged += new System.EventHandler(this.signsDateTimePicker_ValueChanged);
            this.signsDateTimePicker.Leave += new System.EventHandler(this.signsDateTimePicker_Leave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 447);
            this.Controls.Add(this.signsDateTimePicker);
            this.Controls.Add(this.signsComboBox);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(760, 485);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Подпись и печать";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.signsDataGridView)).EndInit();
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button signButton;
        private System.Windows.Forms.Button pdfPlotButton;
        private System.Windows.Forms.CheckBox dateYearCheckBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button dateReplaceAllButton;
        private System.Windows.Forms.Button dateReplaceButton;
        private System.Windows.Forms.Panel pdfSeparator;
        private System.Windows.Forms.Label pdfLabel;
        private System.Windows.Forms.Panel signSeparator;
        private System.Windows.Forms.TextBox pdfTextBox;
        public System.Windows.Forms.DataGridView signsDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelLayers;
        private System.Windows.Forms.Label labelTableLayers;
        private System.Windows.Forms.Label labelLayersValue;
        private System.Windows.Forms.Label labelWithoutDate;
        private System.Windows.Forms.Label labelUndefined;
        private System.Windows.Forms.Label labelSigns;
        private System.Windows.Forms.Label labelTables;
        private System.Windows.Forms.Label labelTableLayersValue;
        private System.Windows.Forms.Label labelTablesValue;
        private System.Windows.Forms.Label labelSignsValue;
        private System.Windows.Forms.Label labelUndefinedValue;
        private System.Windows.Forms.Label labelWithoutDateValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLayout;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.ComboBox signsComboBox;
        private System.Windows.Forms.DateTimePicker signsDateTimePicker;
        private System.Windows.Forms.Label labelZoomError;
        private System.Windows.Forms.Label labelDeleted;
        private System.Windows.Forms.Label labelDeletedValue;

    }
}
