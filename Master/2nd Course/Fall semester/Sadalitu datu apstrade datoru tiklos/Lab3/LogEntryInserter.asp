<% @Language="JScript" %>
<%
    var openstr = "driver={Microsoft Access Driver (*.mdb)};" +
              "dbq=" + Server.MapPath("network.mdb");
             
    var user = Request.QueryString("User");
    var computer = Request.QueryString("Computer");
    var day = Request.QueryString("Day");
    var totalTime = Request.QueryString("TotalTime");
    
    var sql = "insert into AuditLog (User, Computer, Day, TotalTime) " +
              "values ('" + user + "', '" + computer + "', '" + day + "', '" + totalTime + "');";

    var cn = Server.CreateObject("ADODB.Connection");
    
    cn.Open(openstr);
    cn.Execute(sql);
    
    cn.close()
    cn = null;
    
    Response.Write("Done!");
%>