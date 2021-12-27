using System;
using System.Drawing;
using System.Windows.Forms;

namespace HealthSystem.UI.Components {
    
    public partial class PictureForm : Form {
        public PictureForm() {
            InitializeComponent();
        }

        public PictureForm(string firstname, string lastname, Image img) {
            InitializeComponent();
            this.Text = string.Format("{0} {1}", firstname, lastname);
            pictureBox.Image = img;
        }

        private void PictureForm_Load(object sender, EventArgs e) {
            this.Size = new Size(pictureBox.Size.Width + 4, pictureBox.Size.Height + 24);
        }

        private void pictureBox_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
