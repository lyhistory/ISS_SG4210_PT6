using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using CRS_COMMON;
using CRS_COMMON.Security.FormAuthentication;
using nus.iss.crs.dm;
namespace nus.iss.crs.pl
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, System.EventArgs e)
        {
            var formsIndentity = HttpContext.Current.User.Identity as FormsIdentity;
            if (formsIndentity != null && formsIndentity.IsAuthenticated && formsIndentity.AuthenticationType.Equals("Forms"))
            {
                HttpContext.Current.User = CRSFormsAuthentication<User>.ParsePrincipal(HttpContext.Current.Request);
            }
        }
    }
}
