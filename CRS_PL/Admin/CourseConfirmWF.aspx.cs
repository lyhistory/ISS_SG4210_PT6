using nus.iss.crs.bl;
using nus.iss.crs.dm.Course;
using nus.iss.crs.pl.Admin.Ctrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin
{
    public partial class CourseConfirmWF : CrsPageController
    {

        //TODO
        CourseManager manager = null;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            ShowCourseList();
        }

        private void ShowCourseList()
        { 
             
            manager = BLSession.CreateCourseManager();
            
            foreach (CourseCategory courseCategory in manager.GetCourseCategoryList(true))
            {
                CategourCourseList4WF table = (CategourCourseList4WF)Page.LoadControl("./Ctrl/CategourCourseList4WF.ascx");

                table.Category = courseCategory;
                //table.Category = testData.CreateCategory(); 
                PlaceHolder1.Controls.Add(table);
                Label newline = new Label();
                newline.Text = "<BR/>";
                PlaceHolder1.Controls.Add(newline);
            }
        }

        public override void RegistraterAction()
        {
            //throw new NotImplementedException();
        }
    }
}