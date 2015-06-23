using nus.iss.crs.dm;
using nus.iss.crs.pl.AppCode.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace nus.iss.crs.pl.Admin
{
    public class BasePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("/home/logon");
            }
            var userdata = (new JavaScriptSerializer()).Deserialize<User>(((FormsIdentity)HttpContext.Current.User.Identity).Ticket.UserData);
            if (userdata == null || (userdata.RoleName.Equals("SYSTEM") || userdata.RoleName.Equals("COURSE")) == false)
            {
                Response.Redirect("/home/logon");
            }
        }
    }
}