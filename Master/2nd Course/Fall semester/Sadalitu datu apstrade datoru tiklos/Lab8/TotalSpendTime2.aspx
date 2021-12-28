<%@ Page Language="C#" Debug="true" Inherits="TotalSpendTime2" CodeFile="TotalSpendTime2.aspx.cs" %>
<html>
    <head>
        <title>Total spend time</title>
    </head>
    <body bgcolor="Cyan">
        <form id="Form1" runat="server">
            <asp:Label ID="lbUser" Text="User:" runat="server" />
            <asp:DropDownList ID="ddlUsers" runat="server" DataTextField="User" DataValueField="User" />
            <asp:Button ID="btnShow" Text="Show" runat="server" OnClick="btnShow_Click" />
        </form>
    </body>
</html>