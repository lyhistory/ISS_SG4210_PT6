using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
/*
 * AUTHOR:LIU YUE
 * */
namespace CRS_COMMON.Security.FormAuthentication
{
    public class CRSFormsPrincipal<T> : IPrincipal where T : class,new()
    {
        public IIdentity Identity { get; private set; }
        public T UserData { get; private set; }

        public CRSFormsPrincipal(FormsAuthenticationTicket ticket, T userData)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("ticket");
            }
            if (userData == null)
            {
                throw new ArgumentNullException("userData");
            }

            Identity = new FormsIdentity(ticket);
        }

        public bool IsInRole(string role)
        {
            return false;
        }
        public bool IsInUser(string user)
        {
            return false;
        }
    }
}
