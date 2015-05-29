using nus.iss.crs.bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nus.iss.crs.pl.Controllers
{
    public class CourseRegisterController : BaseController
    {
        // GET: CourseRegister
        public ActionResult IndividualReigster(string code)
        {
            var model = CourseManager.GetCourseByCode(code);
            return View(model);
        }

        public JsonResult PostIndividualReigster()
        {
            //if not login 
            //auto register
            //if exists ask him to login!
            //string toPage = "?code="+code;
            //return Json(new { Code = -1, toPage = toPage) });
            return Json(new { Code = -1 });
        }

        public ActionResult HRRegister(string code)
        {
            var model = CourseManager.GetCourseByCode(code);
            return View(model);
        }

        public JsonResult PostHRRegister()
        {

            return Json(new { Code = -1 });
        }
    }
}