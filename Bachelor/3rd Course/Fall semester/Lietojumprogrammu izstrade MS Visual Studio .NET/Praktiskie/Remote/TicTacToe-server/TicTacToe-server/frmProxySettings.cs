using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe_server
{
    public partial class frmProxySettings : Form
    {
        public string Contribution
        {
            get
            {
                return txthost.Text;
            }
        }

        public string Port
        {
            get
            {
                return txtPort.Text;
            }
        }

        public bool Checked
        {
            get
            {
                return cbCross.Checked;
            }
        }

        public frmProxySettings()
        {
            InitializeComponent();
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
        }

        private void txthost_TextChanged(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
        }

        private void cbCross_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCross.Checked == true)
                cbNought.Checked = false;
            else
                cbNought.Checked = true;
        }

        private void cbNought_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNought.Checked == true)
                cbCross.Checked = false;
            else
                cbCross.Checked = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtPort.Text.Length > 4) 
            {
                this.errorProvider1.SetError(txtPort, "Incorrect value!");
            }
            else if (txthost.Text == "")
            {
                this.errorProvider1.SetError(txthost, "Host not specified!");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}