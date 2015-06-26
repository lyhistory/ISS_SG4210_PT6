using CRS_COMMON.Logs;
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

        UserManager manager = null;

        public HomeController()
        {
            manager = new UserManager(BLSession);
        }

        #region CourseCatalogue and Details
        public ActionResult Index()
        {
            //ISession session = SessionFactory.CreateSession();
            //LogingStrategy loginStrategy = new NonLoginStrategy();

            //session.Login(loginStrategy);

            //CourseManager manager = session.CreateCourseManager();
            //List<CourseCategory> categoryList = CourseManager.GetCourseCategoryList(DateTime.Now, DateTime.Now.AddMonths(5), true);

            if (SessionHelper.Current != null)
            {
                if (SessionHelper.Current.RoleName.ToUpper().Equals("SYSTEM") || SessionHelper.Current.RoleName.ToUpper().Equals("COURSE"))
                {
                    return Redirect("/Admin/AdminHome.aspx");
                }
            }

            return View();
        }

        public JsonResult GetCourseCategoryList(string searchText = "")
        {
            CourseManager manager = this.BLSession.CreateCourseManager();

            List<CourseCategory> categoryList = manager.GetCourseCategoryList(DateTime.Now, DateTime.Now.AddMonths(5), true, searchText);

            return Json(new { Data = categoryList });
        }

        public ActionResult CourseDetail(string code)
        {
            CourseManager manager = this.BLSession.CreateCourseManager();
            var model = manager.GetCourseByCode(code);
            return View(model);
        }

        #endregion

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
            User loginUser = null;

            if (loginType.Equals("staff", StringComparison.OrdinalIgnoreCase))
            {
                //do staff login,redirect to back office
                loginUser = manager.LoginStaff(loginID, password);
                if (loginUser.Enabled < 1)
                {
                    return Json(new { Code = -2 }); 
                }
            }
            else
            {
                //do user login
                loginUser = manager.LoginUser(loginID, password); //new nus.iss.crs.dm.User() { UserID = "test", Password = "1111", Email = "", RoleName = "HR" };    
            }
            if (loginUser != null)
            {
                if (loginUser.RoleName.ToUpper().Equals("HR"))
                {
                    var companyhr = manager.GetCompanyHRByLoginID(loginUser.LoginID);

                    if (companyhr != null)
                    {
                        loginUser.CompanyID = companyhr.CompanyID;
                        var company = manager.GetCompanyByID(companyhr.CompanyID);
                        loginUser.CompanyName = company.CompanyName;
                    }
                }
                SessionHelper.SetSession(loginUser);
                CRSFormsAuthentication<User>.SetAuthCookie(loginUser.LoginID, loginUser, true);
                userType = loginUser.RoleName;
                userStatus = loginUser.Status;
                result = true;
            }
            if (result)
            {
                if (!string.IsNullOrEmpty(userType))
                {
                    if (userStatus == 0)
                    {
                        return Json(new { Code = 1, redirectUrl = "/Account/ResetPassword" });
                    }
                    if (loginType.Equals("user", StringComparison.OrdinalIgnoreCase))
                    {
                        var cookie = HttpContext.Request.Cookies["toPage"];
                        if (cookie != null)
                        {
                            string toPage = cookie.Value;
                            //delete cookie after use
                            if (cookie != null)
                            {
                                //delete cookie after use
                                HttpCookie currentUserCookie = HttpContext.Request.Cookies["toPage"];
                                HttpContext.Response.Cookies.Remove("toPage");
                                currentUserCookie.Expires = DateTime.Now.AddDays(-10);
                                currentUserCookie.Value = null;
                                HttpContext.Response.SetCookie(currentUserCookie);
                            }
                            if (!string.IsNullOrEmpty(toPage) && toPage.Contains("?code="))
                            {
                                string redirectUrl = userType.ToUpper().Equals("HR") ? "/CourseRegister/HRRegister" : "/CourseRegister/IndividualRegister";
                                return Json(new { Code = 1, redirectUrl = string.Format("{0}{1}", redirectUrl, toPage) });
                            }
                        }
                    }
                    else
                    {
                        return Json(new { Code = 1, redirectUrl = "../Admin/AdminHome.aspx" });
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
            User user = manager.GetHRUserByLoginID(form.LoginID);
            if(user!=null)
                return Json(new { Code = -1, Message = "User already exsits!" });
            user = new dm.User();
            bool createCompany = false;
            Company_DM company = manager.GetCompanyByUEN(form.CompanyUEN);
            if (company == null)
            {
                company = new Company_DM()
                {
                    CompanyName = form.CompanyName,
                    CompanyUEN = form.CompanyUEN,
                    OrganizationSize = form.OrganizationSize,
                    CompanyAddress = form.CompanyAddress,
                    Country = form.Country,
                    PostalCode = form.PostalCode
                };
                createCompany = manager.CreateCompany(company);
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

            bool result = createCompany ? manager.CreateHRUser(user, company) : manager.CreateHRUser(user);

            if (result)
            {
                user.CompanyID = company.CompanyID;
                user.CompanyName = company.CompanyName;
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
                user = manager.GetIndividualUserByIDNumber(loginID);
            }
            else
            {
                user = manager.GetHRUserByLoginID(loginID);
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