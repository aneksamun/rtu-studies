using System;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace HealthSystem.UI {

    public partial class AboutForm : Form {
        
        public AboutForm() {
            InitializeComponent();
        }

        public string AssemblyTitle {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

                if (attributes.Length > 0) {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];

                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }

                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion {
            get {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private void AboutForm_Load(object sender, EventArgs e) {
            aboutLabel.Text = AssemblyTitle;
            versionLabel.Text = AssemblyVersion;
        }

        private void pictureBox_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void AboutForm_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
