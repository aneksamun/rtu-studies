using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HealthSystem.Business;

namespace HealthSystem.UI.Personal {
    
    public partial class DoctorListForm : Form {

        public DoctorListForm() {
            InitializeComponent();
        }

        private void DoctorListForm_Load(object sender, EventArgs e) {
            InitializeGrid();
            LoadGrid();
        }

        private void InitializeGrid() {
            DataGridViewTextBoxColumn dgvColumn;
            
            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "PersonasID";
            dgvColumn.HeaderText = "PersonasID";
            dgvColumn.DataPropertyName = "PersonasID";
            this.docDataGridView.Columns.Add(dgvColumn);
            this.docDataGridView.Columns["PersonasID"].Width = 0;
            this.docDataGridView.Columns["PersonasID"].Visible = false;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Vārds";
            dgvColumn.HeaderText = "Vārds";
            dgvColumn.DataPropertyName = "Vārds";
            this.docDataGridView.Columns.Add(dgvColumn);
            this.docDataGridView.Columns["Vārds"].Width = 120;
            this.docDataGridView.Columns["Vārds"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Uzvārds";
            dgvColumn.HeaderText = "Uzvārds";
            dgvColumn.DataPropertyName = "Uzvārds";
            docDataGridView.Columns.Add(dgvColumn);
            docDataGridView.Columns["Uzvārds"].Width = 120;
            docDataGridView.Columns["Uzvārds"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Personas_kods";
            dgvColumn.HeaderText = "Personas kods";
            dgvColumn.DataPropertyName = "Personas_kods";
            docDataGridView.Columns.Add(dgvColumn);
            docDataGridView.Columns["Personas_kods"].Width = 100;
            docDataGridView.Columns["Personas_kods"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Telefons";
            dgvColumn.HeaderText = "Telefons";
            dgvColumn.DataPropertyName = "Telefons";
            docDataGridView.Columns.Add(dgvColumn);
            docDataGridView.Columns["Telefons"].Width = 100;
            docDataGridView.Columns["Telefons"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Adrese";
            dgvColumn.HeaderText = "Adrese";
            dgvColumn.DataPropertyName = "Adrese";
            docDataGridView.Columns.Add(dgvColumn);
            docDataGridView.Columns["Adrese"].Width = 120;
            docDataGridView.Columns["Adrese"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Lietotājvārds";
            dgvColumn.HeaderText = "Lietotājvārds";
            dgvColumn.DataPropertyName = "Lietotājvārds";
            docDataGridView.Columns.Add(dgvColumn);
            docDataGridView.Columns["Lietotājvārds"].Width = 120;
            docDataGridView.Columns["Lietotājvārds"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Parole";
            dgvColumn.HeaderText = "Parole";
            dgvColumn.DataPropertyName = "Parole";
            docDataGridView.Columns.Add(dgvColumn);
            docDataGridView.Columns["Parole"].Width = 120;
            docDataGridView.Columns["Parole"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Specializācija";
            dgvColumn.HeaderText = "Specializācija";
            dgvColumn.DataPropertyName = "Specializācija";
            docDataGridView.Columns.Add(dgvColumn);
            docDataGridView.Columns["Specializācija"].Width = 120;
            docDataGridView.Columns["Specializācija"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Kab_num";
            dgvColumn.HeaderText = "Kabin. nr.";
            dgvColumn.DataPropertyName = "Kabineta_numurs";
            docDataGridView.Columns.Add(dgvColumn);
            docDataGridView.Columns["Kab_num"].Width = 75;
            docDataGridView.Columns["Kab_num"].Visible = true;
            dgvColumn.Dispose();
        }

        private void LoadGrid() {
            docDataGridView.DataSource = GetMethods.GetDoctorsList();
            docDataGridView.Columns["Attēls"].Visible = false;
            docDataGridView.Columns["ĀrstsPacients"].Visible = false;
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e) {
            LoadGrid();
        }

        private void labotToolStripButton_Click(object sender, EventArgs e) {
            ModifyItem();
        }

        private void ModifyItem() {
            if (this.docDataGridView.Rows.Count == 0)
                return;

            if (this.docDataGridView.SelectedRows.Count == 0)
                return;

            EmployersForm employersForm = new EmployersForm(
                (int)docDataGridView.SelectedRows[0].Cells["PersonasID"].Value, 1);

            employersForm.ShowDialog();
            LoadGrid();

            employersForm.Dispose();
        }

        private void filterToolStripButton_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(lastnameToolStripTextBox.Text))
                return;

            IList<Ārsts> doctors = GetMethods.GetDoctorsByLastname(lastnameToolStripTextBox.Text);

            if (doctors.Count > 0)
                docDataGridView.DataSource = doctors;
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e) {
            if (this.docDataGridView.Rows.Count == 0)
                return;

            if (this.docDataGridView.SelectedRows.Count == 0)
                return;

            try {
                DeleteMethods.DeleteDoctor((int)docDataGridView.SelectedRows[0].Cells["PersonasID"].Value);
            } catch(Exception ex) {
                MessageBox.Show(
                    ex.Message,
                    "Kļūda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            LoadGrid();
        }

        private void docDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            ModifyItem();
        }
    }
}
