<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ListCourse.aspx.cs" Inherits="nus.iss.crs.pl.Admin.ListCourse" %>

<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    <p>
        Executive Education Programmes
    </p>
    <asp:Table ID="Table1" runat="server" GridLines="Both">
        <asp:TableRow runat="server">
            <asp:TableHeaderCell ColumnSpan="2">Programe </asp:TableHeaderCell>
            
            <asp:TableHeaderCell>Duration</asp:TableHeaderCell>
            <asp:TableHeaderCell>Instructor</asp:TableHeaderCell>
            <asp:TableHeaderCell>Fee</asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell ColumnSpan="5">SOFTWARE ENGINEERING & DESIGN</asp:TableCell>                     
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell>Code</asp:TableCell>
            <asp:TableCell>Course Name</asp:TableCell>
            <asp:TableCell>Duration</asp:TableCell>
            <asp:TableCell>Instructor</asp:TableCell>
            <asp:TableCell>Fee</asp:TableCell>
            <asp:TableCell><A  href ="">Edit</A></asp:TableCell>
            <asp:TableCell><A  href ="">Delete</A></asp:TableCell>
            <asp:TableCell><A  href ="">Disable/Enable</A></asp:TableCell>             
        </asp:TableRow>
        <asp:TableRow runat="server">
        </asp:TableRow>
        <asp:TableRow runat="server">
        </asp:TableRow>
        <asp:TableRow runat="server">
        </asp:TableRow>
    </asp:Table>
    
</asp:Content>

