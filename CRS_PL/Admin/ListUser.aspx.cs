using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
using nus.iss.crs.pl.Admin.Ctrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin
{
    public partial class ListUser : CrsPageController
    {
        UserManager manager = null;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (BLSession == null)
            {
                ISession session = new SessionImplement();
                manager = session.CreateUserManager();
            }
            else
            {
                manager = BLSession.CreateUserManager();
            }

            ShowCourseList();
        }

        private void ShowCourseList()
        {
            UserList table = (UserList)Page.LoadControl("./Ctrl/UserList.ascx");
            table.userList = manager.GetUserList();
            PlaceHolder1.Controls.Add(table);
        }

        public override void RegistraterAction()
        {
            //throw new NotImplementedException();
        }
    }
}

