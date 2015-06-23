<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ListRegistration.aspx.cs" Inherits="nus.iss.crs.pl.Admin.ListCourseClassRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeholder_HeadContent1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="placeholder_HeadContent2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    <h2>Registration List</h2>
    <div>
        <form class="form-inline">
            <div class="form-group">
                <label for="SearchCondition">Search Condition</label>
                <asp:DropDownList CssClass="form-control" ID="UserPropertyList" runat="server"></asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="SearchValue">Search Value</label>
                <input type="text" class="form-control" id="SearchValue">
            </div>

            <button type="submit" class="btn btn-default" onclick="SearchUser">Search</button>
        </form>
    </div>
    <br />
    <br />
    <br />
    <br />

    <div>
        <asp:Table ID="Table1" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableHeaderCell>Full Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Company Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                <asp:TableHeaderCell>Course Code</asp:TableHeaderCell>
                <asp:TableHeaderCell>Course Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Class Code</asp:TableHeaderCell>
                <asp:TableHeaderCell>Start Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>End Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>Active</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="placeholder_FooterContent" runat="server">
</asp:Content>
