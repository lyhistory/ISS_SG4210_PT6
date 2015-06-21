<%@ Page Language="C#" MasterPageFile="~/Admin/Site.master" AutoEventWireup="true" CodeBehind="CreateCourse.aspx.cs" Inherits="nus.iss.crs.pl.Admin.CreateCourse" %>

 
<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="placeholder_MainContent">
    <h1>Course Creation </h1>
    
    <Table id="Table1" class="table" >
        <tr>
            <td><h4>Category</h4></td>
            <td>
                <asp:DropDownList ID="categoryList" runat="server" CssClass="form-control" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><h4>Code</h4></td>
            <td><asp:TextBox ID="codeID" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Title</h4></td>
            <td><asp:TextBox ID="titleID" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Description</h4></td>
            <td><asp:TextBox ID="descriptionID" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Duration</h4></td>
            <td><asp:TextBox ID="durationID" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Fee</h4></td>
            <td><asp:TextBox ID="feeID" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Instructor</h4></td>
            <td> <asp:DropDownList ID="instructorList" runat="server" CssClass="form-control" >
                    </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2"  align="center">  
                <asp:Button  runat="server" ID="Save" Text ="Save" OnClick="Submit_Click" CssClass="btn btn-primary" />
                &nbsp;&nbsp;  
                <asp:Button  runat="server" ID="SaveAndNext" Text ="Save and Create Next" OnClick="SaveAndNext_Click" CssClass="btn btn-primary" /> 
            </td>
        </tr>
    </Table>
   
</asp:Content>