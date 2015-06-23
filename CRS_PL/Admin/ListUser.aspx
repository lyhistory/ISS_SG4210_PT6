<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ListUser.aspx.cs" Inherits="nus.iss.crs.pl.Admin.ListUser" %>

<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    <blockquote>
        <h2>User List</h2>
    </blockquote>
    
    <div>
        <form class="form-inline">
            <div class="form-group">
                <label for="SearchCondition">Condition</label>
                <asp:DropDownList CssClass="form-control" ID="UserPropertyList" runat="server"></asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="SearchValue">Value</label>
                <input type="text" class="form-control" id="SearchValue">
            </div>

            <button type="submit" class="btn btn-default" onclick="SearchUser">Search</button>
        </form>
    </div>

    <div>
        <asp:PlaceHolder runat="server" ID="PlaceHolder1" />
    </div>
</asp:Content>
