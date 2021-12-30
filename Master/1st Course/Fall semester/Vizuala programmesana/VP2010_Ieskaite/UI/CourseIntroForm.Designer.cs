namespace CourseSystem.UI {
    partial class CourseIntroForm {
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
            this.gbCourseInfo = new System.Windows.Forms.GroupBox();
            this.txtMaxParticipants = new System.Windows.Forms.TextBox();
            this.lblMaxParticipants = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtChairman = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblChairman = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.courseGroupBox = new System.Windows.Forms.GroupBox();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.lstCourses = new System.Windows.Forms.ListBox();
            this.gbCourseInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.courseGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCourseInfo
            // 
            this.gbCourseInfo.Controls.Add(this.txtMaxParticipants);
            this.gbCourseInfo.Controls.Add(this.lblMaxParticipants);
            this.gbCourseInfo.Controls.Add(this.lblEndTime);
            this.gbCourseInfo.Controls.Add(this.btnSave);
            this.gbCourseInfo.Controls.Add(this.lblStartTime);
            this.gbCourseInfo.Controls.Add(this.dtpStartTime);
            this.gbCourseInfo.Controls.Add(this.dtpEndTime);
            this.gbCourseInfo.Controls.Add(this.lblTitle);
            this.gbCourseInfo.Controls.Add(this.lblLocation);
            this.gbCourseInfo.Controls.Add(this.txtLocation);
            this.gbCourseInfo.Controls.Add(this.txtChairman);
            this.gbCourseInfo.Controls.Add(this.txtTitle);
            this.gbCourseInfo.Controls.Add(this.lblChairman);
            this.gbCourseInfo.Location = new System.Drawing.Point(12, 12);
            this.gbCourseInfo.Name = "gbCourseInfo";
            this.gbCourseInfo.Size = new System.Drawing.Size(413, 239);
            this.gbCourseInfo.TabIndex = 0;
            this.gbCourseInfo.TabStop = false;
            this.gbCourseInfo.Text = "Informācija par kursu";
            // 
            // txtMaxParticipants
            // 
            this.txtMaxParticipants.Location = new System.Drawing.Point(152, 169);
            this.txtMaxParticipants.MaxLength = 5;
            this.txtMaxParticipants.Name = "txtMaxParticipants";
            this.txtMaxParticipants.Size = new System.Drawing.Size(78, 20);
            this.txtMaxParticipants.TabIndex = 21;
            this.txtMaxParticipants.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxParticipants_KeyPress);
            this.txtMaxParticipants.Validating += new System.ComponentModel.CancelEventHandler(this.tbValue_Validating);
            // 
            // lblMaxParticipants
            // 
            this.lblMaxParticipants.AutoSize = true;
            this.lblMaxParticipants.Location = new System.Drawing.Point(34, 171);
            this.lblMaxParticipants.Name = "lblMaxParticipants";
            this.lblMaxParticipants.Size = new System.Drawing.Size(112, 13);
            this.lblMaxParticipants.TabIndex = 23;
            this.lblMaxParticipants.Text = "Max dalībnieku skaits:";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(110, 139);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(30, 13);
            this.lblEndTime.TabIndex = 22;
            this.lblEndTime.Text = "Līdz:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(328, 208);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 25);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "&Saglabāt";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(28, 113);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(114, 13);
            this.lblStartTime.TabIndex = 21;
            this.lblStartTime.Text = "Kursa norises laiks No:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(152, 109);
            this.dtpStartTime.MaxDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpStartTime.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(213, 20);
            this.dtpStartTime.TabIndex = 7;
            this.dtpStartTime.Value = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtpStartTime.Validating += new System.ComponentModel.CancelEventHandler(this.dtpStartTime_Validating);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(152, 135);
            this.dtpEndTime.MaxDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpEndTime.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(213, 20);
            this.dtpEndTime.TabIndex = 2;
            this.dtpEndTime.Validating += new System.ComponentModel.CancelEventHandler(this.dtpEndTime_Validating);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(46, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(94, 13);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Kursa nosaukums:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(41, 86);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(99, 13);
            this.lblLocation.TabIndex = 16;
            this.lblLocation.Text = "Kursa norises vieta:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(152, 83);
            this.txtLocation.MaxLength = 50;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(212, 20);
            this.txtLocation.TabIndex = 18;
            this.txtLocation.Validating += new System.ComponentModel.CancelEventHandler(this.tbValue_Validating);
            // 
            // txtChairman
            // 
            this.txtChairman.Location = new System.Drawing.Point(152, 57);
            this.txtChairman.MaxLength = 50;
            this.txtChairman.Name = "txtChairman";
            this.txtChairman.Size = new System.Drawing.Size(213, 20);
            this.txtChairman.TabIndex = 19;
            this.txtChairman.Validating += new System.ComponentModel.CancelEventHandler(this.tbValue_Validating);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(152, 31);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(213, 20);
            this.txtTitle.TabIndex = 17;
            this.txtTitle.Validating += new System.ComponentModel.CancelEventHandler(this.tbValue_Validating);
            // 
            // lblChairman
            // 
            this.lblChairman.AutoSize = true;
            this.lblChairman.Location = new System.Drawing.Point(63, 60);
            this.lblChairman.Name = "lblChairman";
            this.lblChairman.Size = new System.Drawing.Size(77, 13);
            this.lblChairman.TabIndex = 15;
            this.lblChairman.Text = "Kursa vadītājs:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // courseGroupBox
            // 
            this.courseGroupBox.Controls.Add(this.btnGenerateReport);
            this.courseGroupBox.Controls.Add(this.lstCourses);
            this.courseGroupBox.Location = new System.Drawing.Point(431, 12);
            this.courseGroupBox.Name = "courseGroupBox";
            this.courseGroupBox.Size = new System.Drawing.Size(200, 239);
            this.courseGroupBox.TabIndex = 1;
            this.courseGroupBox.TabStop = false;
            this.courseGroupBox.Text = "Kursu saraksts";
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(107, 210);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(87, 23);
            this.btnGenerateReport.TabIndex = 21;
            this.btnGenerateReport.Text = "&Viedot atskaiti";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // lstCourses
            // 
            this.lstCourses.FormattingEnabled = true;
            this.lstCourses.Location = new System.Drawing.Point(19, 31);
            this.lstCourses.Name = "lstCourses";
            this.lstCourses.Size = new System.Drawing.Size(158, 160);
            this.lstCourses.TabIndex = 0;
            // 
            // CourseIntroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 273);
            this.Controls.Add(this.courseGroupBox);
            this.Controls.Add(this.gbCourseInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CourseIntroForm";
            this.Text = "Kursa informācijas ievade";
            this.Load += new System.EventHandler(this.CourseIntroForm_Load);
            this.gbCourseInfo.ResumeLayout(false);
            this.gbCourseInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.courseGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCourseInfo;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.TextBox txtChairman;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblChairman;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.TextBox txtMaxParticipants;
        private System.Windows.Forms.Label lblMaxParticipants;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox courseGroupBox;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.ListBox lstCourses;

    }
}