Imports System.Data
Imports System.Web.UI
Imports System.Data.Odbc

Public Class Part2
    Inherits System.Web.UI.Page

    Protected tbComputerName As TextBox
    Protected btnShow As Button
    Protected lbComputerName As Label

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim connectionString As String = "Driver={Microsoft Access Driver (*.mdb)};Dbq=" & Server.MapPath("network.mdb") & ";"

        Dim sql As String = "select * from AuditLog " & _
                              "where Computer = '" & tbComputerName.Text & "'"

        Using cn As New OdbcConnection(connectionString)
            cn.Open()

            Dim cmd As OdbcCommand = New OdbcCommand(sql, cn)

            Using reader As OdbcDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
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

        End Using
    End Sub
End Class