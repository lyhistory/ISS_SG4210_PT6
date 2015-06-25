<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="CourseConfirmWF.aspx.cs" Inherits="nus.iss.crs.pl.Admin.CourseConfirmWF" %>
<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    <p>
        <h2>Course Confirm Process</h2>
    </p>
    <div>
        <asp:PlaceHolder runat="server" ID="PlaceHolder1" />
    </div>

   <asp:Table ID="Table1" runat="server" GridLines="Both">
        <asp:TableRow runat="server">
            <asp:TableHeaderCell ColumnSpan="2">Programe </asp:TableHeaderCell> 

            <asp:TableHeaderCell>Start Date</asp:TableHeaderCell>
            <asp:TableHeaderCell>End Date</asp:TableHeaderCell>
            <asp:TableHeaderCell>Capacity</asp:TableHeaderCell>
            <asp:TableHeaderCell>No of Participant</asp:TableHeaderCell>
            <asp:TableHeaderCell>Confirmation Status</asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell ColumnSpan="6">SOFTWARE ENGINEERING & DESIGN</asp:TableCell>                     
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell>Code</asp:TableCell>
            <asp:TableCell>Course Name</asp:TableCell>
            <asp:TableCell>Start Date</asp:TableCell>
            <asp:TableCell>End Date</asp:TableCell>
            <asp:TableCell>Capacity</asp:TableCell>
            <asp:TableCell>No of Participant</asp:TableCell> 
            <asp:TableCell>Confirmation Status</asp:TableCell> 
        </asp:TableRow>
        <asp:TableRow runat="server">
        </asp:TableRow>
        <asp:TableRow runat="server">
        </asp:TableRow>
        <asp:TableRow runat="server">
        </asp:TableRow>
    </asp:Table>
    

</asp:Content>
