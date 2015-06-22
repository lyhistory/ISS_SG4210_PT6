﻿using CRS_COMMON.Logs;
using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
using nus.iss.crs.dm;
using nus.iss.crs.dm.Course;
using nus.iss.crs.pl.AppCode.Filter;
using nus.iss.crs.pl.AppCode.FormAuthentication;
using nus.iss.crs.pl.AppCode.Session;
using nus.iss.crs.pl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nus.iss.crs.pl.Controllers
{
    public class HomeController : BaseController
    {
        private static LogHelper _log = LogHelper.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            //ISession session = SessionFactory.CreateSession();
            //LogingStrategy loginStrategy = new NonLoginStrategy();

            //session.Login(loginStrategy);

            //CourseManager manager = session.CreateCourseManager();
            //List<CourseCategory> categoryList = CourseManager.GetCourseCategoryList(DateTime.Now, DateTime.Now.AddMonths(5), true);

            return View();
        }

        CourseManager manager = null;//new CourseManager();

        public JsonResult GetCourseCategoryList(string searchText = "")
        {
            
            List<CourseCategory> categoryList = manager.GetCourseCategoryList(DateTime.Now, DateTime.Now.AddMonths(5), true);

            return Json(new { Data = categoryList });
        }

        public ActionResult CourseDetail(string code)
        {
            var model = manager.GetCourseByCode(code);
            return View(model);
        }


        [CRSAuthorize(Roles = "HR")]
        public ActionResult About()
        {
            _log.Debug("test about");
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [CRSAuthorize(Roles="Individual")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region Login&Register
        public ActionResult Logon(string message="",string toPage="")
        {
            ViewBag.Message = message;

            if (toPage.Contains("?code="))
            {
                HttpContext.Response.SetCookie(new HttpCookie("toPage", toPage));
            }

            return View();
        }
        [HttpPost]
        public JsonResult PostLogon(string loginID,string password,string loginType)
        {
            bool result = false;
            string userType = string.Empty;
            int userStatus = 0;
            if (loginType.Equals("staff", StringComparison.OrdinalIgnoreCase))
            {
                //do staff login,redirect to back office
            }
            else
            {
                //do user login

                nus.iss.crs.dm.User loginUser = UserManager.LoginUser(loginID, password); //new nus.iss.crs.dm.User() { UserID = "test", Password = "1111", Email = "", RoleName = "HR" };
                if (loginUser != null)
                {
                    if (loginUser.RoleName.ToUpper().Equals("HR"))
                    {
                        var companyhr = UserManager.GetCompanyHRByLoginID(loginUser.LoginID);
                        if (companyhr != null)
                            loginUser.CompanyID = companyhr.CompanyID;
                    }
                    SessionHelper.SetSession(loginUser);
                    CRSFormsAuthentication<User>.SetAuthCookie(loginUser.LoginID, loginUser, true);
                    userType = loginUser.RoleName;
                    userStatus = loginUser.Status;
                    result = true;
                }
            }
            if (result)
            {
                if (!string.IsNullOrEmpty(userType))
                {
                    if (userStatus == 0)
                    {
                        return Json(new { Code = 1, redirectUrl = "/Account/ResetPassword" });
                    }
                    else
                    {
                        var cookie = HttpContext.Request.Cookies["toPage"];
                        if (cookie != null)
                        {
                            string toPage = cookie.Value;
                            //delete cookie after use
                            HttpContext.Response.Cookies.Remove("toPage");
                            if (!string.IsNullOrEmpty(toPage) && toPage.Contains("?code="))
                            {
                                string redirectUrl = userType.ToUpper().Equals("HR") ? "/CourseRegister/HRRegister" : "/CourseRegister/IndividualRegister";
                                return Json(new { Code = 1, redirectUrl = string.Format("{0}{1}", redirectUrl, toPage) });
                            }
                        }
                    }
                }
            }
            else
            {
                return Json(new { Code = -1 });
            }    
            

            return Json(new{Code=1});
        }

        public ViewResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult PostRegister(UserRegisterForm form)
        {
            if (this.ModelState.IsValid)
            {
                //log
            }
            if (!form.Password.Equals(form.ConfirmPassword))
            {
                return Json(new { Code = -1, Message = "Password not the same" });
            }
            User user=UserManager.GetHRUserByLoginID(form.LoginID);
            if(user!=null)
                return Json(new { Code = -1, Message = "User already exsits!" });
            user = new dm.User();
            bool createCompany = false;
            Company company = UserManager.GetCompanyByUEN(form.CompanyUEN);
            if (company == null)
            {
                company = new Company()
                {
                    CompanyName = form.CompanyName,
                    CompanyUEN = form.CompanyUEN,
                    OrganizationSize = form.OrganizationSize,
                    CompanyAddress = form.CompanyAddress,
                    Country = form.Country,
                    PostalCode = form.PostalCode
                };
                createCompany = UserManager.CreateCompany(company);
                //log if fail
            }
            
            user.CompanyID = company.CompanyID;
            user.Email=form.LoginID;
            user.Name = form.Name;
            user.ContactNumber = form.ContactNumber;
            user.JobTitle = form.JobTitle;
            user.FaxNumber = form.FaxNumber;
            user.Password = form.Password;
            user.LoginID = form.LoginID;
            user.RoleName = "HR";
            user.Status = 1;

            bool result = createCompany ? UserManager.CreateHRUser(user, company) : UserManager.CreateHRUser(user);

            if (result)
            {
                user.CompanyID = company.CompanyID;
                SessionHelper.SetSession(user);
                CRSFormsAuthentication<User>.SetAuthCookie(user.LoginID, user, true);
                return Json(new { Code = 1, Message = "" });
            }
            else
                return Json(new { Code = -1, Message = "Register failed!" });
        }
        #endregion

        public ActionResult Unauthorized()
        {
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public JsonResult PostForgetPassword(string usertype,string loginID,string email)
        {
            // ADD USER TYPE SUP
            User user = null;
            if (usertype.Equals("1"))
            {
                user=UserManager.GetIndividualUserByIDNumber(loginID);
            }
            else
            {
                user=UserManager.GetHRUserByLoginID(loginID);
            }
            //user=UserManager.GetHRUserByLoginID()
            if (user == null)
            {
                return Json(new { Code = -1, Message = "user not exists!" });
            }
            _log.Debug(string.Format("Send Email: userid:{0},password:{1}", user.LoginID, user.Password));
            return Json(new { Code = 1, Message = "please check your email" });
        }
    }
}