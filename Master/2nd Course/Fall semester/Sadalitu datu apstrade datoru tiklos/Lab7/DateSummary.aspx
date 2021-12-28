<%@ Page Language="C#" Debug="true" Inherits="DateSummary" CodeFile="DateSummary.aspx.cs" %>
<html>
    <head>
        <title>Date usage filter</title>
        <script language="javascript" type="text/javascript">
            function validateDate(sender, e) {
                var currentDate = new Date();
                var filterDate = new Date(e.Value)

                e.IsValid = (filterDate >= currentDate) && 
                            (currentYear <= filterDate.getYear() + 1);
            }
        </script>
    </head>
    <body bgcolor="Cyan">
        <form id="Form1" runat="server">
            <asp:ValidationSummary ID="dateValidSummary" ValidationGroup="DateValidGroup" ShowSummary="true" runat="server" />
            <asp:Label ID="lbDate" Text="Date to filter:" runat="server" />
            <asp:TextBox ID="tbDate" runat="server" />
            <asp:RequiredFieldValidator ID="dateReqValidator" runat="server" Display="Dynamic" ValidationGroup="DateValidGroup" 
                ControlToValidate="tbDate" ErrorMessage="The date is required" Text="*" ForeColor="Red"
                ToolTip="The date is required" />
            <asp:CustomValidator ID="dateValidator" runat="server" Display="Dynamic"
                ControlToValidate="tbDate" ErrorMessage="Date format is invalid or date range is abuse (valid current or previous)" 
                Text="*" ForeColor="Red" ValidationGroup="DateValidGroup" ClientValidationFunction="validateDate"
                ToolTip="Date format is invalid or date range is abuse (valid current or previous)" />
            <asp:Button ID="btnFind" Text="Show" runat="server" OnClick="btnFind_Click" ValidationGroup="DateValidGroup" />
        </form>
    </body>
</html>