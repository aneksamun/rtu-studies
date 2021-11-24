using System;
using System.Windows.Forms;
using HealthSystem.Common;
using HealthSystem.UI.Disease;
using HealthSystem.UI.Patient;
using HealthSystem.UI.Personal;
using HealthSystem.UI.Threatment;

namespace HealthSystem.UI {
    
    public partial class MdiParentForm : Form {
        
        public MdiParentForm() {
            InitializeComponent();
        }

        private void MdiParentForm_Load(object sender, EventArgs e) {
            
            LoginForm loginForm = new LoginForm();

            if (loginForm.ShowDialog() == DialogResult.OK) {
                this.WindowState = FormWindowState.Maximized;

                switch (GlobalMembers.GlobalPersonType) {
                    case (int)Classifiers.PersonType.Administrators:
                        slimībasToolStripMenuItem.Enabled = false;
                        pacientiToolStripMenuItem.Enabled = false;
                        break;
                    case (int)Classifiers.PersonType.Ārsts:
                        reģistrētToolStripMenuItem.Enabled = false;
                        sarakstsToolStripMenuItem.Enabled = false;
                        reģDarbSarakstsToolStripMenuItem.Enabled = false;
                        pacientuSarakstsToolStripMenuItem.Enabled = false;
                        norikotToolStripMenuItem.Enabled = false;
                        reģistrētToolStripMenuItem1.Enabled = false;
                        break;
                    case (int)Classifiers.PersonType.Reģ_darb:
                        reģistrētToolStripMenuItem.Enabled = false;
                        sarakstsToolStripMenuItem.Enabled = false;
                        reģDarbSarakstsToolStripMenuItem.Enabled = false;
                        ārstēšanasSarakstsToolStripMenuItem.Enabled = false;
                        arstēšanaToolStripMenuItem.Enabled = false;
                        slimībasToolStripMenuItem.Enabled = false;
                        break;
                    case (int)Classifiers.PersonType.Pacients:
                        darbiniekiToolStripMenuItem.Enabled = false;
                        slimībasToolStripMenuItem.Enabled = false;
                        reģistrētToolStripMenuItem1.Enabled = false;
                        norikotToolStripMenuItem.Enabled = false;
                        arstēšanaToolStripMenuItem.Enabled = false;
                        pacientuSarakstsToolStripMenuItem.Enabled = false;
                        break;
                }
            } else
                this.Close();

            loginForm.Dispose();
        }

        private void CheckMdiChildren(Form form) {
            foreach (Form frm in this.MdiChildren) {
                if (frm.Text == form.Text) {
                    frm.Focus();
                    return;
                }
            }
            form.MdiParent = this;
            form.Show();
        }

        private void sarakstsToolStripMenuItem_Click(object sender, EventArgs e) {
            DoctorListForm docListForm = new DoctorListForm();
            CheckMdiChildren(docListForm);
        }

        private void reģistrētToolStripMenuItem_Click(object sender, EventArgs e) {
            EmployersForm empForm = new EmployersForm();
            CheckMdiChildren(empForm);
        }

        private void reģDarbSarakstsToolStripMenuItem_Click(object sender, EventArgs e) {
            registryStaffListForm deskClerkListForm = new registryStaffListForm();
            CheckMdiChildren(deskClerkListForm);
        }

        private void mainītProfiluToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (Form frm in this.MdiChildren) {
                if (frm.Text == "Lietotājs") {
                    frm.Focus();
                    return;
                }
            }

            EmployersForm empForm = new EmployersForm(GlobalMembers.GlobalPersonID, GlobalMembers.GlobalPersonType);
            empForm.Text = "Lietotājs";
            empForm.MdiParent = this;
            empForm.Show();
        }

        private void aizvērtToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void izietToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Restart();
        }

        private void palidzībaToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutForm aboutForm = new AboutForm();
            CheckMdiChildren(aboutForm);
        }

        private void grupētToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void izveitotHorizontāliToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void izvietotVertikāliToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void reģistrētToolStripMenuItem2_Click(object sender, EventArgs e) {
            DiseaseForm diseaseForm = new DiseaseForm();
            CheckMdiChildren(diseaseForm);
        }

        private void sarakstsToolStripMenuItem1_Click(object sender, EventArgs e) {
            DiseaseListForm diseaseListForm = new DiseaseListForm();
            CheckMdiChildren(diseaseListForm);
        }

        private void reģistrētToolStripMenuItem1_Click(object sender, EventArgs e) {
            PatientsForm patientForm = new PatientsForm();
            CheckMdiChildren(patientForm);
        }

        private void pacientuSarakstsToolStripMenuItem_Click(object sender, EventArgs e) {
            PatientsListForm patientListForm = new PatientsListForm();
            CheckMdiChildren(patientListForm);
        }

        private void norikotToolStripMenuItem_Click(object sender, EventArgs e) {
            PatientAssignmentForm patientAssignmentForm = new PatientAssignmentForm();
            CheckMdiChildren(patientAssignmentForm);
        }

        private void arstēšanaToolStripMenuItem_Click(object sender, EventArgs e) {
            TreatmentsForm treatmentForm = new TreatmentsForm();
            CheckMdiChildren(treatmentForm);
        }

        private void ārstēšanasSarakstsToolStripMenuItem_Click(object sender, EventArgs e) {
            TreatmentsListForm treatmentListForm = new TreatmentsListForm();
            CheckMdiChildren(treatmentListForm);
        }
    }
}
