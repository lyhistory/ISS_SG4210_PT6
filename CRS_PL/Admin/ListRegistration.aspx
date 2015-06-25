<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ListRegistration.aspx.cs" Inherits="nus.iss.crs.pl.Admin.ListRegistration" %>
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
                <asp:DropDownList CssClass="form-control" ID="searchConditionList" runat="server">
                    <asp:ListItem Text ="Participant Name" Value="0"></asp:ListItem>
                    <asp:ListItem Text ="Participant ID" Value="1"></asp:ListItem>
                    <asp:ListItem Text ="Company Name" Value="2"></asp:ListItem>
                </asp:DropDownList>
                
            </div>

            <div class="form-group">
                <label for="SearchValue">Search Value</label>
                <asp:TextBox ID="searchValue" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="SearchRegistration" runat="server" Text="Search" CssClass="btn btn-default" OnClick="SearchRegistration_Click" />
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
                <asp:TableHeaderCell>Course Code</asp:TableHeaderCell>
                <asp:TableHeaderCell>Course Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Class Code</asp:TableHeaderCell>
                <asp:TableHeaderCell>Start Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>End Date</asp:TableHeaderCell>
                <asp:TableHeaderCell ColumnSpan="3">Operation</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
    </div>

    <script type="text/javascript">
        function ChangeRegistrationStatus(btn) {
            if (confirm('Are you sure ?')) {
                //clicked the OK button.  
                var registrationID = btn.ToolTip
                __doPostBack('ChangeRegistrationStatus', registrationID);
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>

