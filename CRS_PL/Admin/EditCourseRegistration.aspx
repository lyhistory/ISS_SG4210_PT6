<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="EditCourseRegistration.aspx.cs" Inherits="nus.iss.crs.pl.Admin.EditCourseRegistration" %>

<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    <blockquote>
        <h2>Edit Registration</h2>
    </blockquote>

    <Table id="Table1" class="table" >
        <tr>
            <td><h4>ID Number</h4></td>
            <td><asp:TextBox ID="idNumber" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Employment Status</h4></td>
            <td><asp:TextBox ID="employmentStatus" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
<%--        <tr>
            <td><h4>Company ID</h4></td>
            <td><asp:TextBox ID="companyID" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Company Name</h4></td>
            <td><asp:TextBox ID="companyName" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>--%>
        <tr>
            <td><h4>Company</h4></td>
            <td><asp:DropDownList ID="companyList" runat="server" CssClass="form-control">
                </asp:DropDownList>    
            </td> 
        </tr>
        <tr>
            <td><h4>Salutation</h4></td>
            <td><asp:TextBox ID="salutation" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Job Title</h4></td>
            <td><asp:TextBox ID="jobTitle" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Department</h4></td>
            <td><asp:TextBox ID="department" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Full Name</h4></td>
            <td><asp:TextBox ID="fullName" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Organization Size</h4></td>
            <td><asp:TextBox ID="organizationSize" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Gender</h4></td>
            <td><asp:DropDownList ID="genderList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Mr" Value="0"></asp:ListItem>
                <asp:ListItem Text="Miss" Value="0"></asp:ListItem>
                </asp:DropDownList>    
            </td> 
        </tr>
        <tr>
            <td><h4>Salary Range</h4></td>
            <td><asp:TextBox ID="salaryRange" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Nationality</h4></td>
            <td><asp:TextBox ID="nationality" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Date of Birth</h4></td>
            <td><asp:TextBox ID="DOB" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>EMail</h4></td>
            <td><asp:TextBox ID="email" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Contact Number</h4></td>
            <td><asp:TextBox ID="contactNumber" runat="server" CssClass="form-control" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><h4>Dietary Requirement</h4></td>
            <td><asp:TextBox ID="dietaryRequirement" runat="server" CssClass="form-control" ></asp:TextBox></td>
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

