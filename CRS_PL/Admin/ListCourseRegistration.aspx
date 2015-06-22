<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ListCourseRegistration.aspx.cs" Inherits="nus.iss.crs.pl.Admin.ListCourseRegistraton" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeholder_HeadContent1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="placeholder_HeadContent2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    <asp:Label ID="courseID" Text="Course Registration" runat ="server" CssClass="h4"></asp:Label>
    <asp:DropDownList ID="courseListID" runat ="server" OnSelectedIndexChanged="courseListID_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control" > </asp:DropDownList>
    <br />
    <br />
    <br />

    <div>
        <asp:PlaceHolder runat="server" ID="PlaceHolder1" />
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="placeholder_FooterContent" runat="server">
</asp:Content>
