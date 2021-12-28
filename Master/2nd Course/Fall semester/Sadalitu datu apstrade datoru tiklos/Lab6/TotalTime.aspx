<%@ Page Language="C#" Debug="true" Inherits="TotalTime" CodeFile="TotalTime.aspx.cs" %>
<html>
    <head>
        <title>Total time filter</title>
    </head>
    <body bgcolor="Cyan">
        <form id="Form1" runat="server">
            <asp:ValidationSummary ID="timesValidSummary" ValidationGroup="TimesValidGroup" ShowSummary="true" runat="server" />
            <asp:Label ID="lbTimes" Text="Time to find:" runat="server" />
            <asp:TextBox ID="tbTimes" runat="server" />
            <asp:RequiredFieldValidator ID="timeReqValidator" runat="server" Display="Dynamic" ValidationGroup="TimesValidGroup" 
                ControlToValidate="tbTimes" ErrorMessage="The times is required" Text="*" ForeColor="Red"
                ToolTip="The times is required" />
            <asp:CompareValidator ID="timesRangeValidator" runat="server" Display="Dynamic" Type="Integer" Operator="GreaterThan"
                ControlToValidate="tbTimes" ErrorMessage="The times must positive number" Text="*" ForeColor="Red"
                ValidationGroup="TimesValidGroup" ValueToCompare="0" ToolTip="The times must positive number" />
            <asp:Button ID="btnFind" Text="Show" runat="server" OnClick="btnFind_Click" ValidationGroup="TimesValidGroup" />
        </form>
    </body>
</html>