using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseSystem.Bussines;
using System.Diagnostics;

namespace WebUI {
    public partial class CourseList : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                try {
                    gwCourses.DataSource = GetMethods.GetCourses();
                    gwCourses.DataBind();
                } 
                catch (Exception ex) {
                    Debug.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
