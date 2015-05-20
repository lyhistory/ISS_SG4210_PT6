using nus.iss.crs.pl.AppCode.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nus.iss.crs.dm;
using System.Web.Security;
/*
 *AUTHOR: LIU YUE
 * */
namespace nus.iss.crs.pl.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool afterLogin = false;
            User session = SessionHelper.Current;

            if (session != null)
            {
                afterLogin = true;
            }

            ViewBag.AfterLogin = afterLogin;

            base.OnAuthorization(filterContext);
        }

        protected ActionResult Kickout(bool isAjaxRequest)
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();

            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = 403;

            if (isAjaxRequest)
            {
                return Json(new { SessionLost = true, Message = "Session Lost" }, JsonRequestBehavior.AllowGet);
            }

            return RedirectToAction("logon", "home", new { Message = "Session Lost" });
        }
	}
}