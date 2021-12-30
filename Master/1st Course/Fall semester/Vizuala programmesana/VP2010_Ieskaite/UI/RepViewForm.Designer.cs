namespace CourseSystem.UI {
    partial class RepViewForm {
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ParticipantBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DbDataSet = new CourseSystem.UI.DbDataSet();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ParticipantTableAdapter = new CourseSystem.UI.DbDataSetTableAdapters.ParticipantTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ParticipantBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ParticipantBindingSource
            // 
            this.ParticipantBindingSource.DataMember = "Participant";
            this.ParticipantBindingSource.DataSource = this.DbDataSet;
            // 
            // DbDataSet
            // 
            this.DbDataSet.DataSetName = "DbDataSet";
            this.DbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DbDataSet_Participant";
            reportDataSource1.Value = this.ParticipantBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "CourseSystem.UI.CoursePartRep.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(484, 462);
            this.reportViewer.TabIndex = 0;
            // 
            // ParticipantTableAdapter
            // 
            this.ParticipantTableAdapter.ClearBeforeFill = true;
            // 
            // RepViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.reportViewer);
            this.Name = "RepViewForm";
            this.Text = "Parskats par kursiem reģistrētājām personām";
            this.Load += new System.EventHandler(this.RepViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ParticipantBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DbDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource ParticipantBindingSource;
        private DbDataSet DbDataSet;
        private CourseSystem.UI.DbDataSetTableAdapters.ParticipantTableAdapter ParticipantTableAdapter;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer;




    }
}