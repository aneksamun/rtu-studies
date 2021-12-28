using System;
using System.Web.UI;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Text;

public partial class DurationReview : Page {
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

        if (string.IsNullOrEmpty(tbMinDuration.Text)) {
            gwAuditLog.DataSource = null;
            gwAuditLog.DataBind();
            return;
        }

        using (OleDbConnection cn = new OleDbConnection(ConnectionString)) {
            cn.Open();

            OleDbCommand cmd = new OleDbCommand("FilterByDuration", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Duration", OleDbType.Single, 4);
            cmd.Parameters["@Duration"].Value = tbMinDuration.Text;

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            gwAuditLog.DataSource = dt;
            gwAuditLog.DataBind();

            cmd.Parameters.Clear();
        }
    }
}