<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="EditClass.aspx.cs" Inherits="nus.iss.crs.pl.Admin.EditClass" %>

<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    
   
    <Table id="Table1" class="table" >
        <tr>
            <td><h4>Category</h4></td>
            <td>
                <asp:Label ID="categoryNameID" runat ="server" CssClass="form-control" ></asp:Label>               
            </td>
        </tr>
        <tr>
            <td><h4>Course</h4></td>
            <td>
                 <asp:Label ID="courseTitleID" runat ="server" CssClass="form-control" ></asp:Label>    
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
                <asp:Button  runat="server" ID="Save" Text ="Save" OnClick="Save_Click" CssClass="btn btn-primary" />
                &nbsp;&nbsp;  
                <asp:Button  runat="server" ID="Back" Text ="Back" OnClick="Back_Click" CssClass="btn btn-primary" /> 
            </td>
        </tr>
    </Table>
   
</asp:Content>
 
