<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="CreateClass.aspx.cs" Inherits="nus.iss.crs.pl.Admin.ClassCreation" %>

 
<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="placeholder_MainContent">
    <h1>Class Creation </h1>
    
    <Table id="Table1" class="table">
        <tr>
            <td><h4>Category</h4></td>
            <td>
                <asp:DropDownList ID="categoryListID" runat="server" OnSelectedIndexChanged="categoryList_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><h4>Course</h4></td>
            <td>
                <asp:DropDownList ID="courseListID" runat="server" CssClass="form-control" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><h4>Class Code</h4></td>
            <td><asp:TextBox ID="classID" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Size</h4></td>
            <td><asp:TextBox ID="sizeID" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Start Date</h4></td>
            <td><asp:TextBox ID="startDateID" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>End Date</h4></td>
            <td><asp:TextBox ID="endDateID" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>  
        <tr>
            <td colspan="2"  align="center">  
                <asp:Button runat="server" ID="Save" Text ="Save" OnClick="Submit_Click" CssClass="btn btn-primary" />
                &nbsp;&nbsp;  
                <asp:Button runat="server" ID="SaveAndNext" Text ="Save and Create Next" OnClick="SaveAndNext_Click" CssClass="btn btn-primary" /> 
            </td>
        </tr>
    </Table>
   
</asp:Content>