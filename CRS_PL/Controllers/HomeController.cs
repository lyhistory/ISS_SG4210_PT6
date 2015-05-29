using CRS_COMMON.Logs;
using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
using nus.iss.crs.dm;
using nus.iss.crs.dm.Course;
using nus.iss.crs.pl.AppCode.Filter;
using nus.iss.crs.pl.AppCode.FormAuthentication;
using nus.iss.crs.pl.AppCode.Session;
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

        public JsonResult GetCourseCategoryList(string searchText = "")
        {
            List<CourseCategory> categoryList = CourseManager.GetCourseCategoryList(DateTime.Now, DateTime.Now.AddMonths(5), true);

            return Json(new { Data = categoryList });
        }

        public ActionResult CourseDetail(string code)
        {
            var model = CourseManager.GetCourseByCode(code);
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
                    SessionHelper.SetSession(loginUser);
                    CRSFormsAuthentication<User>.SetAuthCookie(loginUser.UserID, loginUser, true);
                    userType = loginUser.RoleName;
                    result = true;
                }
            }
            if (result)
            {
                var cookie = HttpContext.Request.Cookies["toPage"];
                if (cookie != null)
                {
                    string toPage = cookie.Value;
                    if (!string.IsNullOrEmpty(toPage) && toPage.Contains("?code="))
                    {
                        string redirectUrl = userType.ToUpper().Equals("HR") ? "/CourseRegister/HRRegister" : "/CourseRegister/IndividualReigster";
                        return Json(new { Code = 1, redirectUrl = string.Format("{0}{1}",redirectUrl,toPage)});
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
        #endregion

        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}