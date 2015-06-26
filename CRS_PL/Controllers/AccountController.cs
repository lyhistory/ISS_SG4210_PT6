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
         UserManager manager = null;

         public AccountController()
        {
            manager = new UserManager(BLSession);
        }


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
            string usertype = string.Empty;
            if (session.RoleName.ToUpper().Equals("SYSTEM") || session.RoleName.ToUpper().Equals("COURSE"))
            {
                usertype = "STAFF";
            }
            else
            {
                usertype = "USER";
            }

            if (session != null)
            {
                if (session.Password.Equals(password))
                {
                    if (manager.ResetPassword(usertype,session.LoginID, password, newpassword))
                    {
                        session.Password = newpassword;
                        session.Status = 1;


                        if (usertype.Equals("STAFF"))
                        {
                            return Json(new { Code = 1, redirectUrl = "../Admin/AdminHome.aspx" });
                        }

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
            //Session.Abandon();
            SessionHelper.ReleaseSession();
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "home");
        }
    }
}