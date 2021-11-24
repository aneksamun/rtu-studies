namespace HealthSystem.UI.Personal {
    partial class DoctorListForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorListForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.labotToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lastnameLabel = new System.Windows.Forms.ToolStripLabel();
            this.lastnameToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.filterToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.docDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labotToolStripButton,
            this.deleteToolStripButton,
            this.refreshToolStripButton,
            this.toolStripSeparator1,
            this.lastnameLabel,
            this.lastnameToolStripTextBox,
            this.filterToolStripButton,
            this.toolStripSeparator2});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(999, 34);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // labotToolStripButton
            // 
            this.labotToolStripButton.AutoSize = false;
            this.labotToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.labotToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("labotToolStripButton.Image")));
            this.labotToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.labotToolStripButton.Name = "labotToolStripButton";
            this.labotToolStripButton.Size = new System.Drawing.Size(33, 31);
            this.labotToolStripButton.Text = "Labot darbinieku";
            this.labotToolStripButton.Click += new System.EventHandler(this.labotToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.AutoSize = false;
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton.Image")));
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(33, 31);
            this.deleteToolStripButton.Text = "Dzēst darbinieku";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.AutoSize = false;
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripButton.Image")));
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(33, 31);
            this.refreshToolStripButton.Text = "Atjaunot sarakstu";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // lastnameLabel
            // 
            this.lastnameLabel.Name = "lastnameLabel";
            this.lastnameLabel.Size = new System.Drawing.Size(51, 31);
            this.lastnameLabel.Text = "Uzvārds:";
            // 
            // lastnameToolStripTextBox
            // 
            this.lastnameToolStripTextBox.Name = "lastnameToolStripTextBox";
            this.lastnameToolStripTextBox.Size = new System.Drawing.Size(121, 34);
            // 
            // filterToolStripButton
            // 
            this.filterToolStripButton.AutoSize = false;
            this.filterToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.filterToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("filterToolStripButton.Image")));
            this.filterToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filterToolStripButton.Name = "filterToolStripButton";
            this.filterToolStripButton.Size = new System.Drawing.Size(33, 31);
            this.filterToolStripButton.Text = "Atlasīt";
            this.filterToolStripButton.Click += new System.EventHandler(this.filterToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // docDataGridView
            // 
            this.docDataGridView.AllowUserToAddRows = false;
            this.docDataGridView.AllowUserToDeleteRows = false;
            this.docDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.docDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.docDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.docDataGridView.Location = new System.Drawing.Point(0, 34);
            this.docDataGridView.MultiSelect = false;
            this.docDataGridView.Name = "docDataGridView";
            this.docDataGridView.ReadOnly = true;
            this.docDataGridView.RowHeadersVisible = false;
            this.docDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.docDataGridView.Size = new System.Drawing.Size(999, 462);
            this.docDataGridView.TabIndex = 1;
            this.docDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.docDataGridView_CellDoubleClick);
            // 
            // DoctorListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 496);
            this.Controls.Add(this.docDataGridView);
            this.Controls.Add(this.toolStrip);
            this.Name = "DoctorListForm";
            this.Text = "Ārstu saraksts";
            this.Load += new System.EventHandler(this.DoctorListForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton labotToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox lastnameToolStripTextBox;
        private System.Windows.Forms.ToolStripButton filterToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lastnameLabel;
        private System.Windows.Forms.DataGridView docDataGridView;
    }
}