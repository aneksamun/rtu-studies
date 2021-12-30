using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CourseSystem.UI {
    public partial class RepViewForm : Form {
        public RepViewForm() {
            InitializeComponent();
        }

        private void RepViewForm_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'DbDataSet.Participant' table. You can move, or remove it, as needed.
            this.WindowState = FormWindowState.Maximized;
            this.ParticipantTableAdapter.Fill(this.DbDataSet.Participant);
            this.reportViewer.RefreshReport();
        }
    }
}
