<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site.Master" CodeBehind="ViewReport.aspx.cs" Inherits="nus.iss.crs.pl.Admin.ViewReport" %>

<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
     <script language="javascript" type="text/javascript">
         $(function () {
             $('#btnSearch').click(function () {
                 var courseCode = $('#courseCode').val();
                 var date = $('#classDate').val();
                 if (courseCode == '' || date == '') {
                     alert("invalid query");
                     return false;
                 }
                 searchReport(courseCode,date);
             });
            
         });
         function searchReport(courseCode,date) {
             $.ajax({
                 type: 'post',
                 url: '/Report/SearchAttendacne',
                 data: { courseCode: courseCode, date:date  }
             }).done(function(data){
                 
                 $('#reportContent').html(data);
             });
         }
    </script>
    <blockquote>
        <h2>Attendance Report</h2>
    </blockquote>
        <div id="header">
            <label for="classCode">Class Code</label>
            <input id="courseCode" type="text"/>
            <label for="classDate">Class Date</label>
            <input id="classDate" type="date" />

            <input type="button" id="btnSearch" value="Search"/>

        </div>
        <div id="reportContainer">
            <table class="table">
                <thead>
                    <tr>
                        <td>Course Title</td>
                        <td>Class Code</td>
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
