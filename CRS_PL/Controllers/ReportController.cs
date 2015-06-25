using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nus.iss.crs.pl.Controllers
{
    public class ReportController : AuthController
    {
        // GET: Report
        public ActionResult SearchAttendacne(string classCode,string date)
        {
            DateTime datetime;

            return Content("<tr><td>hi</td></tr>");
        }
    }
}