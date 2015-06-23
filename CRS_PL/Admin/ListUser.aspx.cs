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

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            ShowCourseList();
        }

        private void ShowCourseList()
        {
            //CourseManager manager = BLSession.CreateCourseManager();
            if (BLSession == null)
            {
                ISession session = new SessionImplement();
                manager = session.CreateUserManager();
            }
            else
            {
                manager = BLSession.CreateUserManager();
            }

            //foreach (UserManager userManager in manager.GetUserList())
            //{
            //    UserList table = (UserList)Page.LoadControl("./Ctrl/UserList.ascx");

            //    table.c = userManager;
            //    //table.Category = testData.CreateCategory(); 
            //    PlaceHolder1.Controls.Add(table);
            //    Label newline = new Label();
            //    newline.Text = "<BR/>";
            //    PlaceHolder1.Controls.Add(newline);
            //}
        }

        private void SeachUser()
        {

        }

        public override void RegistraterAction()
        {
            //throw new NotImplementedException();
        }
    }
}

