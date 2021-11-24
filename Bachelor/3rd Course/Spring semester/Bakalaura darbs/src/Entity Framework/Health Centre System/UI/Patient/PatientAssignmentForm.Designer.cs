namespace HealthSystem.UI.Patient {
    partial class PatientAssignmentForm {
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
            this.patientComboBox = new System.Windows.Forms.ComboBox();
            this.specializationComboBox = new System.Windows.Forms.ComboBox();
            this.doctorComboBox = new System.Windows.Forms.ComboBox();
            this.patientLabel = new System.Windows.Forms.Label();
            this.doctorLabel = new System.Windows.Forms.Label();
            this.specializationLabel = new System.Windows.Forms.Label();
            this.assignButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.assignmentDataGridView = new System.Windows.Forms.DataGridView();
            this.assignmentGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.filterButton = new System.Windows.Forms.Button();
            this.patientLastnameTextBox = new System.Windows.Forms.TextBox();
            this.patientLastnameLabel = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assignmentDataGridView)).BeginInit();
            this.assignmentGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // patientComboBox
            // 
            this.patientComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.patientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.patientComboBox.FormattingEnabled = true;
            this.patientComboBox.Location = new System.Drawing.Point(99, 35);
            this.patientComboBox.Name = "patientComboBox";
            this.patientComboBox.Size = new System.Drawing.Size(362, 21);
            this.patientComboBox.TabIndex = 0;
            // 
            // specializationComboBox
            // 
            this.specializationComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.specializationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specializationComboBox.FormattingEnabled = true;
            this.specializationComboBox.Location = new System.Drawing.Point(100, 89);
            this.specializationComboBox.Name = "specializationComboBox";
            this.specializationComboBox.Size = new System.Drawing.Size(361, 21);
            this.specializationComboBox.TabIndex = 1;
            // 
            // doctorComboBox
            // 
            this.doctorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.doctorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doctorComboBox.FormattingEnabled = true;
            this.doctorComboBox.Location = new System.Drawing.Point(99, 62);
            this.doctorComboBox.Name = "doctorComboBox";
            this.doctorComboBox.Size = new System.Drawing.Size(362, 21);
            this.doctorComboBox.TabIndex = 2;
            // 
            // patientLabel
            // 
            this.patientLabel.AutoSize = true;
            this.patientLabel.Location = new System.Drawing.Point(42, 38);
            this.patientLabel.Name = "patientLabel";
            this.patientLabel.Size = new System.Drawing.Size(51, 13);
            this.patientLabel.TabIndex = 3;
            this.patientLabel.Text = "Pacients:";
            // 
            // doctorLabel
            // 
            this.doctorLabel.AutoSize = true;
            this.doctorLabel.Location = new System.Drawing.Point(60, 65);
            this.doctorLabel.Name = "doctorLabel";
            this.doctorLabel.Size = new System.Drawing.Size(33, 13);
            this.doctorLabel.TabIndex = 4;
            this.doctorLabel.Text = "Ārsts:";
            // 
            // specializationLabel
            // 
            this.specializationLabel.AutoSize = true;
            this.specializationLabel.Location = new System.Drawing.Point(20, 92);
            this.specializationLabel.Name = "specializationLabel";
            this.specializationLabel.Size = new System.Drawing.Size(74, 13);
            this.specializationLabel.TabIndex = 5;
            this.specializationLabel.Text = "Specializācija:";
            // 
            // assignButton
            // 
            this.assignButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.assignButton.Location = new System.Drawing.Point(386, 137);
            this.assignButton.Name = "assignButton";
            this.assignButton.Size = new System.Drawing.Size(75, 23);
            this.assignButton.TabIndex = 6;
            this.assignButton.Text = "&Norīkot";
            this.assignButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.assignButton.UseVisualStyleBackColor = true;
            this.assignButton.Click += new System.EventHandler(this.assignButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.assignmentDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(13, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 264);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Norīkojumu saraksts";
            // 
            // assignmentDataGridView
            // 
            this.assignmentDataGridView.AllowUserToAddRows = false;
            this.assignmentDataGridView.AllowUserToDeleteRows = false;
            this.assignmentDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.assignmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assignmentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assignmentDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.assignmentDataGridView.Location = new System.Drawing.Point(3, 16);
            this.assignmentDataGridView.MultiSelect = false;
            this.assignmentDataGridView.Name = "assignmentDataGridView";
            this.assignmentDataGridView.ReadOnly = true;
            this.assignmentDataGridView.RowHeadersVisible = false;
            this.assignmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.assignmentDataGridView.Size = new System.Drawing.Size(484, 245);
            this.assignmentDataGridView.TabIndex = 4;
            // 
            // assignmentGroupBox
            // 
            this.assignmentGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.assignmentGroupBox.Controls.Add(this.assignButton);
            this.assignmentGroupBox.Controls.Add(this.patientComboBox);
            this.assignmentGroupBox.Controls.Add(this.doctorComboBox);
            this.assignmentGroupBox.Controls.Add(this.specializationComboBox);
            this.assignmentGroupBox.Controls.Add(this.specializationLabel);
            this.assignmentGroupBox.Controls.Add(this.doctorLabel);
            this.assignmentGroupBox.Controls.Add(this.patientLabel);
            this.assignmentGroupBox.Location = new System.Drawing.Point(12, 12);
            this.assignmentGroupBox.Name = "assignmentGroupBox";
            this.assignmentGroupBox.Size = new System.Drawing.Size(490, 182);
            this.assignmentGroupBox.TabIndex = 8;
            this.assignmentGroupBox.TabStop = false;
            this.assignmentGroupBox.Text = "Pacienta norīkošana";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(13, 511);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(489, 2);
            this.label2.TabIndex = 27;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(407, 529);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 16;
            this.closeButton.Text = "Aizvērt";
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(407, 477);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 26;
            this.deleteButton.Text = "Dzēst";
            this.deleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // filterButton
            // 
            this.filterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.filterButton.Location = new System.Drawing.Point(326, 477);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 25;
            this.filterButton.Text = "Meklēt";
            this.filterButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // patientLastnameTextBox
            // 
            this.patientLastnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.patientLastnameTextBox.Location = new System.Drawing.Point(112, 479);
            this.patientLastnameTextBox.Name = "patientLastnameTextBox";
            this.patientLastnameTextBox.Size = new System.Drawing.Size(199, 20);
            this.patientLastnameTextBox.TabIndex = 24;
            this.toolTip.SetToolTip(this.patientLastnameTextBox, "Saraksta atjaunošanai izdzēsiet meklēšanas kritēriju un nospiediet \"Meklēt\"");
            // 
            // patientLastnameLabel
            // 
            this.patientLastnameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.patientLastnameLabel.AutoSize = true;
            this.patientLastnameLabel.Location = new System.Drawing.Point(13, 481);
            this.patientLastnameLabel.Name = "patientLastnameLabel";
            this.patientLastnameLabel.Size = new System.Drawing.Size(92, 13);
            this.patientLastnameLabel.TabIndex = 23;
            this.patientLastnameLabel.Text = "Pacienta uzvārds:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Saraksta atjaunošana";
            // 
            // PatientAssignmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 575);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.patientLastnameTextBox);
            this.Controls.Add(this.patientLastnameLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.assignmentGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "PatientAssignmentForm";
            this.Text = "Pacientu norīkojumi";
            this.Load += new System.EventHandler(this.PatientAssignmentForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.assignmentDataGridView)).EndInit();
            this.assignmentGroupBox.ResumeLayout(false);
            this.assignmentGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox patientComboBox;
        private System.Windows.Forms.ComboBox specializationComboBox;
        private System.Windows.Forms.ComboBox doctorComboBox;
        private System.Windows.Forms.Label patientLabel;
        private System.Windows.Forms.Label doctorLabel;
        private System.Windows.Forms.Label specializationLabel;
        private System.Windows.Forms.Button assignButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView assignmentDataGridView;
        private System.Windows.Forms.GroupBox assignmentGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.TextBox patientLastnameTextBox;
        private System.Windows.Forms.Label patientLastnameLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip;
    }
}