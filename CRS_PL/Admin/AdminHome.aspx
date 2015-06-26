<%@ Page Language="C#" MasterPageFile="~/Admin/Site.master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="nus.iss.crs.pl.Admin.AdminHome" %>

 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeholder_HeadContent1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="placeholder_HeadContent2" runat="server">
    <asp:HyperLink ID="AccountCenter" runat="server" NavigateUrl="/Account/Center" class="btn btn-primary btn-lg active">Account Center</asp:HyperLink>
</asp:Content>
<%--<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_LeftMenu" runat="server">
</asp:Content>--%>
<asp:Content ID="Content5" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    <h1 class="active">Admin Home Page</h1>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="placeholder_FooterContent" runat="server">
</asp:Content>