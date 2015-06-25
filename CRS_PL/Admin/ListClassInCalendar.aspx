<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" EnableEventValidation="false"  AutoEventWireup="true" CodeBehind="ListClassInCalendar.aspx.cs" Inherits="nus.iss.crs.pl.Admin.ListCourseInCalendar" %>

<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div>
                <label for="CourseList">Course List</label>
                <asp:DropDownList ID="courseListID" runat ="server" CssClass="form-control" > </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="StartDate">Start Date(yyyy-mm-dd)</label>
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control"></asp:TextBox>
                <%--<asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" Height="18px" ImageUrl="~/Images/Calendar.png" Width="25px" />
                <asp:Calendar ID="CalStartDate" runat="server"></asp:Calendar>--%>
            </div>

            <div class="form-group">
                <label for="EndDate">End Date(yyyy-mm-dd)</label>
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control"></asp:TextBox>
                <%--<asp:ImageButton ID="ImageButton2" runat="server" OnClick="ImageButton2_Click" Height="16px" ImageUrl="~/Images/Calendar.png" Width="23px" />
                <asp:Calendar ID="CalEndDate" runat="server"></asp:Calendar>--%>
            </div>
            <asp:Button ID="SearchClass" runat="server" Text="Search" CssClass="btn btn-default" OnClick="SearchClass_Click" />
        </div>
    </div>
    <br />
    <br />
    <br />
    <div>
        <asp:PlaceHolder runat="server" ID="PlaceHolder1" />
    </div>
</asp:Content>

