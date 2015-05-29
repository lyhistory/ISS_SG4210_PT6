using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nus.iss.crs.dm;
using nus.iss.crs.pl.AppCode.Session;

namespace nus.iss.crs.pl.Controllers
{
    public class AuthController : BaseController
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool afterLogin = false;
            string userType = string.Empty;
            string userName = string.Empty;
            User session = SessionHelper.Current;

            if (session == null)
            {
                filterContext.Result = Kickout(filterContext.HttpContext.Request.IsAjaxRequest());
            }
            else
            {
                afterLogin = true;
                userType = session.RoleName.ToUpper();
                userName = session.Name;
            }

            ViewBag.AfterLogin = afterLogin;
            ViewBag.UserType = userType;
            ViewBag.UserName = userName;

            base.OnAuthorization(filterContext);
        }
    }
}