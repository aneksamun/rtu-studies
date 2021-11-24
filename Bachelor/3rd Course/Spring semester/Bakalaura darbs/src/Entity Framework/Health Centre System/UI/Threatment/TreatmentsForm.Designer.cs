namespace HealthSystem.UI.Threatment {
    partial class TreatmentsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreatmentsForm));
            this.treatmentsGroupBox = new System.Windows.Forms.GroupBox();
            this.treatmentGroupBox = new System.Windows.Forms.GroupBox();
            this.treatmentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.healthGroupBox = new System.Windows.Forms.GroupBox();
            this.healthRichTextBox = new System.Windows.Forms.RichTextBox();
            this.recoveryDateLabel = new System.Windows.Forms.Label();
            this.diagnosisSetupLabel = new System.Windows.Forms.Label();
            this.diagnosisDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.diseasesComboBox = new System.Windows.Forms.ComboBox();
            this.patientsComboBox = new System.Windows.Forms.ComboBox();
            this.diseaseLabel = new System.Windows.Forms.Label();
            this.patientLabel = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fontToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.recoveryNullableDateTimePicker = new HealthSystem.UI.Components.NullableDateTimePicker();
            this.treatmentsGroupBox.SuspendLayout();
            this.treatmentGroupBox.SuspendLayout();
            this.healthGroupBox.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // treatmentsGroupBox
            // 
            this.treatmentsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treatmentsGroupBox.Controls.Add(this.treatmentGroupBox);
            this.treatmentsGroupBox.Controls.Add(this.healthGroupBox);
            this.treatmentsGroupBox.Controls.Add(this.recoveryDateLabel);
            this.treatmentsGroupBox.Controls.Add(this.diagnosisSetupLabel);
            this.treatmentsGroupBox.Controls.Add(this.recoveryNullableDateTimePicker);
            this.treatmentsGroupBox.Controls.Add(this.diagnosisDateTimePicker);
            this.treatmentsGroupBox.Controls.Add(this.diseasesComboBox);
            this.treatmentsGroupBox.Controls.Add(this.patientsComboBox);
            this.treatmentsGroupBox.Controls.Add(this.diseaseLabel);
            this.treatmentsGroupBox.Controls.Add(this.patientLabel);
            this.treatmentsGroupBox.Location = new System.Drawing.Point(13, 28);
            this.treatmentsGroupBox.Name = "treatmentsGroupBox";
            this.treatmentsGroupBox.Size = new System.Drawing.Size(451, 529);
            this.treatmentsGroupBox.TabIndex = 0;
            this.treatmentsGroupBox.TabStop = false;
            this.treatmentsGroupBox.Text = "Ārstēšanas informācija";
            // 
            // treatmentGroupBox
            // 
            this.treatmentGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treatmentGroupBox.Controls.Add(this.treatmentRichTextBox);
            this.treatmentGroupBox.Location = new System.Drawing.Point(14, 342);
            this.treatmentGroupBox.Name = "treatmentGroupBox";
            this.treatmentGroupBox.Size = new System.Drawing.Size(408, 167);
            this.treatmentGroupBox.TabIndex = 13;
            this.treatmentGroupBox.TabStop = false;
            this.treatmentGroupBox.Text = "Terapijas kurss";
            // 
            // treatmentRichTextBox
            // 
            this.treatmentRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treatmentRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treatmentRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treatmentRichTextBox.Location = new System.Drawing.Point(3, 16);
            this.treatmentRichTextBox.MaxLength = 420;
            this.treatmentRichTextBox.Name = "treatmentRichTextBox";
            this.treatmentRichTextBox.Size = new System.Drawing.Size(402, 148);
            this.treatmentRichTextBox.TabIndex = 9;
            this.treatmentRichTextBox.Text = "";
            // 
            // healthGroupBox
            // 
            this.healthGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.healthGroupBox.Controls.Add(this.healthRichTextBox);
            this.healthGroupBox.Location = new System.Drawing.Point(14, 169);
            this.healthGroupBox.Name = "healthGroupBox";
            this.healthGroupBox.Size = new System.Drawing.Size(408, 167);
            this.healthGroupBox.TabIndex = 12;
            this.healthGroupBox.TabStop = false;
            this.healthGroupBox.Text = "Veselības stāvoklis";
            // 
            // healthRichTextBox
            // 
            this.healthRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.healthRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.healthRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.healthRichTextBox.Location = new System.Drawing.Point(3, 16);
            this.healthRichTextBox.MaxLength = 420;
            this.healthRichTextBox.Name = "healthRichTextBox";
            this.healthRichTextBox.Size = new System.Drawing.Size(402, 148);
            this.healthRichTextBox.TabIndex = 9;
            this.healthRichTextBox.Text = "";
            // 
            // recoveryDateLabel
            // 
            this.recoveryDateLabel.AutoSize = true;
            this.recoveryDateLabel.Location = new System.Drawing.Point(11, 136);
            this.recoveryDateLabel.Name = "recoveryDateLabel";
            this.recoveryDateLabel.Size = new System.Drawing.Size(103, 13);
            this.recoveryDateLabel.TabIndex = 11;
            this.recoveryDateLabel.Text = "Atveseļošanas dat.: ";
            // 
            // diagnosisSetupLabel
            // 
            this.diagnosisSetupLabel.AutoSize = true;
            this.diagnosisSetupLabel.Location = new System.Drawing.Point(11, 111);
            this.diagnosisSetupLabel.Name = "diagnosisSetupLabel";
            this.diagnosisSetupLabel.Size = new System.Drawing.Size(93, 13);
            this.diagnosisSetupLabel.TabIndex = 10;
            this.diagnosisSetupLabel.Text = "Slim. uzstad. dat.: ";
            // 
            // diagnosisDateTimePicker
            // 
            this.diagnosisDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diagnosisDateTimePicker.Location = new System.Drawing.Point(115, 105);
            this.diagnosisDateTimePicker.Name = "diagnosisDateTimePicker";
            this.diagnosisDateTimePicker.Size = new System.Drawing.Size(307, 20);
            this.diagnosisDateTimePicker.TabIndex = 7;
            // 
            // diseasesComboBox
            // 
            this.diseasesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diseasesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diseasesComboBox.FormattingEnabled = true;
            this.diseasesComboBox.Location = new System.Drawing.Point(61, 77);
            this.diseasesComboBox.Name = "diseasesComboBox";
            this.diseasesComboBox.Size = new System.Drawing.Size(361, 21);
            this.diseasesComboBox.TabIndex = 3;
            // 
            // patientsComboBox
            // 
            this.patientsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.patientsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.patientsComboBox.FormattingEnabled = true;
            this.patientsComboBox.Location = new System.Drawing.Point(61, 50);
            this.patientsComboBox.Name = "patientsComboBox";
            this.patientsComboBox.Size = new System.Drawing.Size(361, 21);
            this.patientsComboBox.TabIndex = 2;
            // 
            // diseaseLabel
            // 
            this.diseaseLabel.AutoSize = true;
            this.diseaseLabel.Location = new System.Drawing.Point(11, 80);
            this.diseaseLabel.Name = "diseaseLabel";
            this.diseaseLabel.Size = new System.Drawing.Size(44, 13);
            this.diseaseLabel.TabIndex = 1;
            this.diseaseLabel.Text = "Slimība:";
            // 
            // patientLabel
            // 
            this.patientLabel.AutoSize = true;
            this.patientLabel.Location = new System.Drawing.Point(11, 53);
            this.patientLabel.Name = "patientLabel";
            this.patientLabel.Size = new System.Drawing.Size(51, 13);
            this.patientLabel.TabIndex = 0;
            this.patientLabel.Text = "Pacients:";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.fontToolStripButton,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(478, 25);
            this.toolStrip.TabIndex = 31;
            this.toolStrip.Text = "toolStrip";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "Attīrīt";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // fontToolStripButton
            // 
            this.fontToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("fontToolStripButton.Image")));
            this.fontToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontToolStripButton.Name = "fontToolStripButton";
            this.fontToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.fontToolStripButton.Text = "Fonta izvēle";
            this.fontToolStripButton.Click += new System.EventHandler(this.fontToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "Izgriezt";
            this.cutToolStripButton.Click += new System.EventHandler(this.cutToolStripButton_Click);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "Kopēt";
            this.copyToolStripButton.Click += new System.EventHandler(this.copyToolStripButton_Click);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "Ievietot";
            this.pasteToolStripButton.Click += new System.EventHandler(this.pasteToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(389, 592);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 32;
            this.saveButton.Text = "Saglabāt";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(308, 593);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 33;
            this.closeButton.Text = "Aizvērt";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(14, 566);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(450, 2);
            this.label8.TabIndex = 47;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // recoveryNullableDateTimePicker
            // 
            this.recoveryNullableDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.recoveryNullableDateTimePicker.Enabled = false;
            this.recoveryNullableDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.recoveryNullableDateTimePicker.Location = new System.Drawing.Point(115, 132);
            this.recoveryNullableDateTimePicker.Name = "recoveryNullableDateTimePicker";
            this.recoveryNullableDateTimePicker.NullValue = " Lūdzu izvēlēties datumu";
            this.recoveryNullableDateTimePicker.Size = new System.Drawing.Size(307, 20);
            this.recoveryNullableDateTimePicker.TabIndex = 8;
            this.recoveryNullableDateTimePicker.Value = new System.DateTime(2010, 5, 4, 17, 47, 9, 112);
            // 
            // TreatmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 628);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.treatmentsGroupBox);
            this.Name = "TreatmentsForm";
            this.Text = "Ārstēšana";
            this.Load += new System.EventHandler(this.TreatmentsForm_Load);
            this.treatmentsGroupBox.ResumeLayout(false);
            this.treatmentsGroupBox.PerformLayout();
            this.treatmentGroupBox.ResumeLayout(false);
            this.healthGroupBox.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox treatmentsGroupBox;
        private System.Windows.Forms.Label diseaseLabel;
        private System.Windows.Forms.Label patientLabel;
        private System.Windows.Forms.ComboBox diseasesComboBox;
        private System.Windows.Forms.ComboBox patientsComboBox;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton fontToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DateTimePicker diagnosisDateTimePicker;
        private HealthSystem.UI.Components.NullableDateTimePicker recoveryNullableDateTimePicker;
        private System.Windows.Forms.RichTextBox healthRichTextBox;
        private System.Windows.Forms.Label diagnosisSetupLabel;
        private System.Windows.Forms.Label recoveryDateLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox healthGroupBox;
        private System.Windows.Forms.GroupBox treatmentGroupBox;
        private System.Windows.Forms.RichTextBox treatmentRichTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}