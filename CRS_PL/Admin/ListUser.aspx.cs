using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
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

            foreach (UserManager userManager in manager.GetCourseCategoryList(true))
            {
                CategoryCourseList table = (CategoryCourseList)Page.LoadControl("./Ctrl/CategoryCourseList.ascx");

                table.Category = userManager;
                //table.Category = testData.CreateCategory(); 
                PlaceHolder1.Controls.Add(table);
                Label newline = new Label();
                newline.Text = "<BR/>";
                PlaceHolder1.Controls.Add(newline);
            }
        }

        private void SeachUser()
        {

        }
    }
}