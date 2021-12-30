<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseList.aspx.cs" Inherits="WebUI.CourseList" MasterPageFile="~/Page.Master" %>

<asp:Content ID="MainPage" ContentPlaceHolderID="PageContent" runat="server">
    <form id="CourseList" runat="server">
        <div style="text-align: center"><center>
            <asp:GridView ID="gwCourses" runat="server" AutoGenerateColumns="False"
             Height="82px" Width="80%" style="font-size: 10pt; font-family: Arial" 
                CellPadding="4" ForeColor="#333333" BorderColor="#AAE0DE" 
                GridLines="Vertical">
                <RowStyle BorderColor="Black" BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Kursa nosaukums" 
                        SortExpression="Title" />
                    <asp:BoundField DataField="Chairman" HeaderText="Vadītājs" 
                        SortExpression="Chairman" />
                    <asp:BoundField DataField="Location" HeaderText="Atrašanas vieta" 
                        SortExpression="Location" />
                    <asp:BoundField DataField="StartTime" HeaderText="Laiks no" 
                        SortExpression="StartTime" DataFormatString="{0:dd.MM.yyyy HH:mm}" />
                    <asp:BoundField DataField="EndTime" HeaderText="Laiks līdz " 
                        SortExpression="EndTime" DataFormatString="{0:dd.MM.yyyy HH:mm}" />
                    <asp:BoundField DataField="MaxParticipantsNum" 
                        HeaderText="Max dalībnieku sk." />
                    <asp:HyperLinkField DataNavigateUrlFields="CourseID" HeaderText="Pieteikšanās"
                        DataNavigateUrlFormatString="Participant.aspx?CourseID={0}" 
                        Text="Pieteikties" DataTextFormatString="{0:c}"/>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#AAE0DE" BorderColor="Black" Font-Bold="True" 
                    ForeColor="Black" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BorderStyle="None" BackColor="White" />
            </asp:GridView></center>
        </div>
    </form>
</asp:Content>
