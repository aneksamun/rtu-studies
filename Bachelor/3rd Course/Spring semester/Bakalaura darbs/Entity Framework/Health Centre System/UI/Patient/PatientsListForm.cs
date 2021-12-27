using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HealthSystem.Business;

namespace HealthSystem.UI.Patient {
    
    public partial class PatientsListForm : Form {

        public PatientsListForm() {
            InitializeComponent();
        }

        private void PatientList_Load(object sender, EventArgs e) {
            InitializeGrid();
            LoadGrid();
        }

        private void InitializeGrid() {
            DataGridViewTextBoxColumn dgvColumn;

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "PersonasID";
            dgvColumn.HeaderText = "PersonasID";
            dgvColumn.DataPropertyName = "PersonasID";
            this.patientsDataGridView.Columns.Add(dgvColumn);
            this.patientsDataGridView.Columns["PersonasID"].Width = 0;
            this.patientsDataGridView.Columns["PersonasID"].Visible = false;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Vārds";
            dgvColumn.HeaderText = "Vārds";
            dgvColumn.DataPropertyName = "Vārds";
            this.patientsDataGridView.Columns.Add(dgvColumn);
            this.patientsDataGridView.Columns["Vārds"].Width = 120;
            this.patientsDataGridView.Columns["Vārds"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Uzvārds";
            dgvColumn.HeaderText = "Uzvārds";
            dgvColumn.DataPropertyName = "Uzvārds";
            patientsDataGridView.Columns.Add(dgvColumn);
            patientsDataGridView.Columns["Uzvārds"].Width = 120;
            patientsDataGridView.Columns["Uzvārds"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Personas_kods";
            dgvColumn.HeaderText = "Personas kods";
            dgvColumn.DataPropertyName = "Personas_kods";
            patientsDataGridView.Columns.Add(dgvColumn);
            patientsDataGridView.Columns["Personas_kods"].Width = 100;
            patientsDataGridView.Columns["Personas_kods"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Telefons";
            dgvColumn.HeaderText = "Telefons";
            dgvColumn.DataPropertyName = "Telefons";
            patientsDataGridView.Columns.Add(dgvColumn);
            patientsDataGridView.Columns["Telefons"].Width = 100;
            patientsDataGridView.Columns["Telefons"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Adrese";
            dgvColumn.HeaderText = "Adrese";
            dgvColumn.DataPropertyName = "Adrese";
            patientsDataGridView.Columns.Add(dgvColumn);
            patientsDataGridView.Columns["Adrese"].Width = 120;
            patientsDataGridView.Columns["Adrese"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Lietotājvārds";
            dgvColumn.HeaderText = "Lietotājvārds";
            dgvColumn.DataPropertyName = "Lietotājvārds";
            patientsDataGridView.Columns.Add(dgvColumn);
            patientsDataGridView.Columns["Lietotājvārds"].Width = 120;
            patientsDataGridView.Columns["Lietotājvārds"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Parole";
            dgvColumn.HeaderText = "Parole";
            dgvColumn.DataPropertyName = "Parole";
            patientsDataGridView.Columns.Add(dgvColumn);
            patientsDataGridView.Columns["Parole"].Width = 120;
            patientsDataGridView.Columns["Parole"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Asins_grupa";
            dgvColumn.HeaderText = "Asins grupa";
            dgvColumn.DataPropertyName = "Asins_grupa";
            patientsDataGridView.Columns.Add(dgvColumn);
            patientsDataGridView.Columns["Asins_grupa"].Width = 85;
            patientsDataGridView.Columns["Asins_grupa"].Visible = true;
            dgvColumn.Dispose();
        }

        private void LoadGrid() {
            patientsDataGridView.DataSource = GetMethods.GetPatientsList();
            patientsDataGridView.Columns["Attēls"].Visible = false;
            patientsDataGridView.Columns["ĀrstsPacients"].Visible = false;
        }

        private void patientDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            ModifyItem();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e) {
            LoadGrid();
        }

        private void filterToolStripButton_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(lastnameToolStripTextBox.Text))
                return;

            IList<Pacients> patients = GetMethods.GetPatientsByLastname(lastnameToolStripTextBox.Text);

            if (patients.Count > 0)
                patientsDataGridView.DataSource = patients;
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e) {
            if (this.patientsDataGridView.Rows.Count == 0)
                return;

            if (this.patientsDataGridView.SelectedRows.Count == 0)
                return;

            try {
                DeleteMethods.DeletePatient((int)patientsDataGridView.SelectedRows[0].Cells["PersonasID"].Value);
            } catch (Exception ex) {
                MessageBox.Show(
                    ex.Message,
                    "Kļūda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            LoadGrid();
        }

        private void labotToolStripButton_Click(object sender, EventArgs e) {
            ModifyItem();
        }

        private void ModifyItem() {
            if (this.patientsDataGridView.Rows.Count == 0)
                return;

            if (this.patientsDataGridView.SelectedRows.Count == 0)
                return;

            PatientsForm patientsForm = new PatientsForm(
                (int)patientsDataGridView.SelectedRows[0].Cells["PersonasID"].Value);

            patientsForm.ShowDialog();
            LoadGrid();

            patientsForm.Dispose();
        }
    }
}
