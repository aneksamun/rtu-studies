using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HealthSystem.Business;

namespace HealthSystem.UI.Threatment {
    
    public partial class TreatmentsForm : Form {

        private bool isValid = true;
        private bool isLoaded = false;
        private Ārstēšana treatment;

        public TreatmentsForm() {
            InitializeComponent();

            BindPatientsComboBox();
            BindDiseasesComboBox();

            recoveryNullableDateTimePicker.Value = null;
        }

        public TreatmentsForm(int treatmentID) {
            int patientID, diseaseID;

            InitializeComponent();

            BindPatientsComboBox();
            BindDiseasesComboBox();

            treatment = GetMethods.GetTeatmentByID(treatmentID, out patientID, out diseaseID);
            patientsComboBox.SelectedValue = patientID;
            diseasesComboBox.SelectedValue = diseaseID;
            diagnosisDateTimePicker.Value = treatment.Diagnozes_datums;
            recoveryNullableDateTimePicker.Value = treatment.Atveselošanas_datums;
            healthRichTextBox.Text = treatment.Slimības_stāvoklis;
            treatmentRichTextBox.Text = treatment.Terapijas_kurss;

            recoveryNullableDateTimePicker.Enabled = true;
            patientsComboBox.Enabled = false;
            diseasesComboBox.Enabled = false;
            isLoaded = true;
        }

        private void TreatmentsForm_Load(object sender, EventArgs e) {
            patientsComboBox.SelectedValueChanged += new EventHandler(HideMessage);
            diseasesComboBox.SelectedValueChanged += new EventHandler(HideMessage);
            treatmentRichTextBox.TextChanged += new EventHandler(HideMessage);
            healthRichTextBox.TextChanged += new EventHandler(HideMessage);
        }

        private void BindDiseasesComboBox() {
            diseasesComboBox.DataSource = GetMethods.GetDiseases();
            diseasesComboBox.DisplayMember = "Diagnoze";
            diseasesComboBox.ValueMember = "SlimībasID";
            diseasesComboBox.SelectedValue = -1;
        }

        private void BindPatientsComboBox() {
            patientsComboBox.DataSource = GetMethods.GetDoctorPatients();
            patientsComboBox.DisplayMember = "Fullname";
            patientsComboBox.ValueMember = "PersonID";
            patientsComboBox.SelectedValue = -1;
        }

        private void HideMessage(object sender, EventArgs e) {
            if (!isValid) {
                this.errorProvider.Clear();
                isValid = true;
            }
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void newToolStripButton_Click(object sender, EventArgs e) {
            ClearControls();
        }

        private void ClearControls() {
            patientsComboBox.SelectedValue = -1;
            diseasesComboBox.SelectedValue = -1;
            healthRichTextBox.Text = String.Empty;
            treatmentRichTextBox.Text = String.Empty;
            diagnosisDateTimePicker.Value = DateTime.Now;
        }

        private void fontToolStripButton_Click(object sender, EventArgs e) {

            if (!treatmentRichTextBox.ContainsFocus &&
                !healthRichTextBox.ContainsFocus)
                return;

            FontDialog fontDialog = new FontDialog();

            RichTextBox richTextBox = (treatmentRichTextBox.ContainsFocus) ? treatmentRichTextBox : healthRichTextBox;

            fontDialog.Font = richTextBox.Font;

            if (fontDialog.ShowDialog() == DialogResult.OK)
                richTextBox.Font = fontDialog.Font;

            fontDialog.Dispose();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e) {

            if (!treatmentRichTextBox.ContainsFocus &&
                !healthRichTextBox.ContainsFocus)
                return;

            RichTextBox richTextBox = (treatmentRichTextBox.ContainsFocus) ? treatmentRichTextBox : healthRichTextBox;

            if (richTextBox.Text == String.Empty)
                return;

            if (richTextBox.SelectionLength == 0) {
                errorProvider.SetError(richTextBox.Parent, "Vispirms iezīmējiet tekstu");
                isValid = false;
            }

            richTextBox.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e) {

            if (!treatmentRichTextBox.ContainsFocus &&
                !healthRichTextBox.ContainsFocus)
                return;

            RichTextBox richTextBox = (treatmentRichTextBox.ContainsFocus) ? treatmentRichTextBox : healthRichTextBox;

            if (richTextBox.Text == String.Empty)
                return;

            if (richTextBox.SelectionLength == 0) {
                errorProvider.SetError(richTextBox.Parent, "Vispirms iezīmējiet tekstu");
                isValid = false;
            }

            richTextBox.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e) {
            
            if (!treatmentRichTextBox.ContainsFocus && 
                !healthRichTextBox.ContainsFocus)
                return;

            RichTextBox richTextBox = (treatmentRichTextBox.ContainsFocus) ? treatmentRichTextBox : healthRichTextBox;

            if (String.Concat(richTextBox.Text, Clipboard.GetText()).Length > 420) {
                errorProvider.SetError(richTextBox, "Ievietojāma teksta garums parsniedz atļauto");
                isValid = false;
            }

            richTextBox.Paste();
        }

        private void saveButton_Click(object sender, EventArgs e) {
            if ((int)patientsComboBox.SelectedValue == -1) {
                errorProvider.SetError(patientsComboBox, "Norādiet pacientu");
                isValid = false;
                return;
            }

            if ((int)diseasesComboBox.SelectedValue == -1) {
                errorProvider.SetError(diseasesComboBox, "Norādiet slimību");
                isValid = false;
                return;
            }

            if (healthRichTextBox.Text == String.Empty) {
                errorProvider.SetError(healthRichTextBox, "Raksturojiet pacienta veselības stāvokli");
                isValid = false;
                return;
            }

            if (treatmentRichTextBox.Text == String.Empty) {
                errorProvider.SetError(treatmentRichTextBox, "Raksturojiet ārstēšanas kursu");
                isValid = false;
                return;
            }

            if (!isLoaded) {
                treatment = new Ārstēšana();
                treatment.Terapijas_kurss = treatmentRichTextBox.Text;
                treatment.Diagnozes_datums = diagnosisDateTimePicker.Value;
                treatment.Slimības_stāvoklis = healthRichTextBox.Text;

                try {
                    AddMethods.AddTreatment(
                        treatment, 
                        (int)diseasesComboBox.SelectedValue, 
                        (int)patientsComboBox.SelectedValue);
                } catch (Exception ex) {
                    MessageBox.Show(
                        ex.Message,
                        "Kļūda",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                ClearControls();
            } else {
                treatment.Terapijas_kurss = treatmentRichTextBox.Text;
                treatment.Slimības_stāvoklis = healthRichTextBox.Text;
                treatment.Diagnozes_datums = diagnosisDateTimePicker.Value;
                treatment.Atveselošanas_datums = (DateTime?)recoveryNullableDateTimePicker.Value;

                try {
                    UpdateMethods.UpdateTreatment(treatment);
                } catch (Exception ex) {
                    MessageBox.Show(
                    ex.Message,
                    "Kļūda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

                this.Close();
            }
        }
    }
}
