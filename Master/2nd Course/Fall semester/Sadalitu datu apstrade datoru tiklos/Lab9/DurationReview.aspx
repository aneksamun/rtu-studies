<%@ Page Language="C#" Debug="true" Inherits="DurationReview" CodeFile="DurationReview.aspx.cs" %>
<html>
    <head>
        <title>Duration Review</title>
    </head>
    <body bgcolor="Cyan">
        <form id="Form1" runat="server">
            <asp:Label ID="lbMinDuration" Text="Minimal duration:" runat="server" />
            <asp:TextBox ID="tbMinDuration" runat="server" /><br/>
            <asp:Button ID="btnFind" Text="Find" runat="server" OnClick="btnFind_Click" /><br />
            <hr style="width: 35%;" align="left" />
            <asp:GridView ID="gwAuditLog" runat="server" HeaderStyle-Font-Bold="true" BorderWidth="6" 
                BorderColor="Silver" CellPadding="5" BackColor="White" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="User" HeaderText="Lietotājs" />
                    <asp:BoundField DataField="Computer" HeaderText="Dators" />
                    <asp:BoundField DataField="Day" HeaderText="Diena" DataFormatString="{0:dd.MM.yyyy}" />
                    <asp:BoundField DataField="TotalTime" HeaderText="Seansa ilgums" />
                </Columns>
            </asp:GridView>
        </form>
    </body>
</html>