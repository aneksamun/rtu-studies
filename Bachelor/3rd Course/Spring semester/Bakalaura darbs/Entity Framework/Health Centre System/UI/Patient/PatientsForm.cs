using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using HealthSystem.Common;
using HealthSystem.Business;
using HealthSystem.UI.Personal;
using HealthSystem.UI.Components;

namespace HealthSystem.UI.Patient {
    
    public partial class PatientsForm : Form {

        private bool isChangedPicture = false;
        private bool isValid = true;
        private bool isLoaded = false;
        private string _username;
        private Pacients patient;

        public PatientsForm() {
            InitializeComponent();
        }

        public PatientsForm(int patientID) {
            InitializeComponent();

            patient = GetMethods.GetPatientByID(patientID);
            firstnameTextBox.Text = patient.Vārds;
            lastnameTextBox.Text = patient.Uzvārds;
            personCodeTxtBox.Text = patient.Personas_kods;
            telephoneTxtBox.Text = patient.Telefons.ToString();
            addressTextBox.Text = patient.Adrese;
            usernameTextBox.Text = _username = patient.Lietotājvārds;
            psswdTextBox.Text = retypedPsswdTxtBox.Text = patient.Parole;
            bloodGroupNUD.Value = (decimal)patient.Asins_grupa;

            if (patient.Attēls != null)
                pictureBox.Image = CommonMethods.LoadImage(patient.Attēls);

            isLoaded = true;
        }

        private void PatientsForm_Load(object sender, EventArgs e) {
            this.firstnameTextBox.KeyPress += new KeyPressEventHandler(this.CheckCharacter);
            this.lastnameTextBox.KeyPress += new KeyPressEventHandler(this.CheckCharacter);
            this.personCodeTxtBox.KeyPress += new KeyPressEventHandler(this.CheckCharacter);
            this.telephoneTxtBox.KeyPress += new KeyPressEventHandler(this.CheckCharacter);
            this.addressTextBox.KeyPress += new KeyPressEventHandler(this.CheckCharacter);

            this.firstnameTextBox.TextChanged += new EventHandler(this.HideMessage);
            this.lastnameTextBox.TextChanged += new EventHandler(this.HideMessage);
            this.personCodeTxtBox.TextChanged += new EventHandler(this.HideMessage);
            this.telephoneTxtBox.TextChanged += new EventHandler(this.HideMessage);
            this.usernameTextBox.TextChanged += new EventHandler(this.HideMessage);
            this.addressTextBox.TextChanged += new EventHandler(this.HideMessage);
            this.psswdTextBox.TextChanged += new EventHandler(this.HideMessage);
            this.retypedPsswdTxtBox.TextChanged += new EventHandler(this.HideMessage);
            this.bloodGroupNUD.ValueChanged += new EventHandler(this.HideMessage);
        }

