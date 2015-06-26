using nus.iss.crs.bl;
using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nus.iss.crs.pl.Controllers
{
    public class ReportController : AuthController
    {
        ReportManager manager = null;

        public ReportController()
        {
            manager = new ReportManager(BLSession);
        }
        // GET: Report
        public ActionResult SearchAttendacne(string courseCode,string date)
        {
            DateTime datetime;
            if (string.IsNullOrEmpty(date))
            {
                return Content("<td colspan=6>Invalid Query</td>");
            }
            List<ParticipantAttendance> list=null;
            if (!DateTime.TryParse(date, out datetime))
            {
                list = manager.GetUserAttendancesByCourseCode(courseCode);
            }
            else
            {
                list = manager.GetUserAttendancesByCourseCode(courseCode, datetime);
            }
            return View("~/views/report/_AttendanceReport.cshtml", list);
        }
    }
}