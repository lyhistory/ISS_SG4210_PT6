<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="CreateClass.aspx.cs" Inherits="nus.iss.crs.pl.Admin.ClassCreation" %>

 
<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="placeholder_MainContent">
    <h3>Class Creation </h3>
    
    <Table  id="Table1" >
        <tr>
            <td>Category</td>
            <td>
                <asp:DropDownList ID="categoryListID" runat="server" OnSelectedIndexChanged="categoryList_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Course</td>
            <td>
                <asp:DropDownList ID="courseListID" runat="server" OnSelectedIndexChanged="courseList_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
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
                <asp:Button  runat="server" ID="Save" Text ="Save" OnClick="Submit_Click" />&nbsp;&nbsp;  
                <asp:Button  runat="server" ID="SaveAndNext" Text ="Save and Create Next" OnClick="SaveAndNext_Click" /> 
            </td>
        </tr>
    </Table>
   
</asp:Content>