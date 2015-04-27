using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nus.iss.crs.pl.Controllers
{
    public class HRController : BaseController
    {
        public ActionResult CourseRegistration()
        {
            return View();
        }
    }
}