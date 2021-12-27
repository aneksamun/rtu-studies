using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HealthSystem.Business;

namespace HealthSystem.UI.Personal {
    
    public partial class registryStaffListForm : Form {

        public registryStaffListForm() {
            InitializeComponent();
        }

        private void registryStaffListForm_Load(object sender, EventArgs e) {
            InitializeGrid();
            LoadGrid();
        }

        private void InitializeGrid() {
            DataGridViewTextBoxColumn dgvColumn;

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "PersonasID";
            dgvColumn.HeaderText = "PersonasID";
            dgvColumn.DataPropertyName = "PersonasID";
            this.registryDataGridView.Columns.Add(dgvColumn);
            this.registryDataGridView.Columns["PersonasID"].Width = 0;
            this.registryDataGridView.Columns["PersonasID"].Visible = false;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Vārds";
            dgvColumn.HeaderText = "Vārds";
            dgvColumn.DataPropertyName = "Vārds";
            this.registryDataGridView.Columns.Add(dgvColumn);
            this.registryDataGridView.Columns["Vārds"].Width = 120;
            this.registryDataGridView.Columns["Vārds"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Uzvārds";
            dgvColumn.HeaderText = "Uzvārds";
            dgvColumn.DataPropertyName = "Uzvārds";
            registryDataGridView.Columns.Add(dgvColumn);
            registryDataGridView.Columns["Uzvārds"].Width = 120;
            registryDataGridView.Columns["Uzvārds"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Personas_kods";
            dgvColumn.HeaderText = "Personas kods";
            dgvColumn.DataPropertyName = "Personas_kods";
            registryDataGridView.Columns.Add(dgvColumn);
            registryDataGridView.Columns["Personas_kods"].Width = 100;
            registryDataGridView.Columns["Personas_kods"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Telefons";
            dgvColumn.HeaderText = "Telefons";
            dgvColumn.DataPropertyName = "Telefons";
            registryDataGridView.Columns.Add(dgvColumn);
            registryDataGridView.Columns["Telefons"].Width = 100;
            registryDataGridView.Columns["Telefons"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Adrese";
            dgvColumn.HeaderText = "Adrese";
            dgvColumn.DataPropertyName = "Adrese";
            registryDataGridView.Columns.Add(dgvColumn);
            registryDataGridView.Columns["Adrese"].Width = 120;
            registryDataGridView.Columns["Adrese"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Lietotājvārds";
            dgvColumn.HeaderText = "Lietotājvārds";
            dgvColumn.DataPropertyName = "Lietotājvārds";
            registryDataGridView.Columns.Add(dgvColumn);
            registryDataGridView.Columns["Lietotājvārds"].Width = 120;
            registryDataGridView.Columns["Lietotājvārds"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "Parole";
            dgvColumn.HeaderText = "Parole";
            dgvColumn.DataPropertyName = "Parole";
            registryDataGridView.Columns.Add(dgvColumn);
            registryDataGridView.Columns["Parole"].Width = 120;
            registryDataGridView.Columns["Parole"].Visible = true;
            dgvColumn.Dispose();
        }

        private void LoadGrid() {
            registryDataGridView.DataSource = GetMethods.GetRegistryStaffList();
            registryDataGridView.Columns["Attēls"].Visible = false;
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e) {
            LoadGrid();
        }

        private void filterToolStripButton_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(lastnameToolStripTextBox.Text))
                return;

            IList<Reģ_darb> registryStaff = GetMethods.GetRegistryStaffByLastname(lastnameToolStripTextBox.Text);

            if (registryStaff.Count > 0)
                registryDataGridView.DataSource = registryStaff;
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e) {
            if (this.registryDataGridView.Rows.Count == 0)
                return;

            if (this.registryDataGridView.SelectedRows.Count == 0)
                return;

            try {
                DeleteMethods.DeleteDeskClerk((int)registryDataGridView.SelectedRows[0].Cells["PersonasID"].Value);
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
            if (this.registryDataGridView.Rows.Count == 0)
                return;

            if (this.registryDataGridView.SelectedRows.Count == 0)
                return;

            EmployersForm employersForm = new EmployersForm(
                (int)registryDataGridView.SelectedRows[0].Cells["PersonasID"].Value, 2);

            employersForm.ShowDialog();
            LoadGrid();

            employersForm.Dispose();
        }

        private void registryDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            ModifyItem();
        }
    }
}
