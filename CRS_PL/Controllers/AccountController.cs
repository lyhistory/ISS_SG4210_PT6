using nus.iss.crs.bl;
using nus.iss.crs.pl.AppCode.Session;
using nus.iss.crs.pl.Models;
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

        public JsonResult PostResetPassword(ResetPasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                //log
            }
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
                if (session.Password.Equals(model.OldPassword))
                {
                    if (manager.ResetPassword(usertype,session.LoginID, model.OldPassword, model.NewPassword))
                    {
                        session.Password = model.NewPassword;
                        session.Status = 1;


                        if (usertype.Equals("STAFF"))
                        {
                            return Json(new { Code = 1, redirectUrl = "/Account/Center" });//"../Admin/AdminHome.aspx" });
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
                    return Json(new { Code = 0});
                }
            }
            return Json(new { Code = -1 });
        }

        public ActionResult Center()
        {
            return View();
        }
        public ActionResult GetCourseAdminList()
        {
            var list=manager.GetCourseAdminList();
            if (list == null)
                return Content("<tr><td colspan='5'>No Data found.</td></tr>");
            return View("~/views/account/_StaffTemplate.cshtml", list);
        }
        public ActionResult EditCourseAdmin()
        {
            return View();
        }
        public ActionResult CreateCourseAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostCreateCourseAdmin(CourseAdminViewModel model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    //log
                }

                bool result = manager.CreateStaff(new dm.User()
                {
                    LoginID = model.LoginID,
                    Password = model.Password,
                    Enabled = model.Enabled ? 1 : 0,
                    RoleName = "COURSE"
                });
                if (result)
                    return Json(new { Code = 1 });
            }
            catch { }
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