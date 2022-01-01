using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe_client
{
    public partial class frmProxySettings : Form
    {
        public string Port
        {
            get
            {
                return txtPort.Text;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtPort.Text.Length > 4)
            {
                this.errorProvider1.SetError(txtPort, "Incorrect!");
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