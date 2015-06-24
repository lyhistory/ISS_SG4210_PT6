<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ListClassInCalendar.aspx.cs" Inherits="nus.iss.crs.pl.Admin.ListCourseInCalendar" %>

<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    <div>
        <form class="form-inline">
            <div class="form-group">
                <h4>Start Date
                </h4>
                
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-horizontal" OnTextChanged="txtStartDate_TextChanged"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" />
                <asp:Calendar ID="CalStartDate" runat="server"></asp:Calendar>
            </div>

            <div class="form-group">
                <h4>End Date</h4>
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-horizontal"></asp:TextBox>
                <asp:ImageButton ID="ImageButton2" runat="server" />
                <asp:Calendar ID="CalEndDate" runat="server"></asp:Calendar>
                
            </div>

            <button type="submit" class="btn btn-default" onclick="SearchClass">Search</button>
        </form>
    </div>
    
    <div>
        <asp:PlaceHolder runat="server" ID="PlaceHolder1" />
    </div>
</asp:Content>

