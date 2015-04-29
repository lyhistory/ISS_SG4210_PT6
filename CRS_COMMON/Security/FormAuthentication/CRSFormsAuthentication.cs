using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
/*
 * Author:LIU YUE
 * */
namespace CRS_COMMON.Security.FormAuthentication
{
    public class CRSFormsAuthentication<TUserData> where TUserData:class,new()
    {
        public static void SetAuthCookie(string username, TUserData userData, bool rememberMe)
        {
            if (userData == null)
                throw new ArgumentNullException("UserData");
            var data = (new JavaScriptSerializer()).Serialize(userData);
            var ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddDays(2), rememberMe, data);
            var cookieValue = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue)
            {
                HttpOnly = true,
                Secure=FormsAuthentication.RequireSSL,
                Domain = FormsAuthentication.CookieDomain,
                Path = FormsAuthentication.FormsCookiePath
            };
            if (rememberMe)
            {
                cookie.Expires = DateTime.Now.AddDays(2);
            }
            HttpContext.Current.Response.Cookies.Remove(cookie.Name);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public static CRSFormsPrincipal<TUserData> ParsePrincipal(HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("HTTP Request");
            var cookie = request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                return null;
            try
            {
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                if (ticket != null && !string.IsNullOrEmpty(ticket.UserData))
                {
                    var userData = (new JavaScriptSerializer()).Deserialize<TUserData>(ticket.UserData);
                    if (userData != null)
                    {
                        return new CRSFormsPrincipal<TUserData>(ticket, userData);
                    }
                }
            }
            catch
            {
                //log...
            }
            return null;
        }
    }
}
