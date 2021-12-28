using System;
using System.Web.UI;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Text;

public partial class TotalSpendTime2 : Page {
    /// <summary>
    /// Gets connection string from settings.
    /// </summary>
    private string ConnectionString {
        get {
            return ConfigurationManager
                .ConnectionStrings["AuditLog"].ConnectionString;
        }
    }

    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {
            const string query = @"select distinct User
                                   from AuditLog
                                   order by User;";

            // for implicitly type support please set .NET 4.0 for IIS.
            using (var cn = new OleDbConnection(ConnectionString)) {
                cn.Open();

                var dt = new DataTable();
                var da = new OleDbDataAdapter(query, cn);
                
                da.Fill(dt);

                ddlUsers.DataSource = dt;
                ddlUsers.DataValueField = "User";
                ddlUsers.DataTextField = "User";
                ddlUsers.DataBind();
            }
        }
    }

    protected void btnShow_Click(object sender, EventArgs e) {

        const string sql = @"select User, Computer, TotalTime
                             from AuditLog
                             where User = @User;";

        using (OleDbConnection cn = new OleDbConnection(ConnectionString)) {
            cn.Open();

            StringBuilder sb = new StringBuilder();
            OleDbCommand cmd = new OleDbCommand(sql, cn);

            cmd.Parameters.Add("@User", OleDbType.VarChar);
            cmd.Parameters["@User"].Value = ddlUsers.SelectedValue;

            using (OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                if (!reader.HasRows)
                    return;

                sb.AppendLine("<table border='1' style='background: white'>\r\n" + 
                    "<tr style='color: green'>" +
                    "<td>Nr.</td><td>User</td><td>Computer</td><td>Spended time</td></tr>");

                int i = 0;
                while (reader.Read()) {
                    sb.AppendLine(
                        string.Format(
                        "<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>",
                        ++i,
                        reader["User"],
                        reader["Computer"], 
                        reader["TotalTime"]));
                }
            }

            cmd.Parameters.Clear();
            sb.AppendLine("</table><br />");
            Response.Write(sb.ToString());
        }
    }
}