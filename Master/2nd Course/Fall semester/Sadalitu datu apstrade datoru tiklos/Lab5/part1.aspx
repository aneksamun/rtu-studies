<%@ Page Language="VB" Debug="true" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<script runat="server">
    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As EventArgs)
        
        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & _
            Server.MapPath("network.mdb")
        
        Const sql As String = "select * from AuditLog " & _
                              "where Computer = @Name"
        
        Using cn As New OleDbConnection(connectionString)
            cn.Open()
            
            Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
            
            cmd.Parameters.Add("@Name", OleDbType.VarChar)
            cmd.Parameters("@Name").Value = tbComputerName.Text
            
            Using reader As OleDbDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If Not reader.HasRows Then
                    Response.Write(String.Format("The {0} hasn't been used yet.", tbComputerName.Text))
                Else
                    Response.Write("<table border='1' style='background: white'>")
                    Response.Write("<tr style='color: green'>" & _
                                   "<td>Nr.</td>" & _
                                   "<td>User</td>" & _
                                   "<td>Computer</td>" & _
                                   "<td>Date</td>" & _
                                   "<td>Total time</td></tr>")
                    
                    Dim i As Integer = 1
                    
                    While reader.Read
                        Response.Write(String.Format("<tr><td><b>{0}.</b></td>", i))
                        Response.Write(String.Format("<td>{0}</td>", reader("User")))
                        Response.Write(String.Format("<td>{0}</td>", reader("Computer")))
                        Response.Write(String.Format("<td>{0}</td>", CDate(reader("Day")).ToString("dd.MM.yyyy")))
                        Response.Write(String.Format("<td>{0}</td></tr>", reader("TotalTime")))
                        
                        i += 1
                    End While
                    
                    Response.Write("</table><br />")
                End If
            End Using
            
            cmd.Parameters.Clear()
        End Using
    End Sub
</script>
<html>
    <head>
        <title>Computer usage (Code Inline)</title>
    </head>
    <body bgcolor="Cyan">
        <form runat="server">
            <asp:Label ID="lbComputerName" Text="Computer name:" runat="server" />
            <asp:TextBox ID="tbComputerName" runat="server" />
            <asp:Button ID="btnShow" Text="Show" runat="server" OnClick="btnShow_Click" />
        </form>
    </body>
</html>