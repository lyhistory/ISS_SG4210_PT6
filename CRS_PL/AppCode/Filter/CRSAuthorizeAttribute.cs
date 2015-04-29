using CRS_COMMON.Security.FormAuthentication;
using nus.iss.crs.dm;
using nus.iss.crs.pl.AppCode.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
/*
 * Author:LIU YUE
 * */
namespace nus.iss.crs.pl.AppCode.Filter
{
    public class CRSAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = httpContext.User as CRSFormsPrincipal<User>;
            //var user=((FormsIdentity)HttpContext.Current.User.Identity).Ticket.UserData;
            if (user != null)
            {
                string userRole = string.Empty;
                if (SessionHelper.Current != null)
                {
                    userRole = SessionHelper.Current.RoleName;
                }
                else
                {
                    var userdata = (new JavaScriptSerializer()).Deserialize<User>(((FormsIdentity)HttpContext.Current.User.Identity).Ticket.UserData);
                    userRole = userdata.RoleName;
                }
                if (!string.IsNullOrEmpty(userRole))
                {
                    var roles = Roles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    bool approve= (from role in roles where role.Equals(userRole) select role).Any();
                    return approve;
                }
            }
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (SessionHelper.Current == null)
            {
                filterContext.Result = new RedirectResult("/home/logon");
            }
            else
            {
                filterContext.Result = new RedirectResult("/home/Unauthorized");
            }
        }
    }
}