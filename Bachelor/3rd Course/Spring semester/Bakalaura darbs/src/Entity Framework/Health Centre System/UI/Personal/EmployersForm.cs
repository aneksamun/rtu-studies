using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using HealthSystem.Common;
using HealthSystem.Business;
using HealthSystem.UI.Components;

namespace HealthSystem.UI.Personal {
    
    public partial class EmployersForm : Form {

        private bool isValid = true;
        private bool isChangedPicture = false;
        private bool isLoaded = false;
        private string _username;
        private Ārsts doctor;
        private Persona person;

        public EmployersForm() {
            InitializeComponent();
        }

        public EmployersForm(int personID, byte type) {
            InitializeComponent();

            switch (type) {
                case (int)Classifiers.PersonType.Administrators:
                    person = GetMethods.GetAdminByID(personID);
                    firstnameTextBox.Text = person.Vārds;
                    lastnameTextBox.Text = person.Uzvārds;
                    personCodeTxtBox.Text = person.Personas_kods;
                    telephoneTxtBox.Text = person.Telefons.ToString();
                    addressTextBox.Text = person.Adrese;
                    usernameTextBox.Text = _username = person.Lietotājvārds;
                    psswdTextBox.Text = retypedPsswdTxtBox.Text = person.Parole;
                    adminRBtn.Checked = true;
                    deskClerkRBtn.Enabled = false;
                    doctorRBtn.Enabled = false;

                    if (person.Attēls != null)
                        pictureBox.Image = CommonMethods.LoadImage(person.Attēls);

                    break;
                case (int)Classifiers.PersonType.Ārsts:
                    doctor = GetMethods.GetDoctorByID(personID);
                    firstnameTextBox.Text = doctor.Vārds;
                    lastnameTextBox.Text = doctor.Uzvārds;
                    personCodeTxtBox.Text = doctor.Personas_kods;
                    telephoneTxtBox.Text = doctor.Telefons.ToString();
                    addressTextBox.Text = doctor.Adrese;
                    usernameTextBox.Text = _username = doctor.Lietotājvārds;
                    psswdTextBox.Text = retypedPsswdTxtBox.Text = doctor.Parole;
                    specializationTextBox.Text = doctor.Specializācija;
                    cabNUD.Value = (decimal)doctor.Kabineta_numurs;
                    doctorRBtn.Checked = true;
                    adminRBtn.Enabled = false;
                    deskClerkRBtn.Enabled = false;

                    if (doctor.Attēls != null)
                        pictureBox.Image = CommonMethods.LoadImage(doctor.Attēls);

                    break;

                case (int)Classifiers.PersonType.Reģ_darb:
                    person = GetMethods.GetDeskClerkByID(personID);
                    firstnameTextBox.Text = person.Vārds;
                    lastnameTextBox.Text = person.Uzvārds;
                    personCodeTxtBox.Text = person.Personas_kods;
                    telephoneTxtBox.Text = person.Telefons.ToString();
                    addressTextBox.Text = person.Adrese;
                    usernameTextBox.Text = _username = person.Lietotājvārds;
                    psswdTextBox.Text = retypedPsswdTxtBox.Text = person.Parole;
                    deskClerkRBtn.Checked = true;
                    doctorRBtn.Enabled = false;
                    adminRBtn.Enabled = false;

                    if (person.Attēls != null)
                        pictureBox.Image = CommonMethods.LoadImage(person.Attēls);

                    break;
            }

            isLoaded = true;
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

        private void EmployersForm_Load(object sender, EventArgs e) {
            this.firstnameTextBox.KeyPress += new KeyPressEventHandler(this.CheckCharacter);
            this.lastnameTextBox.KeyPress += new KeyPressEventHandler(this.CheckCharacter);
            this.personCodeTxtBox.KeyPress += new KeyPressEventHandler(this.CheckCharacter);
            this.telephoneTxtBox.KeyPress += new KeyPressEventHandler(this.CheckCharacter);
            this.addressTextBox.KeyPress += new KeyPressEventHandler(this.CheckCharacter);
            this.specializationTextBox.KeyPress += new KeyPressEventHandler(this.CheckCharacter);

            this.firstnameTextBox.TextChanged += new EventHandler(this.HideMessage);
            this.lastnameTextBox.TextChanged += new EventHandler(this.HideMessage);
            this.personCodeTxtBox.TextChanged += new EventHandler(this.HideMessage);
            this.telephoneTxtBox.TextChanged += new EventHandler(this.HideMessage);
            this.addressTextBox.TextChanged += new EventHandler(this.HideMessage);
            this.usernameTextBox.TextChanged += new EventHandler(this.HideMessage);
            this.psswdTextBox.TextChanged += new EventHandler(this.HideMessage);
            this.retypedPsswdTxtBox.TextChanged += new EventHandler(this.HideMessage);
            this.specializationTextBox.TextChanged += new EventHandler(this.HideMessage);
            this.cabNUD.ValueChanged += new EventHandler(this.HideMessage);
        }

        private void CheckCharacter(object sender, KeyPressEventArgs e) {
            TextBox textBox = (TextBox)sender;

            switch (textBox.Name) {
                case "firstnameTextBox":
                case "lastnameTextBox":
                case "specializationTextBox":
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

            if (doctorRBtn.Checked) {
                if (specializationTextBox.Text == String.Empty) {
                    tabControl.SelectedTab = postTabPage;
                    errorProvider.SetError(specializationTextBox, "Ārstam nav norādīta speciālizācija");
                    isValid = false;
                    return;
                }

                if (cabNUD.Value == 0) {
                    tabControl.SelectedTab = postTabPage;
                    errorProvider.SetError(cabNUD, "Kabineta numurs nav norādīts");
                    isValid = false;
                    return;
                }

                if (!isLoaded) {
                    doctor = new Ārsts();

                    doctor.Vārds = firstnameTextBox.Text;
                    doctor.Uzvārds = lastnameTextBox.Text;
                    doctor.Personas_kods = personCodeTxtBox.Text;
                    doctor.Telefons = int.Parse(telephoneTxtBox.Text);
                    doctor.Adrese = addressTextBox.Text;
                    doctor.Lietotājvārds = usernameTextBox.Text;
                    doctor.Parole = psswdTextBox.Text;
                    doctor.Specializācija = specializationTextBox.Text;
                    doctor.Kabineta_numurs = (short)cabNUD.Value;
                    doctor.Attēls = isChangedPicture ? CommonMethods.PreparePhoto(pictureBox.Image) : null;

                    try {
                        AddMethods.AddPerson<Ārsts>(doctor);
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message,
                            "Kļūda",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    ClearControls();

                } else {
                    doctor.Vārds = firstnameTextBox.Text;
                    doctor.Uzvārds = lastnameTextBox.Text;
                    doctor.Personas_kods = personCodeTxtBox.Text;
                    doctor.Telefons = int.Parse(telephoneTxtBox.Text);
                    doctor.Adrese = addressTextBox.Text;
                    doctor.Lietotājvārds = usernameTextBox.Text;
                    doctor.Parole = psswdTextBox.Text;
                    doctor.Specializācija = specializationTextBox.Text;
                    doctor.Kabineta_numurs = (short)cabNUD.Value;

                    if (isChangedPicture)
                        doctor.Attēls = CommonMethods.PreparePhoto(pictureBox.Image);

                    try {
                        UpdateMethods.UpdatePerson<Ārsts>(doctor);
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message,
                            "Kļūda",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    this.Close();
                }
            }

            if (adminRBtn.Checked) {
                if (!isLoaded) {
                    //Administrators.CreateAdministrators(1, ....);
                    person = new Administrators();
                    person.Vārds = firstnameTextBox.Text;
                    person.Uzvārds = lastnameTextBox.Text;
                    person.Personas_kods = personCodeTxtBox.Text;
                    person.Telefons = int.Parse(telephoneTxtBox.Text);
                    person.Adrese = addressTextBox.Text;
                    person.Lietotājvārds = usernameTextBox.Text;
                    person.Parole = psswdTextBox.Text;
                    person.Attēls = isChangedPicture ? CommonMethods.PreparePhoto(pictureBox.Image) : null;

                    try {
                        AddMethods.AddPerson<Administrators>((Administrators)person);
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message,
                            "Kļūda",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    ClearControls();

                } else {
                    person.Vārds = firstnameTextBox.Text;
                    person.Uzvārds = lastnameTextBox.Text;
                    person.Personas_kods = personCodeTxtBox.Text;
                    person.Telefons = int.Parse(telephoneTxtBox.Text);
                    person.Adrese = addressTextBox.Text;
                    person.Lietotājvārds = usernameTextBox.Text;
                    person.Parole = psswdTextBox.Text;

                    if (isChangedPicture)
                        person.Attēls = CommonMethods.PreparePhoto(pictureBox.Image);

                    try {
                        UpdateMethods.UpdatePerson<Administrators>((Administrators)person);
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message,
                            "Kļūda",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    this.Close();
                }
            }

            if (deskClerkRBtn.Checked) {
                if (!isLoaded) {
                    person = new Reģ_darb();
                    person.Vārds = firstnameTextBox.Text;
                    person.Uzvārds = lastnameTextBox.Text;
                    person.Personas_kods = personCodeTxtBox.Text;
                    person.Telefons = int.Parse(telephoneTxtBox.Text);
                    person.Adrese = addressTextBox.Text;
                    person.Lietotājvārds = usernameTextBox.Text;
                    person.Parole = psswdTextBox.Text;
                    person.Attēls = isChangedPicture ? CommonMethods.PreparePhoto(pictureBox.Image) : null;

                    try {
                        AddMethods.AddPerson<Reģ_darb>((Reģ_darb)person);
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message,
                            "Kļūda",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    ClearControls();
                } else {
                    person.Vārds = firstnameTextBox.Text;
                    person.Uzvārds = lastnameTextBox.Text;
                    person.Personas_kods = personCodeTxtBox.Text;
                    person.Telefons = int.Parse(telephoneTxtBox.Text);
                    person.Adrese = addressTextBox.Text;
                    person.Lietotājvārds = usernameTextBox.Text;
                    person.Parole = psswdTextBox.Text;

                    if (isChangedPicture)
                        person.Attēls = CommonMethods.PreparePhoto(pictureBox.Image);

                    try {
                        UpdateMethods.UpdatePerson<Reģ_darb>((Reģ_darb)person);
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message,
                            "Kļūda",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    this.Close();
                }
            }
        }

        private void pictureBox_Click(object sender, EventArgs e) {
            PictureForm pictureForm = new PictureForm(
                firstnameTextBox.Text,
                lastnameTextBox.Text,
                pictureBox.Image);

            pictureForm.ShowDialog();

            pictureForm.Dispose();
        }

        private void doctorRBtn_CheckedChanged(object sender, EventArgs e) {
            if (doctorRBtn.Checked) {
                specializationTextBox.Enabled = true;
                cabNUD.Enabled = true;
            } else {
                specializationTextBox.Enabled = false;
                cabNUD.Enabled = false;
            }
        }

        private void ClearControls() {
            foreach (Control control in personGroupBox.Controls) {
                if (control is TextBox)
                    control.Text = String.Empty;

                if (control is TabControl)
                    foreach (TabPage tabPage in tabControl.TabPages)
                        foreach (Control ctrl in tabPage.Controls)
                            if (ctrl is TextBox)
                                ctrl.Text = String.Empty;
            }

            cabNUD.Value = 0;
            doctorRBtn.Checked = true;

            ComponentResourceManager resources = new ComponentResourceManager((typeof(EmployersForm)));
            pictureBox.Image = ((Image)(resources.GetObject("pictureBox.Image")));
        }
    }
}
