<%@ Page Language="C#" Debug="true" Inherits="TotalSpendTime" CodeFile="TotalSpendTime.aspx.cs" %>
<html>
    <head>
        <title>Total spend time</title>
    </head>
    <body bgcolor="Cyan">
        <form id="Form1" runat="server">
            <asp:AccessDataSource DataFile="~/lab8/network.mdb" ID="adsUsers" runat="server"
                SelectCommand="select distinct User from AuditLog order by User" />
            <asp:Label ID="lbUser" Text="User:" runat="server" />
            <asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="adsUsers" 
                DataTextField="User" DataValueField="User" />
            <asp:Button ID="btnShow" Text="Show" runat="server" OnClick="btnShow_Click" />
        </form>
    </body>
</html>