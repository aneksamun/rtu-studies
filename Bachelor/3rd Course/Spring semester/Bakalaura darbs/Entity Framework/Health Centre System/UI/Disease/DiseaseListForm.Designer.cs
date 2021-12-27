namespace HealthSystem.UI.Disease {
    partial class DiseaseListForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiseaseListForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnEditIllness = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnDeleteIllness = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnRefreshGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.diagnosisToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.diseaseDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diseaseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnEditIllness,
            this.toolStripBtnDeleteIllness,
            this.toolStripBtnRefreshGrid,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.diagnosisToolStripTextBox,
            this.toolStripBtnSearch,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(955, 34);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnEditIllness
            // 
            this.toolStripBtnEditIllness.AutoSize = false;
            this.toolStripBtnEditIllness.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripBtnEditIllness.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnEditIllness.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnEditIllness.Image")));
            this.toolStripBtnEditIllness.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnEditIllness.Name = "toolStripBtnEditIllness";
            this.toolStripBtnEditIllness.Size = new System.Drawing.Size(33, 31);
            this.toolStripBtnEditIllness.Text = "Labot slimības datus";
            this.toolStripBtnEditIllness.Click += new System.EventHandler(this.toolStripBtnEditIllness_Click);
            // 
            // toolStripBtnDeleteIllness
            // 
            this.toolStripBtnDeleteIllness.AutoSize = false;
            this.toolStripBtnDeleteIllness.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnDeleteIllness.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnDeleteIllness.Image")));
            this.toolStripBtnDeleteIllness.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDeleteIllness.Name = "toolStripBtnDeleteIllness";
            this.toolStripBtnDeleteIllness.Size = new System.Drawing.Size(33, 31);
            this.toolStripBtnDeleteIllness.Text = "Dzēst slimību";
            this.toolStripBtnDeleteIllness.Click += new System.EventHandler(this.toolStripBtnDeleteIllness_Click);
            // 
            // toolStripBtnRefreshGrid
            // 
            this.toolStripBtnRefreshGrid.AutoSize = false;
            this.toolStripBtnRefreshGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnRefreshGrid.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnRefreshGrid.Image")));
            this.toolStripBtnRefreshGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnRefreshGrid.Name = "toolStripBtnRefreshGrid";
            this.toolStripBtnRefreshGrid.Size = new System.Drawing.Size(33, 31);
            this.toolStripBtnRefreshGrid.Text = "Atjaunot sarakstu";
            this.toolStripBtnRefreshGrid.Click += new System.EventHandler(this.toolStripBtnRefreshGrid_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(73, 31);
            this.toolStripLabel1.Text = "Nosaukums:";
            // 
            // diagnosisToolStripTextBox
            // 
            this.diagnosisToolStripTextBox.Name = "diagnosisToolStripTextBox";
            this.diagnosisToolStripTextBox.Size = new System.Drawing.Size(121, 34);
            // 
            // toolStripBtnSearch
            // 
            this.toolStripBtnSearch.AutoSize = false;
            this.toolStripBtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSearch.Image")));
            this.toolStripBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSearch.Name = "toolStripBtnSearch";
            this.toolStripBtnSearch.Size = new System.Drawing.Size(33, 31);
            this.toolStripBtnSearch.Text = "Atlasīt";
            this.toolStripBtnSearch.Click += new System.EventHandler(this.toolStripBtnSearch_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // diseaseDataGridView
            // 
            this.diseaseDataGridView.AllowUserToAddRows = false;
            this.diseaseDataGridView.AllowUserToDeleteRows = false;
            this.diseaseDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.diseaseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.diseaseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diseaseDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.diseaseDataGridView.Location = new System.Drawing.Point(0, 34);
            this.diseaseDataGridView.MultiSelect = false;
            this.diseaseDataGridView.Name = "diseaseDataGridView";
            this.diseaseDataGridView.ReadOnly = true;
            this.diseaseDataGridView.RowHeadersVisible = false;
            this.diseaseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.diseaseDataGridView.Size = new System.Drawing.Size(955, 462);
            this.diseaseDataGridView.TabIndex = 3;
            this.diseaseDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.diseaseDataGridView_CellDoubleClick);
            // 
            // DiseaseListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 496);
            this.Controls.Add(this.diseaseDataGridView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DiseaseListForm";
            this.Text = "Slimību saraksts";
            this.Load += new System.EventHandler(this.DiseaseListForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diseaseDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnEditIllness;
        private System.Windows.Forms.ToolStripButton toolStripBtnDeleteIllness;
        private System.Windows.Forms.ToolStripButton toolStripBtnRefreshGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox diagnosisToolStripTextBox;
        private System.Windows.Forms.ToolStripButton toolStripBtnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridView diseaseDataGridView;
    }
}