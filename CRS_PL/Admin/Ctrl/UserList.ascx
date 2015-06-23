<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserList.ascx.cs" Inherits="nus.iss.crs.pl.Admin.Ctrl.UserList" %>
<asp:Table ID="Table1" runat="server" CssClass="table-bordered">
    <asp:TableRow>
        <asp:TableHeaderCell>UserID</asp:TableHeaderCell>
        <asp:TableHeaderCell>LogInID</asp:TableHeaderCell>
        <asp:TableHeaderCell>Name</asp:TableHeaderCell>
        <asp:TableHeaderCell>Email</asp:TableHeaderCell>
        <asp:TableHeaderCell>ContactNumber</asp:TableHeaderCell>
        <asp:TableHeaderCell>CompanyName</asp:TableHeaderCell>
        <asp:TableHeaderCell>Status</asp:TableHeaderCell>
    </asp:TableRow>
</asp:Table>