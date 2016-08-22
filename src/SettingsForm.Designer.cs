namespace tsign2
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.signsFileTextBox = new System.Windows.Forms.TextBox();
            this.signsFileLabel = new System.Windows.Forms.Label();
            this.replaceCharSrcTextBox = new System.Windows.Forms.TextBox();
            this.replaceCharToLabel = new System.Windows.Forms.Label();
            this.replaceCharDstTextBox = new System.Windows.Forms.TextBox();
            this.dateTextHeightLabel = new System.Windows.Forms.Label();
            this.dateTextHeightTextBox = new System.Windows.Forms.TextBox();
            this.dateTextFormatLabel = new System.Windows.Forms.Label();
            this.dateTextFormatTextBox = new System.Windows.Forms.TextBox();
            this.prefixFileNumberLabel = new System.Windows.Forms.Label();
            this.prefixFileNumberTextBox = new System.Windows.Forms.TextBox();
            this.fileBySheetNameRadioButton = new System.Windows.Forms.RadioButton();
            this.replaceCharGroupBox = new System.Windows.Forms.GroupBox();
            this.textGroupBox = new System.Windows.Forms.GroupBox();
            this.pdfGroupBox = new System.Windows.Forms.GroupBox();
            this.bookmarkGroupBox = new System.Windows.Forms.GroupBox();
            this.prefixBookmarkNumberLabel = new System.Windows.Forms.Label();
            this.prefixBookmarkNumberTextBox = new System.Windows.Forms.TextBox();
            this.bookmarkDontCreateRadioButton = new System.Windows.Forms.RadioButton();
            this.bookmarkBySheetNameRadioButton = new System.Windows.Forms.RadioButton();
            this.bookmarkBySheetNumberRadioButton = new System.Windows.Forms.RadioButton();
            this.fileNameGroupBox = new System.Windows.Forms.GroupBox();
            this.fileBySheetNumberRadioButton = new System.Windows.Forms.RadioButton();
            this.deleteOneSheetPdfCheckBox = new System.Windows.Forms.CheckBox();
            this.createMultiSheetsPdfCheckBox = new System.Windows.Forms.CheckBox();
            this.autoSizeCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.separatorFileNumberLabel = new System.Windows.Forms.Label();
            this.separatorFileNumberTextBox = new System.Windows.Forms.TextBox();
            this.formatPaperGroupBox = new System.Windows.Forms.GroupBox();
            this.allowSideExcessSizeTextBox = new System.Windows.Forms.TextBox();
            this.warningSideExcessCheckBox = new System.Windows.Forms.CheckBox();
            this.replaceCharGroupBox.SuspendLayout();
            this.textGroupBox.SuspendLayout();
            this.pdfGroupBox.SuspendLayout();
            this.bookmarkGroupBox.SuspendLayout();
            this.fileNameGroupBox.SuspendLayout();
            this.formatPaperGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(208, 489);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Сохранить";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(347, 489);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // signsFileTextBox
            // 
            this.signsFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.signsFileTextBox.Location = new System.Drawing.Point(12, 33);
            this.signsFileTextBox.Name = "signsFileTextBox";
            this.signsFileTextBox.Size = new System.Drawing.Size(431, 21);
            this.signsFileTextBox.TabIndex = 2;
            // 
            // signsFileLabel
            // 
            this.signsFileLabel.AutoSize = true;
            this.signsFileLabel.Location = new System.Drawing.Point(9, 16);
            this.signsFileLabel.Name = "signsFileLabel";
            this.signsFileLabel.Size = new System.Drawing.Size(231, 13);
            this.signsFileLabel.TabIndex = 3;
            this.signsFileLabel.Text = "Путь к файлу с подписями (\"Подписи.dwg\"):";
            // 
            // replaceCharSrcTextBox
            // 
            this.replaceCharSrcTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.replaceCharSrcTextBox.Location = new System.Drawing.Point(6, 19);
            this.replaceCharSrcTextBox.Name = "replaceCharSrcTextBox";
            this.replaceCharSrcTextBox.Size = new System.Drawing.Size(195, 21);
            this.replaceCharSrcTextBox.TabIndex = 5;
            // 
            // replaceCharToLabel
            // 
            this.replaceCharToLabel.AutoSize = true;
            this.replaceCharToLabel.Location = new System.Drawing.Point(205, 22);
            this.replaceCharToLabel.Name = "replaceCharToLabel";
            this.replaceCharToLabel.Size = new System.Drawing.Size(19, 13);
            this.replaceCharToLabel.TabIndex = 6;
            this.replaceCharToLabel.Text = "=>";
            // 
            // replaceCharDstTextBox
            // 
            this.replaceCharDstTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.replaceCharDstTextBox.Location = new System.Drawing.Point(230, 19);
            this.replaceCharDstTextBox.Name = "replaceCharDstTextBox";
            this.replaceCharDstTextBox.Size = new System.Drawing.Size(195, 21);
            this.replaceCharDstTextBox.TabIndex = 7;
            // 
            // dateTextHeightLabel
            // 
            this.dateTextHeightLabel.AutoSize = true;
            this.dateTextHeightLabel.Location = new System.Drawing.Point(6, 22);
            this.dateTextHeightLabel.Name = "dateTextHeightLabel";
            this.dateTextHeightLabel.Size = new System.Drawing.Size(48, 13);
            this.dateTextHeightLabel.TabIndex = 8;
            this.dateTextHeightLabel.Text = "Высота:";
            // 
            // dateTextHeightTextBox
            // 
            this.dateTextHeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTextHeightTextBox.Location = new System.Drawing.Point(56, 19);
            this.dateTextHeightTextBox.Name = "dateTextHeightTextBox";
            this.dateTextHeightTextBox.Size = new System.Drawing.Size(77, 21);
            this.dateTextHeightTextBox.TabIndex = 9;
            // 
            // dateTextFormatLabel
            // 
            this.dateTextFormatLabel.AutoSize = true;
            this.dateTextFormatLabel.Location = new System.Drawing.Point(172, 22);
            this.dateTextFormatLabel.Name = "dateTextFormatLabel";
            this.dateTextFormatLabel.Size = new System.Drawing.Size(52, 13);
            this.dateTextFormatLabel.TabIndex = 10;
            this.dateTextFormatLabel.Text = "Формат:";
            // 
            // dateTextFormatTextBox
            // 
            this.dateTextFormatTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTextFormatTextBox.Location = new System.Drawing.Point(230, 19);
            this.dateTextFormatTextBox.Name = "dateTextFormatTextBox";
            this.dateTextFormatTextBox.Size = new System.Drawing.Size(195, 21);
            this.dateTextFormatTextBox.TabIndex = 11;
            // 
            // prefixFileNumberLabel
            // 
            this.prefixFileNumberLabel.AutoSize = true;
            this.prefixFileNumberLabel.Location = new System.Drawing.Point(218, 44);
            this.prefixFileNumberLabel.Name = "prefixFileNumberLabel";
            this.prefixFileNumberLabel.Size = new System.Drawing.Size(56, 13);
            this.prefixFileNumberLabel.TabIndex = 12;
            this.prefixFileNumberLabel.Text = "Префикс:";
            // 
            // prefixFileNumberTextBox
            // 
            this.prefixFileNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prefixFileNumberTextBox.Location = new System.Drawing.Point(300, 39);
            this.prefixFileNumberTextBox.Name = "prefixFileNumberTextBox";
            this.prefixFileNumberTextBox.Size = new System.Drawing.Size(110, 21);
            this.prefixFileNumberTextBox.TabIndex = 13;
            // 
            // fileBySheetNameRadioButton
            // 
            this.fileBySheetNameRadioButton.AutoSize = true;
            this.fileBySheetNameRadioButton.Location = new System.Drawing.Point(9, 19);
            this.fileBySheetNameRadioButton.Name = "fileBySheetNameRadioButton";
            this.fileBySheetNameRadioButton.Size = new System.Drawing.Size(104, 17);
            this.fileBySheetNameRadioButton.TabIndex = 14;
            this.fileBySheetNameRadioButton.TabStop = true;
            this.fileBySheetNameRadioButton.Text = "по имени листа";
            this.fileBySheetNameRadioButton.UseVisualStyleBackColor = true;
            // 
            // replaceCharGroupBox
            // 
            this.replaceCharGroupBox.Controls.Add(this.replaceCharSrcTextBox);
            this.replaceCharGroupBox.Controls.Add(this.replaceCharDstTextBox);
            this.replaceCharGroupBox.Controls.Add(this.replaceCharToLabel);
            this.replaceCharGroupBox.Location = new System.Drawing.Point(12, 59);
            this.replaceCharGroupBox.Name = "replaceCharGroupBox";
            this.replaceCharGroupBox.Size = new System.Drawing.Size(431, 51);
            this.replaceCharGroupBox.TabIndex = 15;
            this.replaceCharGroupBox.TabStop = false;
            this.replaceCharGroupBox.Text = "Заменяемые символы (при поиске подписей)";
            // 
            // textGroupBox
            // 
            this.textGroupBox.Controls.Add(this.dateTextHeightTextBox);
            this.textGroupBox.Controls.Add(this.dateTextHeightLabel);
            this.textGroupBox.Controls.Add(this.dateTextFormatLabel);
            this.textGroupBox.Controls.Add(this.dateTextFormatTextBox);
            this.textGroupBox.Location = new System.Drawing.Point(12, 116);
            this.textGroupBox.Name = "textGroupBox";
            this.textGroupBox.Size = new System.Drawing.Size(431, 51);
            this.textGroupBox.TabIndex = 16;
            this.textGroupBox.TabStop = false;
            this.textGroupBox.Text = "Параметры текста";
            // 
            // pdfGroupBox
            // 
            this.pdfGroupBox.Controls.Add(this.bookmarkGroupBox);
            this.pdfGroupBox.Controls.Add(this.fileNameGroupBox);
            this.pdfGroupBox.Controls.Add(this.deleteOneSheetPdfCheckBox);
            this.pdfGroupBox.Controls.Add(this.createMultiSheetsPdfCheckBox);
            this.pdfGroupBox.Location = new System.Drawing.Point(12, 173);
            this.pdfGroupBox.Name = "pdfGroupBox";
            this.pdfGroupBox.Size = new System.Drawing.Size(431, 220);
            this.pdfGroupBox.TabIndex = 17;
            this.pdfGroupBox.TabStop = false;
            this.pdfGroupBox.Text = "PDF";
            // 
            // bookmarkGroupBox
            // 
            this.bookmarkGroupBox.Controls.Add(this.prefixBookmarkNumberLabel);
            this.bookmarkGroupBox.Controls.Add(this.prefixBookmarkNumberTextBox);
            this.bookmarkGroupBox.Controls.Add(this.bookmarkDontCreateRadioButton);
            this.bookmarkGroupBox.Controls.Add(this.bookmarkBySheetNameRadioButton);
            this.bookmarkGroupBox.Controls.Add(this.bookmarkBySheetNumberRadioButton);
            this.bookmarkGroupBox.Location = new System.Drawing.Point(9, 117);
            this.bookmarkGroupBox.Name = "bookmarkGroupBox";
            this.bookmarkGroupBox.Size = new System.Drawing.Size(416, 94);
            this.bookmarkGroupBox.TabIndex = 19;
            this.bookmarkGroupBox.TabStop = false;
            this.bookmarkGroupBox.Text = "Закладки в многостраничном PDF";
            // 
            // prefixBookmarkNumberLabel
            // 
            this.prefixBookmarkNumberLabel.AutoSize = true;
            this.prefixBookmarkNumberLabel.Location = new System.Drawing.Point(218, 67);
            this.prefixBookmarkNumberLabel.Name = "prefixBookmarkNumberLabel";
            this.prefixBookmarkNumberLabel.Size = new System.Drawing.Size(56, 13);
            this.prefixBookmarkNumberLabel.TabIndex = 17;
            this.prefixBookmarkNumberLabel.Text = "Префикс:";
            // 
            // prefixBookmarkNumberTextBox
            // 
            this.prefixBookmarkNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prefixBookmarkNumberTextBox.Location = new System.Drawing.Point(300, 62);
            this.prefixBookmarkNumberTextBox.Name = "prefixBookmarkNumberTextBox";
            this.prefixBookmarkNumberTextBox.Size = new System.Drawing.Size(110, 21);
            this.prefixBookmarkNumberTextBox.TabIndex = 18;
            // 
            // bookmarkDontCreateRadioButton
            // 
            this.bookmarkDontCreateRadioButton.AutoSize = true;
            this.bookmarkDontCreateRadioButton.Location = new System.Drawing.Point(9, 19);
            this.bookmarkDontCreateRadioButton.Name = "bookmarkDontCreateRadioButton";
            this.bookmarkDontCreateRadioButton.Size = new System.Drawing.Size(93, 17);
            this.bookmarkDontCreateRadioButton.TabIndex = 16;
            this.bookmarkDontCreateRadioButton.TabStop = true;
            this.bookmarkDontCreateRadioButton.Text = "не создавать";
            this.bookmarkDontCreateRadioButton.UseVisualStyleBackColor = true;
            // 
            // bookmarkBySheetNameRadioButton
            // 
            this.bookmarkBySheetNameRadioButton.AutoSize = true;
            this.bookmarkBySheetNameRadioButton.Location = new System.Drawing.Point(9, 42);
            this.bookmarkBySheetNameRadioButton.Name = "bookmarkBySheetNameRadioButton";
            this.bookmarkBySheetNameRadioButton.Size = new System.Drawing.Size(104, 17);
            this.bookmarkBySheetNameRadioButton.TabIndex = 14;
            this.bookmarkBySheetNameRadioButton.TabStop = true;
            this.bookmarkBySheetNameRadioButton.Text = "по имени листа";
            this.bookmarkBySheetNameRadioButton.UseVisualStyleBackColor = true;
            // 
            // bookmarkBySheetNumberRadioButton
            // 
            this.bookmarkBySheetNumberRadioButton.AutoSize = true;
            this.bookmarkBySheetNumberRadioButton.Location = new System.Drawing.Point(9, 65);
            this.bookmarkBySheetNumberRadioButton.Name = "bookmarkBySheetNumberRadioButton";
            this.bookmarkBySheetNumberRadioButton.Size = new System.Drawing.Size(109, 17);
            this.bookmarkBySheetNumberRadioButton.TabIndex = 15;
            this.bookmarkBySheetNumberRadioButton.TabStop = true;
            this.bookmarkBySheetNumberRadioButton.Text = "по номеру листа";
            this.bookmarkBySheetNumberRadioButton.UseVisualStyleBackColor = true;
            // 
            // fileNameGroupBox
            // 
            this.fileNameGroupBox.Controls.Add(this.separatorFileNumberLabel);
            this.fileNameGroupBox.Controls.Add(this.separatorFileNumberTextBox);
            this.fileNameGroupBox.Controls.Add(this.fileBySheetNameRadioButton);
            this.fileNameGroupBox.Controls.Add(this.fileBySheetNumberRadioButton);
            this.fileNameGroupBox.Controls.Add(this.prefixFileNumberLabel);
            this.fileNameGroupBox.Controls.Add(this.prefixFileNumberTextBox);
            this.fileNameGroupBox.Location = new System.Drawing.Point(9, 42);
            this.fileNameGroupBox.Name = "fileNameGroupBox";
            this.fileNameGroupBox.Size = new System.Drawing.Size(416, 69);
            this.fileNameGroupBox.TabIndex = 18;
            this.fileNameGroupBox.TabStop = false;
            this.fileNameGroupBox.Text = "Окончание имени файла";
            // 
            // fileBySheetNumberRadioButton
            // 
            this.fileBySheetNumberRadioButton.AutoSize = true;
            this.fileBySheetNumberRadioButton.Location = new System.Drawing.Point(9, 42);
            this.fileBySheetNumberRadioButton.Name = "fileBySheetNumberRadioButton";
            this.fileBySheetNumberRadioButton.Size = new System.Drawing.Size(109, 17);
            this.fileBySheetNumberRadioButton.TabIndex = 15;
            this.fileBySheetNumberRadioButton.TabStop = true;
            this.fileBySheetNumberRadioButton.Text = "по номеру листа";
            this.fileBySheetNumberRadioButton.UseVisualStyleBackColor = true;
            // 
            // deleteOneSheetPdfCheckBox
            // 
            this.deleteOneSheetPdfCheckBox.AutoSize = true;
            this.deleteOneSheetPdfCheckBox.Location = new System.Drawing.Point(230, 19);
            this.deleteOneSheetPdfCheckBox.Name = "deleteOneSheetPdfCheckBox";
            this.deleteOneSheetPdfCheckBox.Size = new System.Drawing.Size(180, 17);
            this.deleteOneSheetPdfCheckBox.TabIndex = 17;
            this.deleteOneSheetPdfCheckBox.Text = "Удалять одностраничные PDF";
            this.deleteOneSheetPdfCheckBox.UseVisualStyleBackColor = true;
            // 
            // createMultiSheetsPdfCheckBox
            // 
            this.createMultiSheetsPdfCheckBox.AutoSize = true;
            this.createMultiSheetsPdfCheckBox.Location = new System.Drawing.Point(18, 19);
            this.createMultiSheetsPdfCheckBox.Name = "createMultiSheetsPdfCheckBox";
            this.createMultiSheetsPdfCheckBox.Size = new System.Drawing.Size(198, 17);
            this.createMultiSheetsPdfCheckBox.TabIndex = 16;
            this.createMultiSheetsPdfCheckBox.Text = "Создавать многостраничный PDF";
            this.createMultiSheetsPdfCheckBox.UseVisualStyleBackColor = true;
            this.createMultiSheetsPdfCheckBox.CheckedChanged += new System.EventHandler(this.createMultiSheetsPdfCheckBox_CheckedChanged);
            // 
            // autoSizeCheckBox
            // 
            this.autoSizeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autoSizeCheckBox.AutoSize = true;
            this.autoSizeCheckBox.Location = new System.Drawing.Point(12, 458);
            this.autoSizeCheckBox.Name = "autoSizeCheckBox";
            this.autoSizeCheckBox.Size = new System.Drawing.Size(280, 17);
            this.autoSizeCheckBox.TabIndex = 18;
            this.autoSizeCheckBox.Text = "Автоматическая установка размера и положения";
            this.autoSizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReset.Location = new System.Drawing.Point(41, 489);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(107, 23);
            this.buttonReset.TabIndex = 19;
            this.buttonReset.Text = "По умолчанию";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // separatorFileNumberLabel
            // 
            this.separatorFileNumberLabel.AutoSize = true;
            this.separatorFileNumberLabel.Location = new System.Drawing.Point(218, 21);
            this.separatorFileNumberLabel.Name = "separatorFileNumberLabel";
            this.separatorFileNumberLabel.Size = new System.Drawing.Size(76, 13);
            this.separatorFileNumberLabel.TabIndex = 16;
            this.separatorFileNumberLabel.Text = "Разделитель:";
            // 
            // separatorFileNumberTextBox
            // 
            this.separatorFileNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.separatorFileNumberTextBox.Location = new System.Drawing.Point(300, 16);
            this.separatorFileNumberTextBox.Name = "separatorFileNumberTextBox";
            this.separatorFileNumberTextBox.Size = new System.Drawing.Size(110, 21);
            this.separatorFileNumberTextBox.TabIndex = 17;
            // 
            // formatPaperGroupBox
            // 
            this.formatPaperGroupBox.Controls.Add(this.warningSideExcessCheckBox);
            this.formatPaperGroupBox.Controls.Add(this.allowSideExcessSizeTextBox);
            this.formatPaperGroupBox.Location = new System.Drawing.Point(12, 399);
            this.formatPaperGroupBox.Name = "formatPaperGroupBox";
            this.formatPaperGroupBox.Size = new System.Drawing.Size(431, 46);
            this.formatPaperGroupBox.TabIndex = 20;
            this.formatPaperGroupBox.TabStop = false;
            this.formatPaperGroupBox.Text = "Автоматический выбор формата бумаги для печати";
            // 
            // allowSideExcessSizeTextBox
            // 
            this.allowSideExcessSizeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allowSideExcessSizeTextBox.Location = new System.Drawing.Point(352, 15);
            this.allowSideExcessSizeTextBox.Name = "allowSideExcessSizeTextBox";
            this.allowSideExcessSizeTextBox.Size = new System.Drawing.Size(67, 21);
            this.allowSideExcessSizeTextBox.TabIndex = 11;
            // 
            // warningSideExcessCheckBox
            // 
            this.warningSideExcessCheckBox.AutoSize = true;
            this.warningSideExcessCheckBox.Location = new System.Drawing.Point(13, 19);
            this.warningSideExcessCheckBox.Name = "warningSideExcessCheckBox";
            this.warningSideExcessCheckBox.Size = new System.Drawing.Size(318, 17);
            this.warningSideExcessCheckBox.TabIndex = 12;
            this.warningSideExcessCheckBox.Text = "Предупреждать при превышении любой стороны на (мм):";
            this.warningSideExcessCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 524);
            this.Controls.Add(this.formatPaperGroupBox);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.autoSizeCheckBox);
            this.Controls.Add(this.pdfGroupBox);
            this.Controls.Add(this.textGroupBox);
            this.Controls.Add(this.replaceCharGroupBox);
            this.Controls.Add(this.signsFileLabel);
            this.Controls.Add(this.signsFileTextBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsForm_KeyDown);
            this.replaceCharGroupBox.ResumeLayout(false);
            this.replaceCharGroupBox.PerformLayout();
            this.textGroupBox.ResumeLayout(false);
            this.textGroupBox.PerformLayout();
            this.pdfGroupBox.ResumeLayout(false);
            this.pdfGroupBox.PerformLayout();
            this.bookmarkGroupBox.ResumeLayout(false);
            this.bookmarkGroupBox.PerformLayout();
            this.fileNameGroupBox.ResumeLayout(false);
            this.fileNameGroupBox.PerformLayout();
            this.formatPaperGroupBox.ResumeLayout(false);
            this.formatPaperGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label signsFileLabel;
        private System.Windows.Forms.Label replaceCharToLabel;
        private System.Windows.Forms.Label dateTextHeightLabel;
        private System.Windows.Forms.Label dateTextFormatLabel;
        private System.Windows.Forms.Label prefixFileNumberLabel;
        private System.Windows.Forms.GroupBox replaceCharGroupBox;
        private System.Windows.Forms.GroupBox textGroupBox;
        private System.Windows.Forms.GroupBox pdfGroupBox;
        public System.Windows.Forms.CheckBox autoSizeCheckBox;
        public System.Windows.Forms.TextBox signsFileTextBox;
        public System.Windows.Forms.TextBox replaceCharSrcTextBox;
        public System.Windows.Forms.TextBox replaceCharDstTextBox;
        public System.Windows.Forms.TextBox dateTextHeightTextBox;
        public System.Windows.Forms.TextBox dateTextFormatTextBox;
        public System.Windows.Forms.TextBox prefixFileNumberTextBox;
        public System.Windows.Forms.RadioButton fileBySheetNameRadioButton;
        public System.Windows.Forms.CheckBox deleteOneSheetPdfCheckBox;
        public System.Windows.Forms.CheckBox createMultiSheetsPdfCheckBox;
        public System.Windows.Forms.RadioButton fileBySheetNumberRadioButton;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.GroupBox bookmarkGroupBox;
        private System.Windows.Forms.Label prefixBookmarkNumberLabel;
        public System.Windows.Forms.TextBox prefixBookmarkNumberTextBox;
        public System.Windows.Forms.RadioButton bookmarkDontCreateRadioButton;
        public System.Windows.Forms.RadioButton bookmarkBySheetNameRadioButton;
        public System.Windows.Forms.RadioButton bookmarkBySheetNumberRadioButton;
        private System.Windows.Forms.GroupBox fileNameGroupBox;
        private System.Windows.Forms.Label separatorFileNumberLabel;
        public System.Windows.Forms.TextBox separatorFileNumberTextBox;
        private System.Windows.Forms.GroupBox formatPaperGroupBox;
        private System.Windows.Forms.CheckBox warningSideExcessCheckBox;
        public System.Windows.Forms.TextBox allowSideExcessSizeTextBox;
    }
}