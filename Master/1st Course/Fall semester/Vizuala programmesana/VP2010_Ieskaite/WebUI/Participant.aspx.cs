using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using CourseSystem.Bussines;
using System.Diagnostics;

namespace WebUI {
    public partial class Participant : System.Web.UI.Page {

        private int op1, op2;
        private int? result = null;
        private enum Operation { Add, Sub };
        private Random random = new Random();
        private Operation action;

        protected void Page_Load(object sender, EventArgs e) {
            msgLiteral.Text = String.Empty;

            if (ViewState["result"] == null)
                GenerateExp();
        }

        private void GenerateExp() {
            op1 = random.Next(100);
            op2 = random.Next(100);

            action = (Operation)Enum.ToObject(typeof(Operation), random.Next(2));
            lblExp.Text = String.Format("{0} {1} {2}", op1, OpToString(action), op2);
            result = CalculateExp(op1, action, op2);
            ViewState["result"] = result;
        }

        private string OpToString(Operation op) {
            switch (op) {
                case Operation.Add:
                    return "+";
                case Operation.Sub:
                    return "-";
                default:
                    throw new NotImplementedException("Expected value");
            }
        }

        private int CalculateExp(int op1, 
            Operation op, 
            int op2) {

            switch (op) {
                case Operation.Add:
                    return op1 + op2;
                case Operation.Sub:
                    return op1 - op2;
                default: 
                    throw new NotImplementedException("Expected value");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e) {
            registrationValidator.Validate();
            
            if (!registrationValidator.IsValid)
                return;

            registrationValidator.Text = String.Empty;
            int courseId = int.Parse(Request.QueryString["CourseID"]);

            try {
                if (GetMethods.IsParticipated(courseId,
                    Server.HtmlDecode(txtFirstname.Text),
                    Server.HtmlDecode(txtLastname.Text),
                    Server.HtmlDecode(txtPhoneNum.Text))) {

                    msgLiteral.Text = "Jūs esat jau reģistrēts/-a dotajām kursam.";
                    return;
                }

                msgLiteral.Text = String.Empty;

                CourseSystem.Bussines.Participant participant;
                participant = new CourseSystem.Bussines.Participant {
                    Firstname = txtFirstname.Text,
                    Lastname = txtLastname.Text,
                    Email = txtEmail.Text,
                    PhoneNumber = int.Parse(txtPhoneNum.Text),
                    CourseID = courseId,
                    RegistrationDate = DateTime.Now.Date
                };

                AddMethods.AddParticipant(participant);

                msgLiteral.Text = "Jūs esat vieksmīgi reģistrējies/-usies izvēlētājam kursām.";

                ClearControls();
                GenerateExp();

            } catch (Exception ex) {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        protected void registrationValidator_ServerValidate(object source, ServerValidateEventArgs args) {

            Regex emailRegex = new Regex("(?<user>[^@]+)@(?<host>.+)");
            args.IsValid = true;

            if (String.IsNullOrEmpty(txtFirstname.Text) ||
                txtFirstname.Text.Length > 25) {
                args.IsValid = false;
                registrationValidator.Text = "Vārds nav atbilstošs.";
                return;
            }

            if (String.IsNullOrEmpty(txtLastname.Text) ||
                txtLastname.Text.Length > 25) {
                args.IsValid = false;
                registrationValidator.Text = "Uzvārds nav atbilstošs.";
                return;
            }

            if (String.IsNullOrEmpty(txtEmail.Text) ||
                txtEmail.Text.Length > 50 ||
                !emailRegex.Match(txtEmail.Text).Success) {

                args.IsValid = false;
                registrationValidator.Text = "E-pasts nav korekti ievadīts.";
                return;
            }

            int number;
            if (txtPhoneNum.Text.Length != 8 ||
                !int.TryParse(txtPhoneNum.Text, out number) ||
                txtPhoneNum.Text[0] != '2') {

                args.IsValid = false;
                registrationValidator.Text = "Tālrunis nav korekti ievadīts.";
                return;
            }

            if (txtAnswer.Text == String.Empty ||
                !int.TryParse(txtAnswer.Text, out number)) {
                args.IsValid = false;
                registrationValidator.Text = "Izteiksmes vertība nav aprēķināta.";
                return;
            }

            if (ViewState["result"] != null)
                result = (int)ViewState["result"];

            if (number != result) {
                args.IsValid = false;
                registrationValidator.Text = "Izteiksme ir aprēķināta nepariezi.";
                return;
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e) {
            Response.Redirect("~/CourseList.aspx");
        }

        private void ClearControls() {
            txtEmail.Text = String.Empty;
            txtFirstname.Text = String.Empty;
            txtLastname.Text = String.Empty;
            txtPhoneNum.Text = String.Empty;
            txtAnswer.Text = String.Empty;
        }
    }
}
