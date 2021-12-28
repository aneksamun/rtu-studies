<!-- #include file="adovbs.inc" -->
<%
    postday = Request.QueryString.Item("post_day")

    openstr = "driver={Microsoft Access Driver (*.mdb)};" &_
              "dbq=" & Server.MapPath("network.mdb")

    Set cn = Server.CreateObject("ADODB.Connection")
    Set cmd = Server.CreateObject("ADODB.Command")
    Set dayParam = Server.CreateObject("ADODB.Parameter")

    cn.Open openstr
    Set cmd.ActiveConnection = cn
    
    cmd.CommandText = "FilterByDate"
    cmd.CommandType = adCmdStoredProc
    
    dayParam.Name = "Day"
    dayParam.Type = adVarChar
    dayParam.Direction = adParamInput
    dayParam.Size = Len(postday)
    dayParam.Value = postday
    
    cmd.Parameters.Append dayParam

    Set rs = cmd.Execute()

    If Not rs.EOF Then
        i = 1

        Response.Write("<table border='1' cellpadding='5'>")
        Response.Write("<tr style='color: green'>" &_ 
                       "<td>Nr.</td>" &_ 
                       "<td>User</td>" &_
                        "<td>Computer</td>" &_
                       "<td>Total hours over all time</td></tr>")

        Do While NOT rs.EOF
            Response.Write("<tr>")
            Response.Write("<td><b>" & i & ".</b></td>")
            Response.Write("<td>" & rs.Fields("User") & "</td>")
            Response.Write("<td>" & rs.Fields("Computer") & "</td>")     		
            Response.Write("<td>" & rs.Fields("TotalTime") & "</td>")    		   		
            Response.Write("</tr>")
            i = i + 1
            rs.MoveNext
        Loop

        Response.Write("</table>")
    Else
        Response.Write "There is no any PC was used in following date: " & postday
    End If

    cn.Close
    Set cn  = nothing
%>
<%
    Function pd(n, totalDigits) 
        if totalDigits > len(n) then 
            pd = String(totalDigits-len(n),"0") & n 
        else 
            pd = n 
        end if 
    End Function
 %>