        private void CheckCharacter(object sender, KeyPressEventArgs e) {
            TextBox textBox = (TextBox)sender;

            switch (textBox.Name) {
                case "firstnameTextBox":
                case "lastnameTextBox":
                    if (!char.IsLetter(e.KeyChar) &&
                        e.KeyChar != (char)8)
                        e.Handled = true;
                    break;

                case "personCodeTxtBox":

                    switch (textBox.Text.Length) {
                        case 0:
                            if (!char.IsDigit(e.KeyChar) &&
                                e.KeyChar != (char)8 ||
                                e.KeyChar != (char)8 &&
                                int.Parse(e.KeyChar.ToString()) > 3)
                                e.Handled = true;
                            break;
                        case 1:
                            if (!char.IsDigit(e.KeyChar) &&
                                e.KeyChar != (char)8 ||
                                e.KeyChar != (char)8 &&
                                int.Parse(textBox.Text + e.KeyChar.ToString()) < 1 ||
                                e.KeyChar != (char)8 &&
                                int.Parse(textBox.Text + e.KeyChar.ToString()) > 31)
                                e.Handled = true;
                            break;
                        case 2:
                            if (!char.IsDigit(e.KeyChar) &&
                                e.KeyChar != (char)8 ||
                                e.KeyChar != (char)8 &&
                                int.Parse(e.KeyChar.ToString()) > 1)
                                e.Handled = true;
                            break;
                        case 3:
                            if (!char.IsDigit(e.KeyChar) &&
                                e.KeyChar != (char)8 ||
                                e.KeyChar != (char)8 &&
                                int.Parse(textBox.Text[2] + e.KeyChar.ToString()) < 1 ||
                                e.KeyChar != (char)8 &&
                                !CommonMethods.IsCorrectDate(
                                Byte.Parse(textBox.Text[0].ToString() + textBox.Text[1].ToString()),
                                Byte.Parse(textBox.Text[2].ToString() + e.KeyChar.ToString())))
                                e.Handled = true;
                            break;
                        case 4:
                        case 5:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            if (!char.IsDigit(e.KeyChar) &&
                                e.KeyChar != (char)8)
                                e.Handled = true;
                            break;
                        case 6:
                            if (e.KeyChar != '-' &&
                                e.KeyChar != (char)8)
                                e.Handled = true;
                            break;
                    }

                    break;
                case "telephoneTxtBox":
                    if (!char.IsDigit(e.KeyChar) &&
                        e.KeyChar != (char)8)
                        e.Handled = true;
                    break;
                case "addressTextBox":
                    if (!char.IsLetterOrDigit(e.KeyChar) &&
                        e.KeyChar != (char)8 &&
                        e.KeyChar != (char)32 &&
                        e.KeyChar != ',' &&
                        e.KeyChar != '.')
                        e.Handled = true;
                    break;
            }
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

        private void saveButton_Click(object sender, EventArgs e) {
            if (firstnameTextBox.Text == String.Empty) {
                errorProvider.SetError(firstnameTextBox, "Vārds nav norādīts");
                isValid = false;
                return;
            }

            if (lastnameTextBox.Text == String.Empty) {
                errorProvider.SetError(lastnameTextBox, "Uzvārds nav norādīts");
                isValid = false;
                return;
            }

            if (personCodeTxtBox.Text == String.Empty ||
                personCodeTxtBox.Text.Length < 12) {
                errorProvider.SetError(personCodeTxtBox, "Personas kods ir nekorekts");
                isValid = false;
                return;
            }

            if (telephoneTxtBox.Text == String.Empty ||
                telephoneTxtBox.Text.Length < 8) {
                errorProvider.SetError(telephoneTxtBox, "Numurs ir nekorekts");
                isValid = false;
                return;
            } else if (telephoneTxtBox.Text[0] != '2') {
                errorProvider.SetError(telephoneTxtBox, "Numuram ir jāsākas ar 2");
                isValid = false;
                return;
            }

            if (addressTextBox.Text == String.Empty) {
                errorProvider.SetError(addressTextBox, "Adrese nav noradīta");
                isValid = false;
                return;
            }

            if (usernameTextBox.Text == String.Empty) {
                errorProvider.SetError(usernameTextBox, "Lietotājvārds nav noradīts");
                isValid = false;
                return;
            } else if (!isLoaded || (isLoaded && _username != usernameTextBox.Text))
                if (ValidationMethods.UsernameExists(usernameTextBox.Text)) {
                    errorProvider.SetError(usernameTextBox, "Lietotājvārds ir aizņēmts");
                    isValid = false;
                    return;
                }

            if (psswdTextBox.Text == String.Empty) {
                errorProvider.SetError(psswdTextBox, "Parole nav noradīta");
                isValid = false;
                return;
            } else {
                if (psswdTextBox.Text != retypedPsswdTxtBox.Text) {
                    errorProvider.SetError(psswdTextBox, "Ievadītas paroles nesakrīt");
                    isValid = false;
                    return;
                }
            }

            if (bloodGroupNUD.Value == 0) {
                errorProvider.SetError(bloodGroupNUD, "Noradiet asins grupu");
                isValid = false;
                return;
            }


            if (!isLoaded) {
                patient = new Pacients();

                patient.Vārds = firstnameTextBox.Text;
                patient.Uzvārds = lastnameTextBox.Text;
                patient.Personas_kods = personCodeTxtBox.Text;
                patient.Telefons = int.Parse(telephoneTxtBox.Text);
                patient.Adrese = addressTextBox.Text;
                patient.Lietotājvārds = usernameTextBox.Text;
                patient.Parole = psswdTextBox.Text;
                patient.Asins_grupa = (byte)bloodGroupNUD.Value;
                patient.Attēls = isChangedPicture ? CommonMethods.PreparePhoto(pictureBox.Image) : null;

                try {
                    //AddMethods.AddPatient(patient);
                    AddMethods.AddPerson<Pacients>(patient);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message,
                        "Kļūda",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                ClearControls();

            } else {
                patient.Vārds = firstnameTextBox.Text;
                patient.Uzvārds = lastnameTextBox.Text;
                patient.Personas_kods = personCodeTxtBox.Text;
                patient.Telefons = int.Parse(telephoneTxtBox.Text);
                patient.Adrese = addressTextBox.Text;
                patient.Lietotājvārds = usernameTextBox.Text;
                patient.Parole = psswdTextBox.Text;
                patient.Asins_grupa = (byte)bloodGroupNUD.Value;

                if (isChangedPicture)
                    patient.Attēls = CommonMethods.PreparePhoto(pictureBox.Image);

                try {
                    UpdateMethods.UpdatePerson<Pacients>(patient);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message,
                        "Kļūda",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                this.Close();
            }
        }

        private void ClearControls() {
            foreach (Control control in patientGroupBox.Controls) {
                if (control is TextBox)
                    control.Text = String.Empty;
            }

            bloodGroupNUD.Value = 0;
            ComponentResourceManager resources = new ComponentResourceManager((typeof(EmployersForm)));
            pictureBox.Image = ((Image)(resources.GetObject("pictureBox.Image")));
        }

        private void browseButton_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Attēla izvēle";
            openFileDialog.Filter = "Attēlu formāts (*.jpg; *.jpeg)|*.jpg;  *.jpeg";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                Image img = Image.FromFile(openFileDialog.FileName);

                if (img.Width > 500 || img.Height > 500)
                    pictureBox.Image = CommonMethods.ResizeImage(img);
                else
                    pictureBox.Image = img;

                isChangedPicture = true;
            }

            openFileDialog.Dispose();
        }

        private void pictureBox_Click(object sender, EventArgs e) {
            PictureForm pictureForm = new PictureForm(
                firstnameTextBox.Text,
                lastnameTextBox.Text,
                pictureBox.Image);

            pictureForm.ShowDialog();

            pictureForm.Dispose();
        }
    }
}
