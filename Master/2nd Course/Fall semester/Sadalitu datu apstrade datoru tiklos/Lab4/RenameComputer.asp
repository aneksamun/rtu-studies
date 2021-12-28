<%
    openstr = "driver={Microsoft Access Driver (*.mdb)};" &_
              "dbq=" & Server.MapPath("network.mdb")
    
    oldName = Request.Form.Item("OldName")
    newName = request.Form.item("NewName")

    Set cn = Server.CreateObject("ADODB.Connection")
    Set rs = Server.CreateObject("ADODB.Recordset")

    cn.Open openstr
    rs.Open "AuditLog", cn, 3, 4, adCmdTable

    Do While Not rs.EOF
        If (UCase(rs("Computer").Value) = UCase(oldName)) Then
            rs("Computer") = UCase(newName)
        End If

        rs.MoveNext
    Loop

    rs.UpdateBatch

    Response.Write "Done!<br />"
    Response.Write "Total records: " & rs.RecordCount

    rs.Close
    cn.Close

    Set rs = nothing
    Set cn = nothing
%>