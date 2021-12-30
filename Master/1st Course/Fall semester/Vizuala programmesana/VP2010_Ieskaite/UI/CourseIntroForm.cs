using System;
using System.ComponentModel;
using System.Windows.Forms;
using CourseSystem.Bussines;
using Microsoft.Reporting.WinForms;

namespace CourseSystem.UI { 
    public partial class CourseIntroForm : Form {
        
        public CourseIntroForm() {
            InitializeComponent();
        }

        private void CourseIntroForm_Load(object sender, EventArgs e) {
            dtpEndTime.Value = DateTime.Now;
            dtpStartTime.Value = DateTime.Now;
            UpdateCourseList();
        }

        private void txtMaxParticipants_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void tbValue_Validating(object sender, CancelEventArgs e) {
            
            TextBox tb = (TextBox)sender;
            e.Cancel = true;

            if (tb != null) {
                errorProvider.SetError(tb, null);

                if (tb.Text == String.Empty) {
                    errorProvider.SetError(tb, "Laukam jābūt aizpildītam.");
                    return;
                }

                e.Cancel = false;
            }
        }

        private void dtpStartTime_Validating(object sender, CancelEventArgs e) {
            
            DateTimePicker dtp = sender as DateTimePicker;
            e.Cancel = true;

            if (dtp != null) {
                errorProvider.SetError(dtp, null);

                if (dtp.Value < DateTime.Now) {
                    errorProvider.SetError(dtp, "Norādīts laiks pagātnē.");
                    return;
                }

                e.Cancel = false;
            }
        }

        private void dtpEndTime_Validating(object sender, CancelEventArgs e) {
            
            var dtp = sender as DateTimePicker;
            e.Cancel = true;

            if (dtp != null) {
                errorProvider.SetError(dtp, null);

                if (dtp.Value < dtpStartTime.Value) {
                    errorProvider.SetError(dtp, "Datums \"Līdz\" ir mazāks par datumu \"No\".");
                    return;
                }

                e.Cancel = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            
            if (!this.ValidateChildren())
                return;

            Course course = new Course {
                Title = txtTitle.Text,
                Chairman = txtChairman.Text,
                Location = txtLocation.Text,
                StartTime = dtpStartTime.Value,
                EndTime = dtpEndTime.Value,
                MaxParticipantsNum = short.Parse(txtMaxParticipants.Text)
            };

            try {
                AddMethods.AddCourse(course);
                UpdateCourseList();
                ClearControls();
            } 
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void ClearControls() {
            
            foreach (Control c in gbCourseInfo.Controls)
                if (c is TextBox)
                    c.Text = String.Empty;

            dtpStartTime.Value = DateTime.Now;
            dtpEndTime.Value = DateTime.Now;
        }

        private void UpdateCourseList() {
            lstCourses.DataSource = GetMethods.GetCoursesTitles();
            lstCourses.DisplayMember = "Title";
            lstCourses.ValueMember = "CourseID";
        }

        private void btnGenerateReport_Click(object sender, EventArgs e) {
            Course course = GetMethods.GetCourseByID((int)lstCourses.SelectedValue);

            if (course == null) {
                MessageBox.Show(
                    "Izvēlēts neeksistējošs kurss.", 
                    "Paziņojums", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                return;
            }

            RepViewForm reportForm = new RepViewForm();
            var reportParams = new ReportParameter[6];

            reportParams[0] = new ReportParameter("courseId", course.CourseID.ToString());
            reportParams[1] = new ReportParameter("courseTitle", course.Title);
            reportParams[2] = new ReportParameter("courseChairman", course.Chairman);
            reportParams[3] = new ReportParameter("courseLocation", course.Location);
            reportParams[4] = new ReportParameter("courseStartTime", course.StartTime.ToString("dd/MM/yyyy HH:mm"));
            reportParams[5] = new ReportParameter("courseEndTime", course.EndTime.ToString("dd/MM/yyyy HH:mm"));

            reportForm.reportViewer.LocalReport.SetParameters(reportParams);

            reportForm.ShowDialog();
        }
    }
}
