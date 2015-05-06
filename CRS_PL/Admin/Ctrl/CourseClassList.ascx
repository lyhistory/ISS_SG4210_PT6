<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseClassList.ascx.cs" Inherits="nus.iss.crs.pl.Admin.Ctrl.CourseClassList" %>
<asp:Table ID="Table1" runat="server" GridLines="Both">
        <asp:TableRow runat="server">
            <asp:TableHeaderCell ColumnSpan="1" Wrap="false" Width="300">Class ID </asp:TableHeaderCell>            
            <asp:TableHeaderCell Wrap="false" Width="50">Size</asp:TableHeaderCell>
            <asp:TableHeaderCell Wrap="false" Width="500">Start Date</asp:TableHeaderCell>
            <asp:TableHeaderCell Wrap="false" Width="500">End Date</asp:TableHeaderCell>
            <asp:TableHeaderCell ColumnSpan ="4" Width="300">Operation</asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell   >
                <asp:Label ID="courseID" runat="server"></asp:Label>
              </asp:TableCell>   
            <asp:TableCell ColumnSpan="7"  >
                <asp:Label ID="courseTitle" runat="server"></asp:Label>
              </asp:TableCell>                   
        </asp:TableRow>
        <%--<asp:TableRow runat="server" ID="classRowID">
            <asp:TableCell><asp:Label ID="classID" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:Label ID="sizeID" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:Label ID="startDateID" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:Label ID="endDateID" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell><A  href ="">Edit</A></asp:TableCell>
            <asp:TableCell><A  href ="">Open/Close</A></asp:TableCell>
            <asp:TableCell><A  href ="">Confirm</A></asp:TableCell>             
            <asp:TableCell><A  href ="">Cancel</A></asp:TableCell>             
        </asp:TableRow>--%>
         
    </asp:Table>
    