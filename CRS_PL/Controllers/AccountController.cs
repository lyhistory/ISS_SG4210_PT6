using nus.iss.crs.bl;
using nus.iss.crs.pl.AppCode.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace nus.iss.crs.pl.Controllers
{
    public class AccountController: AuthController
    {
        //Account Center
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        public JsonResult PostResetPassword(string password,string newpassword)
        {
            var session=SessionHelper.Current;
            if (session != null)
            {
                if (session.Password.Equals(password))
                {
                    if (UserManager.ResetPassword(session.LoginID, password,newpassword))
                    {
                        session.Password = newpassword;
                        session.Status = 1;

                        var cookie = HttpContext.Request.Cookies["toPage"];
                        if (cookie != null)
                        {
                            string toPage = cookie.Value;
                            if (!string.IsNullOrEmpty(toPage) && toPage.Contains("?code="))
                            {
                                string redirectUrl = session.RoleName.ToUpper().Equals("HR") ? "/CourseRegister/HRRegister" : "/CourseRegister/IndividualRegister";
                                return Json(new { Code = 1, redirectUrl = string.Format("{0}{1}", redirectUrl, toPage) });
                            }
                        }
                        return Json(new { Code = 1 });
                    }
                }
                else
                {
                    return Json(new { Code = 0 });
                }
            }
            return Json(new { Code = -1 });
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();

            return RedirectToAction("index", "home");
        }
    }
}