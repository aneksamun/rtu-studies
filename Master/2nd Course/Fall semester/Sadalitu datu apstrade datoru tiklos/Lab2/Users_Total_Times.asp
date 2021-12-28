<%
    Response.Charset = "Windows-1257"

    openstr = "driver={Microsoft Access Driver (*.mdb)};" &_
              "dbq=" & Server.MapPath("network.mdb")

    Set cn = Server.CreateObject("ADODB.Connection")
    Set rs = Server.CreateObject("ADODB.Recordset")

    cn.Open openstr

    sql = "select User, sum(TotalTime) as [Total] " &_
          "from AuditLog " &_
          "group by User"

    rs.Open sql, cn, 3, 3

    If rs.RecordCount > 0 Then
        i = 1

        Response.Write("<table border='1' cellpadding='5'>")
        Response.Write("<tr style='color: green'>" &_ 
                       "<td>Nr.</td>" &_ 
                       "<td>User</td>" &_ 
                       "<td>Total hours over all time</td></tr>")

        Do While NOT rs.EOF
            Response.Write("<tr>")
            Response.Write("<td><b>" & i & ".</b></td>")
             Response.Write("<td>" & rs.Fields("User") & "</td>")
             Response.Write("<td>" & rs.Fields("Total") & "</td>")    		   		
            Response.Write("</tr>")
            i = i + 1
            rs.MoveNext
        Loop

        Response.Write("</table>")
    Else
        Response.Write("<p>There is no any records found by now...</p>")
    End If

    rs.Close
    cn.Close

    Set rs = Nothing
    Set cn = Nothing
%>