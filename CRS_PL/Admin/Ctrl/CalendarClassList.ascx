<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalendarClassList.ascx.cs" Inherits="nus.iss.crs.pl.Admin.Ctrl.CalendarClassList" %>
<asp:Table ID="Table1" runat="server" GridLines="Both" CssClass="table">
    <asp:TableRow runat="server">
        <asp:TableHeaderCell ColumnSpan="1" Wrap="false" Width="300">Class ID </asp:TableHeaderCell>            
        <asp:TableHeaderCell Wrap="false" Width="50">Size</asp:TableHeaderCell>
        <asp:TableHeaderCell Wrap="false" Width="500">Start Date</asp:TableHeaderCell>
        <asp:TableHeaderCell Wrap="false" Width="500">End Date</asp:TableHeaderCell>
        <asp:TableHeaderCell>Status</asp:TableHeaderCell>
        <asp:TableHeaderCell ColumnSpan ="5" Width="300">Operation</asp:TableHeaderCell>
    </asp:TableRow>
</asp:Table>