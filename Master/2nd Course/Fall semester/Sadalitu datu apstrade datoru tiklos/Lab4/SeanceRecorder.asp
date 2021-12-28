<%
    openstr = "driver={Microsoft Access Driver (*.mdb)};" &_
              "dbq=" & Server.MapPath("network.mdb")

    Set cn = Server.CreateObject("ADODB.Connection")
    Set rs = Server.CreateObject("ADODB.Recordset")

    cn.Open openstr
    rs.Open "AuditLog", cn, 2, 2, adCmdTable

    rs.AddNew

    rs("User") = Request.Form.Item("User")
    rs("Computer") = Request.Form.Item("Computer")
    rs("Day") = Request.Form.Item("Day")
    rs("TotalTime") = Request.Form.Item("TotalTime")

    rs.Update

    Response.Write "Done!<br />"
    Response.Write "Total records: " & rs.RecordCount

    rs.Close
    cn.Close

    Set rs = nothing
    Set cn = nothing
%>