<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryCourseList.ascx.cs" Inherits="nus.iss.crs.pl.Admin.Ctrl.CategoryCourseList" %>
<asp:Table ID="Table1" runat="server" GridLines="Both" CssClass="table">
        <asp:TableRow runat="server">
            <asp:TableHeaderCell ColumnSpan="2">Programe </asp:TableHeaderCell>
            
            <asp:TableHeaderCell>Duration</asp:TableHeaderCell>
            <asp:TableHeaderCell>Instructor</asp:TableHeaderCell>
            <asp:TableHeaderCell>Fee</asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell ColumnSpan="5"  >
                <asp:Label ID="categoryID" runat="server"></asp:Label>
              </asp:TableCell>                     
        </asp:TableRow>
       <%-- <asp:TableRow runat="server" ID="courseRowID">
            <asp:TableCell><asp:Label ID="codeID" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:Label ID="nameID" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:Label ID="durationID" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:Label ID="instructorID" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:Label ID="feeID" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell><A  href ="">Edit</A></asp:TableCell>
            <asp:TableCell><A  href ="">Delete</A></asp:TableCell>
            <asp:TableCell><A  href ="">Disable/Enable</A></asp:TableCell>             
        </asp:TableRow>--%>
         
    </asp:Table>
    

