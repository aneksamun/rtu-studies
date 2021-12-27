using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HealthSystem.Business;

namespace HealthSystem.UI.Disease {
    
    public partial class DiseaseListForm : Form {

        public DiseaseListForm() {
            InitializeComponent();
        }

        private void DiseaseListForm_Load(object sender, EventArgs e) {
            InitGrid();
            LoadGrid();
        }

        private void InitGrid() {
            DataGridViewTextBoxColumn dgvColumn;

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "SlimībasID";
            dgvColumn.HeaderText = "SlimībasID";
            dgvColumn.DataPropertyName = "SlimībasID";
            diseaseDataGridView.Columns.Add(dgvColumn);
            diseaseDataGridView.Columns["SlimībasID"].Width = 0;
            diseaseDataGridView.Columns["SlimībasID"].Visible = false;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Diagnoze";
            dgvColumn.HeaderText = "Diagnoze";
            dgvColumn.DataPropertyName = "Diagnoze";
            diseaseDataGridView.Columns.Add(dgvColumn);
            diseaseDataGridView.Columns["Diagnoze"].Width = 120;
            diseaseDataGridView.Columns["Diagnoze"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Simptomi";
            dgvColumn.HeaderText = "Simptomi";
            dgvColumn.DataPropertyName = "Simptomi";
            diseaseDataGridView.Columns.Add(dgvColumn);
            diseaseDataGridView.Columns["Simptomi"].Width = 1090;
            diseaseDataGridView.Columns["Simptomi"].Visible = true;
            dgvColumn.Dispose();
        }

        private void LoadGrid() {
            diseaseDataGridView.DataSource = GetMethods.GetDeasesList();
            diseaseDataGridView.Columns["Ārstēšana"].Visible = false;
        }

        private void toolStripBtnRefreshGrid_Click(object sender, EventArgs e) {
            LoadGrid();
        }

        private void toolStripBtnSearch_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(diagnosisToolStripTextBox.Text))
                return;

            IList<Slimība> diseases = GetMethods.GetDiseaseByTitle(diagnosisToolStripTextBox.Text);

            if (diseases.Count > 0)
                diseaseDataGridView.DataSource = diseases;
        }

        private void toolStripBtnEditIllness_Click(object sender, EventArgs e) {
            ModifyItem();
        }

        private void diseaseDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            ModifyItem();
        }

        private void ModifyItem() {
            if (this.diseaseDataGridView.Rows.Count == 0)
                return;

            if (this.diseaseDataGridView.SelectedRows.Count == 0)
                return;

            DiseaseForm diseaseForm = new DiseaseForm(
                (int)diseaseDataGridView.SelectedRows[0].Cells["SlimībasID"].Value);

            diseaseForm.ShowDialog();
            LoadGrid();

            diseaseForm.Dispose();
        }

        private void toolStripBtnDeleteIllness_Click(object sender, EventArgs e) {
            if (this.diseaseDataGridView.Rows.Count == 0)
                return;

            if (this.diseaseDataGridView.SelectedRows.Count == 0)
                return;

            try {
                DeleteMethods.DeleteDisease((int)diseaseDataGridView.SelectedRows[0].Cells["SlimībasID"].Value);
            } catch (Exception ex) {
                MessageBox.Show(
                    ex.Message,
                    "Kļūda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            LoadGrid();
        }
    }
}
