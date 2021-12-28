<%@ Page Language="C#" Debug="true" %>
<html>
    <head>
        <title>Duration Review</title>
    </head>
    <body bgcolor="Cyan">
        <form id="Form1" runat="server">
            <asp:AccessDataSource DataFile="~/lab9/network.mdb" ID="adsAuditLog" runat="server" 
                SelectCommandType="StoredProcedure" SelectCommand="FilterByDuration">
                <SelectParameters>
                    <asp:ControlParameter ControlID="tbMinDuration" />
                </SelectParameters>
            </asp:AccessDataSource>
            <asp:Label ID="lbMinDuration" Text="Minimal duration:" runat="server" />
            <asp:TextBox ID="tbMinDuration" runat="server" /><br/>
            <asp:Button ID="btnFind" Text="Find" runat="server" /><br />
            <hr style="width: 35%;" align="left" />
            <asp:FormView ID="auditLogFormView" AllowPaging="true" DataSourceID="adsAuditLog" 
                runat="server" BackColor="White">
                <ItemTemplate>
                    <table>
                      <tr>
                        <td><i>Lietotājs:</i></td>       
                        <td><%# Eval("User") %></td>
                      </tr>
                      <tr>
                        <td><i>Dators:</i></td>     
                        <td><%# Eval("Computer") %></td>
                      </tr>
                      <tr>
                        <td><i>Diena:</i></td>      
                        <td><%# ((DateTime)Eval("Day")).ToString("dd.MM.yyyy") %></td>
                      </tr>
                      <tr>
                        <td><i>Seansa ilgums:</i></td>
                        <td><%# Eval("TotalTime") %></td>
                      </tr>
                    </table>                 
                  </ItemTemplate>
            </asp:FormView>
        </form>
    </body>
</html>