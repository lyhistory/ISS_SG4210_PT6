using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;

namespace nus.iss.crs.pl.Admin
{
    public abstract class CrsPageController : System.Web.UI.Page
    {

        protected ISession BLSession = null;
        protected NavigationManager navManager = NavigationManager.GetInstance();
        protected AdminAction currentAction;

        protected virtual void Page_Init(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            //role manager
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("/home/logon");
            }
            var userdata = (new JavaScriptSerializer()).Deserialize<User>(((FormsIdentity)HttpContext.Current.User.Identity).Ticket.UserData);
            if (userdata == null || (userdata.RoleName.Equals("SYSTEM") || userdata.RoleName.Equals("COURSE")) == false)
            {
                Response.Redirect("/home/logon");
            }

            RegistraterAction();
        }

        public abstract void RegistraterAction();

        protected void RegistraterActionTarget(AdminAction action, Type target)
        {
            RegistraterActionTarget(action, target, null);
        }
        protected void RegistraterActionTarget(AdminAction action, Type successTarget, Type failedTarget)
        {
            navManager.RegisterActionTarget(this, action, successTarget, failedTarget);
        }

        protected virtual void Page_Load(object sender, EventArgs e)
        {
                //BLSession 
            BLSession = (ISession)Session[CRSConstant.BLSessionKey];
            if (BLSession == null || !BLSession.IsValid())
            {
                //redirect to login page or create a new session 
                BLSession = SessionFactory.CreateSession();
            }
        }

        protected void NextPage(bool status)
        { 

           ActionTarget actionTarget =  navManager.Navigate(this,currentAction);

           if (status)
           {
               Response.Redirect(actionTarget.SuccessTarget.Name + ".aspx");
           }
           else
           {
               if (actionTarget.FailedTarget == null)
               {
                   Response.Redirect(actionTarget.SuccessTarget.Name + ".aspx");
               }
               else
               {
                   Response.Redirect(actionTarget.FailedTarget.Name + ".aspx");
               }
           }
        }

        //public override void Dispose()
        //{
        //    base.Dispose();

        //}
    }
}
