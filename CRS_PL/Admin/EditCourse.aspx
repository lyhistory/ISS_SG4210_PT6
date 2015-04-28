<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="EditCourse.aspx.cs" Inherits="nus.iss.crs.pl.Admin.EditCourse" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    
    <asp:Table ID="Table1" runat="server" Height="41px" Width="335px">
        <asp:TableRow runat="server">
            <asp:TableCell>Category</asp:TableCell>
            <asp:TableCell>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell>Code</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell>Title</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell>Description</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell>Duration</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell>Fee</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow> 
        <asp:TableRow runat="server">
            <asp:TableCell>Instructor</asp:TableCell>
            <asp:TableCell> <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
        </asp:TableRow>
    </asp:Table>
    <asp:Button  runat="server" ID="Submit" Text ="Submit" OnClick="Submit_Click" />
</asp:Content>
 