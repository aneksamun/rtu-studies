using System;
using System.Windows.Forms;
using Lab1Library;

namespace Lab1Form {
    public partial class frmStudents : Form {

        private StudentList students = new StudentList();

        public frmStudents() {
            InitializeComponent();
        }

        private void InvalidateList() {
            lstStudents.VirtualListSize = students.Count;
            lstStudents.Invalidate();
        }

        private void ClearControls() {
            foreach (Control c in this.Controls)
                if (c is TextBox)
                    c.Text = string.Empty;
        }

        private void btnAddStudent_Click(object sender, EventArgs e) {
            try {
                students.Add(new Student(txtName.Text,
                    txtSurname.Text, txtId.Text, txtGroup.Text, txtEmail.Text));

                InvalidateList();

                ClearControls();

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            try {
                students.Save(StudentList.DefaultFilename);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            try {
                students.Load(StudentList.DefaultFilename);
                InvalidateList();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstStudents_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            try {
                Student s = students[e.ItemIndex];
                e.Item = new ListViewItem(s.Name);
                e.Item.SubItems.Add(s.Surname);
                e.Item.SubItems.Add(s.Id);
                e.Item.SubItems.Add(s.Group);
                e.Item.SubItems.Add(s.Email);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
