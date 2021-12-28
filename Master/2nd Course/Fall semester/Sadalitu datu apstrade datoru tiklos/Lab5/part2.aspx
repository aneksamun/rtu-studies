<%@ Page Language="VB" Debug="true" Inherits="Part2" Src="part2.aspx.vb" %>
<html>
    <head>
        <title>Computer usage (Code Inline)</title>
    </head>
    <body bgcolor="Cyan">
        <form id="Form1" runat="server">
            <asp:Label ID="lbComputerName" Text="Computer name:" runat="server" />
            <asp:TextBox ID="tbComputerName" runat="server" />
            <asp:Button ID="btnShow" Text="Show" runat="server" OnClick="btnShow_Click" />
        </form>
    </body>
</html>