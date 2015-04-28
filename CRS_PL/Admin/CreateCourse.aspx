<%@ Page Language="C#" MasterPageFile="~/Admin/Site.master" AutoEventWireup="true" CodeBehind="CreateCourse.aspx.cs" Inherits="nus.iss.crs.pl.Admin.CreateCourse" %>

 
<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="placeholder_MainContent">
    <h3>Course Creation </h3>
    
    <Table  id="Table1" >
        <tr>
            <td>Category</td>
            <td>
                <asp:DropDownList ID="categoryList" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Code</td>
            <td><asp:TextBox ID="TextBox100" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Title</td>
            <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Description</td>
            <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Duration</td>
            <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Fee</td>
            <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Instructor</td>
            <td> <asp:DropDownList ID="instructorList" runat="server">
                    </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2"  align="center">  
                <asp:Button  runat="server" ID="Save" Text ="Save" OnClick="Submit_Click" />&nbsp;&nbsp;  
                <asp:Button  runat="server" ID="SaveAndNext" Text ="Save and Create Next" OnClick="SaveAndNext_Click" /> 
            </td>
        </tr>
    </Table>
   
</asp:Content>