using System;
using System.Windows.Forms;
using HealthSystem.Business;

namespace HealthSystem.UI {
    
    public partial class LoginForm : Form {

        private bool isValid = true;

        public LoginForm() {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e) {
            this.passwordTextBox.TextChanged += new EventHandler(this.HideMessage);
            this.usernameTextBox.TextChanged += new EventHandler(this.HideMessage);
        }

        private void HideMessage(object sender, EventArgs e) {
            if (!isValid) {
                this.errorProvider.Clear();
                isValid = true;
            }
        }

        private void loginButton_Click(object sender, EventArgs e) {
            try {
                if (!ValidationMethods.IsValidPerson(usernameTextBox.Text, passwordTextBox.Text)) {
                    errorProvider.SetError(loginButton, "Lietotājvārds vai parole ir norādīta nepareizi");
                    isValid = false;
                    return;
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Kļūda", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }
    }
}
