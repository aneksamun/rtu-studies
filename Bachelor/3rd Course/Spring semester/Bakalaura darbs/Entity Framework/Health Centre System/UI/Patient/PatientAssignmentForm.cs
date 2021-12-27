using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HealthSystem.Business;

namespace HealthSystem.UI.Patient {
    
    public partial class PatientAssignmentForm : Form {

        bool isValid = true;
        const string NULLABLE_SPECIALIZATION = "Visu ārstu specializācijas";
        IList<Ārsts> doctors;

        public PatientAssignmentForm() {
            InitializeComponent();
        }

        private void PatientAssignmentForm_Load(object sender, EventArgs e) {
            BindPatientsComboBox();
            BindDoctorsComboBox();
            BindSpecialisationComboBox();

            specializationComboBox.SelectedValueChanged += new EventHandler(FilterComboxBoxValues);
            doctorComboBox.SelectedValueChanged += new EventHandler(HideMessage);
            patientComboBox.SelectedValueChanged += new EventHandler(HideMessage);

            InitGrid();
            LoadGrid();
        }

        private void FilterComboxBoxValues(object sender, EventArgs e) {
            if (specializationComboBox.SelectedValue.ToString() == NULLABLE_SPECIALIZATION)
                SetAllValues();
            else
                SetCustomValues();
        }

        private void assignButton_Click(object sender, EventArgs e) {
            if ((int)patientComboBox.SelectedValue == -1) {
                errorProvider.SetError(patientComboBox, "Norādiet pacientu");
                isValid = false;
                return;
            }

            if ((int)doctorComboBox.SelectedValue == -1) {
                errorProvider.SetError(doctorComboBox, "Norādiet ārstu");
                isValid = false;
                return;
            }

            if (ValidationMethods.IsAssociated(
                (int)patientComboBox.SelectedValue,
                (int)doctorComboBox.SelectedValue)) {

                errorProvider.SetError(assignButton, "Pacients ir jau norīkots esošam ārstam");
                isValid = false;
                return;
            }

            try {
                AddMethods.AddAssociation(
                    (int)patientComboBox.SelectedValue,
                    (int)doctorComboBox.SelectedValue);

                LoadGrid();
                ClearControls();

            } catch(Exception ex) {
                MessageBox.Show(
                    ex.Message, 
                    "Kļūda", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void HideMessage(object sender, EventArgs e) {
            if (!isValid) {
                this.errorProvider.Clear();
                isValid = true;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            if (this.assignmentDataGridView.Rows.Count == 0)
                return;

            if (this.assignmentDataGridView.SelectedRows.Count == 0)
                return;

            try {
                DeleteMethods.DeleteAssociation((int)assignmentDataGridView.SelectedRows[0].Cells["ĀrstaPacientaID"].Value);
            } catch (Exception ex) {
                MessageBox.Show(
                    ex.Message,
                    "Kļūda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            LoadGrid();
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void filterButton_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(patientLastnameTextBox.Text)) {
                LoadGrid();
                return;
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = GetMethods.GetAssociationByLastname(patientLastnameTextBox.Text);

            if (bs.Count > 0)
                assignmentDataGridView.DataSource = bs;
        }

        private void BindDoctorsComboBox() {
            doctors = GetMethods.GetDoctorsList();
            SetAllValues();
        }

        private void SetAllValues() {
            var query = from d in doctors
                        select new {
                            PersonID = d.PersonasID, 
                            Fullname = d.Vārds + " " + d.Uzvārds };

            query = query.ToList().Concat(new[] { new { PersonID = -1, Fullname = "Lūdzu izvēlēties ārstu" } });

            doctorComboBox.DataSource = query.ToArray();
            doctorComboBox.DisplayMember = "Fullname";
            doctorComboBox.ValueMember = "PersonID";
            doctorComboBox.SelectedValue = -1;
        }

        private void SetCustomValues() {
            var query = from d in doctors
                        where d.Specializācija == specializationComboBox.SelectedValue.ToString()
                        select new {
                            PersonID = d.PersonasID,
                            Fullname = d.Vārds + " " + d.Uzvārds
                        };

            query = query.ToList().Concat(new[] { new { PersonID = -1, Fullname = "Lūdzu izvēlēties ārstu" } });

            doctorComboBox.DataSource = query.ToArray();
            doctorComboBox.SelectedValue = -1;
        }

        private void BindPatientsComboBox() {
            patientComboBox.DataSource = GetMethods.GetPatients();
            patientComboBox.DisplayMember = "Fullname";
            patientComboBox.ValueMember = "PersonID";
            patientComboBox.SelectedValue = -1;
        }

        private void BindSpecialisationComboBox() {
            specializationComboBox.DataSource = GetMethods.GetDoctorsSpecializations(NULLABLE_SPECIALIZATION);
            specializationComboBox.DisplayMember = "Specializācija";
            specializationComboBox.SelectedItem = NULLABLE_SPECIALIZATION;
        }

        private void ClearControls() {
            specializationComboBox.SelectedItem = NULLABLE_SPECIALIZATION;
            patientComboBox.SelectedValue = -1;
            doctorComboBox.SelectedValue = -1;
        }

        private void InitGrid() {
            DataGridViewTextBoxColumn dgvColumn;

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "ĀrstaPacientaID";
            dgvColumn.HeaderText = "ĀrstaPacientaID";
            dgvColumn.DataPropertyName = "ĀrstaPacientaID";
            assignmentDataGridView.Columns.Add(dgvColumn);
            assignmentDataGridView.Columns["ĀrstaPacientaID"].Width = 0;
            assignmentDataGridView.Columns["ĀrstaPacientaID"].Visible = false;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "PatientFirstname";
            dgvColumn.HeaderText = "Pacienta vārds";
            dgvColumn.DataPropertyName = "PatientFirstname";
            assignmentDataGridView.Columns.Add(dgvColumn);
            assignmentDataGridView.Columns["PatientFirstname"].Width = 120;
            assignmentDataGridView.Columns["PatientFirstname"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "PatientLastname";
            dgvColumn.HeaderText = "Pacienta uzvārds";
            dgvColumn.DataPropertyName = "PatientLastname";
            assignmentDataGridView.Columns.Add(dgvColumn);
            assignmentDataGridView.Columns["PatientLastname"].Width = 120;
            assignmentDataGridView.Columns["PatientLastname"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "DoctorFirstname";
            dgvColumn.HeaderText = "Ārsta vārds";
            dgvColumn.DataPropertyName = "DoctorFirstname";
            assignmentDataGridView.Columns.Add(dgvColumn);
            assignmentDataGridView.Columns["DoctorFirstname"].Width = 120;
            assignmentDataGridView.Columns["DoctorFirstname"].Visible = true;
            dgvColumn.Dispose();

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "DoctorLastname";
            dgvColumn.HeaderText = "Ārsta uzvārds";
            dgvColumn.DataPropertyName = "DoctorLastname";
            assignmentDataGridView.Columns.Add(dgvColumn);
            assignmentDataGridView.Columns["DoctorLastname"].Width = 120;
            assignmentDataGridView.Columns["DoctorLastname"].Visible = true;
            dgvColumn.Dispose();
        }

        private void LoadGrid() {
            assignmentDataGridView.DataSource = GetMethods.GetAssociatedObjects();
        }
    }
}
