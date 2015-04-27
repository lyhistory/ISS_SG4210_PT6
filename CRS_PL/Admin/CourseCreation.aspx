<%@ Page Language="C#" MasterPageFile="~/Admin/Site.master" AutoEventWireup="true" CodeBehind="CourseCreation.aspx.cs" Inherits="nus.iss.crs.pl.Admin.CourseCreation" %>

 
<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="placeholder_MainContent">
    <h2>Course Creation page</h2>
    <asp:Button  ID="Submit" Text ="Submit" OnClick="Submit_Click" />
</asp:Content>