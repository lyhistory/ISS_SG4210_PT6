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

        public ActionResult CourseClassRegistration(){
            return View();
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
        public ActionResult Logon(string message="")
        {
            ViewBag.Message = message;

            if (SessionHelper.Current != null)
            {
                ViewBag.isLogon = true;
                string redirectUrl = Request.UrlReferrer.AbsoluteUri;
                if (redirectUrl.ToLower().Contains("home/courseclassregistration"))
                {
                    HttpContext.Response.SetCookie(new HttpCookie("redirectUrl", redirectUrl));
                }
            }
            else
            {
                ViewBag.isLogon = false;
            }

            return View();
        }
        [HttpPost]
        public JsonResult PostLogon(string loginID,string password,string loginType)
        {
            bool result = false;
            if (loginType.Equals("staff", StringComparison.OrdinalIgnoreCase))
            {
                //do staff login
            }
            else
            {
                //do user login
                nus.iss.crs.dm.User loginUser = new nus.iss.crs.dm.User() { UserID = "test", Password = "1111", Email = "", RoleName = "HR" };
                loginUser.GetRole();
                if (loginUser != null)
                {
                    SessionHelper.SetSession(loginUser);
                    CRSFormsAuthentication<User>.SetAuthCookie(loginUser.UserID, loginUser, true);
                    result = true;
                }
            }
            if (result)
            {
                var cookie = HttpContext.Request.Cookies["redirectUrl"];
                if (cookie != null)
                {
                    string redirectUrl = cookie.Value;
                    if (string.IsNullOrEmpty(redirectUrl))
                    {
                        return Json(new { Code = 1, redirectUrl = redirectUrl });
                    }
                }
            }
            else
            {
                return Json(new { Code = -1 });
            }    
            

            return Json(new{Code=1});
        }
        #endregion

        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}