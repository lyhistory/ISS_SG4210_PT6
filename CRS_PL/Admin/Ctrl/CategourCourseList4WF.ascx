<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategourCourseList4WF.ascx.cs" Inherits="nus.iss.crs.pl.Admin.Ctrl.CategourCourseList4WF" %>
<asp:Table ID="Table1" runat="server" GridLines="Both" CssClass="table">
        <asp:TableRow runat="server">
            <asp:TableHeaderCell ColumnSpan="2">Programe </asp:TableHeaderCell>
                        
             <asp:TableHeaderCell>Start Date</asp:TableHeaderCell>
            <asp:TableHeaderCell>End Date</asp:TableHeaderCell>
            <asp:TableHeaderCell>Capacity</asp:TableHeaderCell>
            <asp:TableHeaderCell>No of Participant</asp:TableHeaderCell>
            <asp:TableHeaderCell>Confirmation Status</asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell ColumnSpan="6"  >
                <asp:Label ID="categoryID" runat="server"></asp:Label>
              </asp:TableCell>                     
        </asp:TableRow>
         
    </asp:Table>
    

