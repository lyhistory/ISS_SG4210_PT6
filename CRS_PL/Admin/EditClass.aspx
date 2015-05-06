<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="EditClass.aspx.cs" Inherits="nus.iss.crs.pl.Admin.EditClass" %>

<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    
   
    <Table  id="Table1" >
        <tr>
            <td>Category</td>
            <td>
                <asp:Label ID="categoryNameID" runat ="server"></asp:Label>               
            </td>
        </tr>
        <tr>
            <td>Course</td>
            <td>
                 <asp:Label ID="courseTitleID" runat ="server"></asp:Label>    
            </td>
        </tr>
        <tr>
            <td>Class Code</td>
            <td><asp:TextBox ID="classID" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Size</td>
            <td><asp:TextBox ID="sizeID" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Start Date</td>
            <td><asp:TextBox ID="startDateID" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>End Date</td>
            <td><asp:TextBox ID="endDateID" runat="server"></asp:TextBox></td>
        </tr>  
        <tr>
            <td colspan="2"  align="center">  
                <asp:Button  runat="server" ID="Save" Text ="Save" OnClick="Save_Click" />&nbsp;&nbsp;  
                <asp:Button  runat="server" ID="Back" Text ="Back" OnClick="Back_Click"/> 
            </td>
        </tr>
    </Table>
   
</asp:Content>
 
