<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="EditCourse.aspx.cs" Inherits="nus.iss.crs.pl.Admin.EditCourse" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    
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
            <td><asp:TextBox ID="codeID" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Title</td>
            <td><asp:TextBox ID="titleID" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Description</td>
            <td><asp:TextBox ID="descriptionID" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Duration</td>
            <td><asp:TextBox ID="durationID" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Fee</td>
            <td><asp:TextBox ID="feeID" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Instructor</td>
            <td> <asp:DropDownList ID="instructorList" runat="server">
                    </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2"  align="center">  
                <asp:Button  runat="server" ID="Save" Text ="Save" OnClick="Save_Click" />&nbsp;&nbsp;  
                <asp:Button  runat="server" ID="Back" Text ="Back" OnClick="Back_Click"/> 
            </td>
        </tr>
    </Table>
    
</asp:Content>
 