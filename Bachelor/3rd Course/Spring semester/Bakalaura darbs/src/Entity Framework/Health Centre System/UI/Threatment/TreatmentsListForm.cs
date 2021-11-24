using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HealthSystem.Business;
using HealthSystem.Common;

namespace HealthSystem.UI.Threatment {

    public partial class TreatmentsListForm : Form {

        public TreatmentsListForm() {
            InitializeComponent();
        }

        private void TreatmentsListForm_Load(object sender, EventArgs e) {
            if (GlobalMembers.GlobalPersonType == (int)Classifiers.PersonType.Pacients) {
                labotToolStripButton.Enabled = false;
                deleteToolStripButton.Enabled = false;
            }
            InitializeGrid();
            LoadGrid();
        }

        private void InitializeGrid() {
            DataGridViewTextBoxColumn dgvColumn;

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "ĀrstēšanasID";
            dgvColumn.HeaderText = "ĀrstēšanasID";
            dgvColumn.DataPropertyName = "ĀrstēšanasID";
            this.treatmentsDataGridView.Columns.Add(dgvColumn);
            this.treatmentsDataGridView.Columns["ĀrstēšanasID"].Width = 0;
            this.treatmentsDataGridView.Columns["ĀrstēšanasID"].Visible = false;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "PatientFirstname";
            dgvColumn.HeaderText = "Pacienta vārds";
            dgvColumn.DataPropertyName = "PatientFirstname";
            this.treatmentsDataGridView.Columns.Add(dgvColumn);
            this.treatmentsDataGridView.Columns["PatientFirstname"].Width = 120;
            this.treatmentsDataGridView.Columns["PatientFirstname"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "PatientLastname";
            dgvColumn.HeaderText = "Pacienta uzvārds";
            dgvColumn.DataPropertyName = "PatientLastname";
            treatmentsDataGridView.Columns.Add(dgvColumn);
            treatmentsDataGridView.Columns["PatientLastname"].Width = 120;
            treatmentsDataGridView.Columns["PatientLastname"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "DoctorFirstname";
            dgvColumn.HeaderText = "Ārsta vārds";
            dgvColumn.DataPropertyName = "DoctorFirstname";
            this.treatmentsDataGridView.Columns.Add(dgvColumn);
            this.treatmentsDataGridView.Columns["DoctorFirstname"].Width = 120;
            this.treatmentsDataGridView.Columns["DoctorFirstname"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "DoctorLastname";
            dgvColumn.HeaderText = "Ārsta uzvārds";
            dgvColumn.DataPropertyName = "DoctorLastname";
            treatmentsDataGridView.Columns.Add(dgvColumn);
            treatmentsDataGridView.Columns["DoctorLastname"].Width = 120;
            treatmentsDataGridView.Columns["DoctorLastname"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Diagnoze";
            dgvColumn.HeaderText = "Slimība";
            dgvColumn.DataPropertyName = "Diagnoze";
            treatmentsDataGridView.Columns.Add(dgvColumn);
            treatmentsDataGridView.Columns["Diagnoze"].Width = 120;
            treatmentsDataGridView.Columns["Diagnoze"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Diagnozes_datums";
            dgvColumn.HeaderText = "Slim. uzstad. dat.";
            dgvColumn.DataPropertyName = "Diagnozes_datums";
            treatmentsDataGridView.Columns.Add(dgvColumn);
            treatmentsDataGridView.Columns["Diagnozes_datums"].Width = 140;
            treatmentsDataGridView.Columns["Diagnozes_datums"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Atveselošanas_datums";
            dgvColumn.HeaderText = "Atveseļ. dat.";
            dgvColumn.DataPropertyName = "Atveselošanas_datums";
            treatmentsDataGridView.Columns.Add(dgvColumn);
            treatmentsDataGridView.Columns["Atveselošanas_datums"].Width = 140;
            treatmentsDataGridView.Columns["Atveselošanas_datums"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Slimības_stāvoklis";
            dgvColumn.HeaderText = "Veselības stāvoklis";
            dgvColumn.DataPropertyName = "Slimības_stāvoklis";
            treatmentsDataGridView.Columns.Add(dgvColumn);
            treatmentsDataGridView.Columns["Slimības_stāvoklis"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            treatmentsDataGridView.Columns["Slimības_stāvoklis"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Terapijas_kurss";
            dgvColumn.HeaderText = "Terapijas kurss";
            dgvColumn.DataPropertyName = "Terapijas_kurss";
            treatmentsDataGridView.Columns.Add(dgvColumn);
            treatmentsDataGridView.Columns["Terapijas_kurss"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            treatmentsDataGridView.Columns["Terapijas_kurss"].Visible = true;
            dgvColumn.Dispose();
        }

        private void LoadGrid() {
            switch (GlobalMembers.GlobalPersonType) {
                case (int)Classifiers.PersonType.Ārsts:
                    treatmentsDataGridView.DataSource = GetMethods.GetDoctorTreatmentsList();
                    treatmentsDataGridView.Columns["DoctorFirstname"].Visible = false;
                    treatmentsDataGridView.Columns["DoctorLastname"].Visible = false;
                    break;
                case (int)Classifiers.PersonType.Pacients:
                    treatmentsDataGridView.DataSource = GetMethods.GetPatientTreatmentsList();
                    treatmentsDataGridView.Columns["PatientFirstname"].Visible = false;
                    treatmentsDataGridView.Columns["PatientLastname"].Visible = false;
                    break;
            }
        }

        private void labotToolStripButton_Click(object sender, EventArgs e) {
            ModifyItem();
        }

        private void ModifyItem() {
            if (this.treatmentsDataGridView.Rows.Count == 0)
                return;

            if (this.treatmentsDataGridView.SelectedRows.Count == 0)
                return;

            TreatmentsForm treatmentsForm = new TreatmentsForm(
                (int)treatmentsDataGridView.SelectedRows[0].Cells["ĀrstēšanasID"].Value);

            treatmentsForm.ShowDialog();
            LoadGrid();

            treatmentsForm.Dispose();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e) {
            if (this.treatmentsDataGridView.Rows.Count == 0)
                return;

            if (this.treatmentsDataGridView.SelectedRows.Count == 0)
                return;

            try {
                DeleteMethods.DeleteTreatment((int)treatmentsDataGridView.SelectedRows[0].Cells["ĀrstēšanasID"].Value);
            } catch (Exception ex) {
                MessageBox.Show(
                    ex.Message,
                    "Kļūda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            LoadGrid();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e) {
            LoadGrid();
        }

        private void filterToolStripButton_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(lastnameToolStripTextBox.Text) &&
                String.IsNullOrEmpty(diseaseToolStripTextBox.Text))
                return;

            BindingSource bs = new BindingSource();

            switch (GlobalMembers.GlobalPersonType) {
                case (int)Classifiers.PersonType.Ārsts:
                    bs.DataSource = GetMethods.GetDoctorTreatmentsByCriteria(lastnameToolStripTextBox.Text, diseaseToolStripTextBox.Text);
                    break;
                case (int)Classifiers.PersonType.Pacients:
                    bs.DataSource = GetMethods.GetPatientTreatmentsByCriteria(lastnameToolStripTextBox.Text, diseaseToolStripTextBox.Text);
                    break;
            }

            if (bs.Count > 0)
                treatmentsDataGridView.DataSource = bs;
        }

        private void treatmentsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            ModifyItem();
        }
    }
}
