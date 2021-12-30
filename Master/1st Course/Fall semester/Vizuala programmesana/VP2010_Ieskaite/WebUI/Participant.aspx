<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Participant.aspx.cs" Inherits="WebUI.Participant" MasterPageFile="~/Page.Master"%>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            font-size: 10pt; 
            font-family: Arial; 
        }
        .style2 
        {
            width: 80%; 
            border: 1px;
        }
        .style3
        {
            border-color: inherit;
            border-width: 1px;
            width: 20%;
            text-align: center;
        }
    </style>

</asp:Content>

<asp:Content ID="MainPage" ContentPlaceHolderID="PageContent" runat="server">
    <form id="form1" runat="server">
        <center><div>
            <table border="0px" class="style1" cellpadding="0" cellspacing="0" width="30%">
                <tr>
                    <td class="style3">Vārds:</td>
                    <td class="style2">
                        <asp:TextBox ID="txtFirstname" runat="server" Width="100%" 
                            ValidationGroup="RegistrationInfo" style="margin-left: 0px" />
                    </td>
                </tr>
                <tr>
                    <td class="style3">Uzvārds:</td>
                    <td class="style2">
                        <asp:TextBox ID="txtLastname" runat="server" Width="100%" 
                            ValidationGroup="RegistrationInfo" />
                    </td>
                </tr>
                <tr>
                    <td class="style3">E-pasts:</td>
                    <td class="style2">
                    <asp:TextBox ID="txtEmail" runat="server" Width="100%" 
                        ValidationGroup="RegistrationInfo"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="style3">Tālrunis:</td>
                    <td class="style2">
                        <asp:TextBox ID="txtPhoneNum" runat="server" Width="100%" 
                            ValidationGroup="RegistrationInfo"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:Label ID="lblExp" Text="EXP" runat="server" />
            &nbsp;=&nbsp;
            <asp:TextBox ID="txtAnswer" runat="server" Width="80px" 
                ValidationGroup="RegistrationInfo" />
        </div>
        <br />
        <asp:CustomValidator ID="registrationValidator" runat="server" 
            ErrorMessage="*" ValidationGroup="RegistrationInfo" 
                onservervalidate="registrationValidator_ServerValidate"></asp:CustomValidator>
        <br />
            <span>
                <asp:Literal ID="msgLiteral" runat="server" />
            </span>
        <br />
        <br />
        <table width="100%" style="background-color:#AAE0DE;">
            <tr>
                <td width="60%">&nbsp;</td>
                <td width="40%">
                    <asp:Button ID="btnReturn" runat="server" Text="Atgriezties" 
                        onclick="btnReturn_Click" />
                    &nbsp;
                    <asp:Button ID="btnSave" runat="server" style="margin-left: 0px" 
                        Text="Saglabāt" Width="77px" onclick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </center>
    </form>
</asp:Content>


