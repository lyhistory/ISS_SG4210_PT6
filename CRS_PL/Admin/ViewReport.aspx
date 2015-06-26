<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site.Master" CodeBehind="ViewReport.aspx.cs" Inherits="nus.iss.crs.pl.Admin.ViewReport" %>

<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
     <script language="javascript" type="text/javascript">
         $(function () {
             $('#btnSearch').click(function () {
                 searchReport('ACD');
             });
            
         });
         function searchReport(courseCode) {
             $.ajax({
                 type: 'post',
                 url: '/Report/SearchAttendacne',
                 data: { courseCode: courseCode, date: $('#classDate').val() }
             }).done(function(data){
                 
                 $('#reportContent').html(data);
             });
         }
    </script>
    <blockquote>
        <h2>Attendance Report</h2>
    </blockquote>
        <div id="header">

            <input id="classDate" type="date" />

            <input type="button" id="btnSearch" value="Search"/>

        </div>
        <div id="reportContainer">
            <table>
                <thead>
                    <tr>
                        <td>Course Title</td>
                        <td>Participant IdNumber</td>
                        <td>Participant CompanyID</td>
                        <td>Participant FullName</td>
                        <td>Attendance Date</td>
                        <td>Attendance Status</td>
                    </tr>
                </thead>
                <tbody id="reportContent">

                </tbody>
            </table>
        </div>
</asp:Content>
