using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NougthAndCroses.UI
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            Type objType = typeof(UserControl);
            label1.Text += " " + objType.Assembly.GetName().Version.ToString();  
        }

        private void frmAbout_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}