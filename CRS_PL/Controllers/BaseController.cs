﻿using nus.iss.crs.pl.AppCode.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nus.iss.crs.dm;
using System.Web.Security;
using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
/*
 *AUTHOR: LIU YUE
 * */
namespace nus.iss.crs.pl.Controllers
{
    public class BaseController : Controller
    {
        protected ISession BLSession  = SessionHelper.BLSession;

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool afterLogin = false;
            string userType = string.Empty;
            string userName = string.Empty;
            User session = SessionHelper.Current;

            if (session != null)
            {
                afterLogin = true;
                userType = session.RoleName.ToUpper();
                userName = session.LoginID;
            }

            ViewBag.AfterLogin = afterLogin;
            ViewBag.UserType = userType;
            ViewBag.UserName = userName;

            base.OnAuthorization(filterContext);
        }

        protected ActionResult Kickout(bool isAjaxRequest)
        {
            SessionHelper.ReleaseSession();
             
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