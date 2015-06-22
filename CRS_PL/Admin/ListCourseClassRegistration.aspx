<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ListCourseClassRegistration.aspx.cs" Inherits="nus.iss.crs.pl.Admin.ListCourseClassRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeholder_HeadContent1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="placeholder_HeadContent2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    <h4>Category</h4>
    <asp:DropDownList ID="categoryListID" runat ="server" OnSelectedIndexChanged="categoryListID_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control" > </asp:DropDownList>
    <h4>Course</h4>
    <asp:DropDownList ID="courseListID" runat ="server" OnSelectedIndexChanged="courseListID_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control" > </asp:DropDownList>
    <h4>Class</h4>
    <asp:DropDownList ID="classListID" runat ="server" OnSelectedIndexChanged="classListID_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control" > </asp:DropDownList>
    <br />
    <br />
    <br />
    <br />

    <div>
        <asp:PlaceHolder runat="server" ID="PlaceHolder1" />
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="placeholder_FooterContent" runat="server">
</asp:Content>
