using System;
using System.Web.UI;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Text;

public partial class TotalTime : Page {
    /// <summary>
    /// Gets connection string from settings.
    /// </summary>
    private string ConnectionString {
        get {
            return ConfigurationManager
                .ConnectionStrings["AuditLog"].ConnectionString;
        }
    }

    protected void btnFind_Click(object sender, EventArgs e) {

        const string sql = @"select Computer, Day, Sum(TotalTime) As Total
                             from AuditLog
                             group by Computer, Day
                             having Sum(TotalTime) >= @Total;";

        using (OleDbConnection cn = new OleDbConnection(ConnectionString)) {
            cn.Open();

            StringBuilder sb = new StringBuilder();
            OleDbCommand cmd = new OleDbCommand(sql, cn);

            cmd.Parameters.Add("@Total", OleDbType.Integer);
            cmd.Parameters["@Total"].Value = int.Parse(tbTimes.Text);

            using (OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                if (!reader.HasRows)
                    return;

                sb.AppendLine("<table border='1' style='background: white'>\r\n" + 
                    "<tr style='color: green'>" +
                    "<td>Nr.</td><td>Computer</td><td>Date</td><td>Total usage time</td></tr>");

                int i = 0;
                while (reader.Read()) {
                    sb.AppendLine(
                        string.Format(
                        "<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>",
                        ++i, 
                        reader["Computer"], 
                        ((DateTime)reader["Day"]).ToString("dd.MM.yyyy"),
                        reader["Total"]));
                }
            }

            cmd.Parameters.Clear();
            sb.AppendLine("</table><br />");
            Response.Write(sb.ToString());
        }
    }
}