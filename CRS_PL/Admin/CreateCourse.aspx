<%@ Page Language="C#" MasterPageFile="~/Admin/Site.master" AutoEventWireup="true" CodeBehind="CreateCourse.aspx.cs" Inherits="nus.iss.crs.pl.Admin.CourseCreation" %>

 
<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="placeholder_MainContent">
    <h3>Course Creation </h3>
    
    <asp:Table ID="Table1" runat="server" Height="41px" Width="493px">
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
            <asp:TableCell ColumnSpan ="2" HorizontalAlign="Center">  
                <asp:Button  runat="server" ID="Save" Text ="Save" OnClick="Submit_Click" />  
                <asp:Button  runat="server" ID="SaveAndNext" Text ="Save and Create Next" OnClick="Submit_Click" /> 
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
   
</asp:Content>