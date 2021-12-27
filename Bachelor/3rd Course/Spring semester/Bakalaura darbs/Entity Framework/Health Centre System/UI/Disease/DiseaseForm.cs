using System;
using System.Windows.Forms;
using HealthSystem.Business;

namespace HealthSystem.UI.Disease {
    public partial class DiseaseForm : Form {

        private bool isValid = true;
        private bool isLoaded = false;
        private Slimība disease;

        public DiseaseForm() {
            InitializeComponent();
        }

        public DiseaseForm(int diseaseID) {
            InitializeComponent();

            disease = GetMethods.GetDiseaseByID(diseaseID);
            titleTextBox.Text = disease.Diagnoze;
            symptomsRichTxtBox.Text = disease.Simptomi;

            isLoaded = true;
        }

        private void DiseaseForm_Load(object sender, EventArgs e) {
            titleTextBox.TextChanged += new EventHandler(HideMessage);
            symptomsRichTxtBox.TextChanged += new EventHandler(HideMessage);
        }

        private void HideMessage(object sender, EventArgs e) {
            if (!isValid) {
                this.errorProvider.Clear();
                isValid = true;
            }
        }

        private void titleTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsLetter(e.KeyChar) &&
                e.KeyChar != (char)8 && 
                e.KeyChar != (char)32)
                e.Handled = true;
        }

        private void ClearControls() {
            titleTextBox.Text = String.Empty;
            symptomsRichTxtBox.Text = String.Empty;
        }

        private void newToolStripButton_Click(object sender, EventArgs e) {
            ClearControls();
        }

        private void fontToolStripButton_Click(object sender, EventArgs e) {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = symptomsRichTxtBox.Font;

            if (fontDialog.ShowDialog() == DialogResult.OK)
                symptomsRichTxtBox.Font = fontDialog.Font;

            fontDialog.Dispose();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e) {

            if (titleTextBox.ContainsFocus) {
                if (titleTextBox.Text == String.Empty)
                    return;

                if (titleTextBox.SelectionLength > 0) {
                    titleTextBox.Cut();
                } else {
                    errorProvider.SetError(titleTextBox, "Vispirms iezīmējiet tekstu, kuru vēlēties izgriezt");
                    isValid = false;
                    return;
                }
            }

            if (symptomsRichTxtBox.ContainsFocus) {
                if (symptomsRichTxtBox.Text == String.Empty)
                    return;

                if (symptomsRichTxtBox.SelectionLength > 0) {
                    symptomsRichTxtBox.Cut();
                } else {
                    errorProvider.SetError(symptomsGroupBox, "Vispirms iezīmējiet tekstu, kuru vēlēties izgriezt");
                    isValid = false;
                    return;
                }
            }
        }

        private void copyToolStripButton_Click(object sender, EventArgs e) {

            if (titleTextBox.ContainsFocus) {
                if (titleTextBox.Text == String.Empty)
                    return;

                if (titleTextBox.SelectionLength > 0) {
                    titleTextBox.Copy();
                } else {
                    errorProvider.SetError(titleTextBox, "Vispirms iezīmējiet tekstu, kuru vēlēties kopēt");
                    isValid = false;
                    return;
                }
            }

            if (symptomsRichTxtBox.ContainsFocus) {
                if (symptomsRichTxtBox.Text == String.Empty)
                    return;

                if (symptomsRichTxtBox.SelectionLength > 0) {
                    symptomsRichTxtBox.Copy();
                } else {
                    errorProvider.SetError(symptomsGroupBox, "Vispirms iezīmējiet tekstu, kuru vēlēties kopēt");
                    isValid = false;
                    return;
                }
            }
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e) {

            if (titleTextBox.ContainsFocus) {
                if ((titleTextBox.Text + Clipboard.GetText()).Length > 25) {
                    errorProvider.SetError(titleTextBox, "Ievietojāma teksta garums parsniedz atļauto");
                    isValid = false;
                    return;
                }

                titleTextBox.Paste();
            }

            if (symptomsRichTxtBox.ContainsFocus) {
                if ((symptomsRichTxtBox.Text + Clipboard.GetText()).Length > 250) {
                    errorProvider.SetError(symptomsGroupBox, "Ievietojāma teksta garums parsniedz atļauto");
                    isValid = false;
                    return;
                }

                symptomsRichTxtBox.Paste();
            }
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e) {

            if (symptomsRichTxtBox.Text == String.Empty) {
                errorProvider.SetError(symptomsGroupBox, "Simptomi nav noradīti");
                isValid = false;
                return;
            }

            if (titleTextBox.Text == String.Empty) {
                errorProvider.SetError(titleTextBox, "Slimības nosaukums nav noradīts");
                isValid = false;
                return;
            }

            if (!isLoaded) {
                disease = new Slimība();
                disease.Diagnoze = titleTextBox.Text;
                disease.Simptomi = symptomsRichTxtBox.Text;

                try {
                    AddMethods.AddDisease(disease);
                } catch (Exception ex) {
                    MessageBox.Show(
                        ex.Message,
                        "Kļūda",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                ClearControls();

            } else {
                disease.Diagnoze = titleTextBox.Text;
                disease.Simptomi = symptomsRichTxtBox.Text;

                try {
                    UpdateMethods.UpdateDisease(disease);
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