using nus.iss.crs.dm.Course;
using nus.iss.crs.pl.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin
{
    public partial class EditClass : CrsPageController
    {

        //private CourseCategory selectedCategory = null;
        //private CourseInstructor selectedInstructor = null;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (this.IsPostBack)
                return;
            PopulateCouseDetail();
        }

        void PopulateCouseDetail()
        {
            //populate category and instructor
            //TestDat();

            //retrieve parameter from request

            //retrieve data by parameter from BL
            //CourseClass course = new Course();
            //course.Category = selectedCategory;
            //course.Instructor = selectedInstructor;
            //course.Code = "123456";
            //course.CourseTitle = "title";
            //course.Description = "description";
            //course.Duration = 3;
            //course.Fee = "2000";

            ////populate data 
            //codeID.Text = course.Code;
            //titleID.Text = course.CourseTitle;
            //descriptionID.Text = course.Description;
            //durationID.Text = course.Duration + "";
            //feeID.Text = course.Fee;

            //foreach (ListItem item in categoryList.Items)
            //{
            //    if (course.Category.ID == item.Value)
            //    {
            //        item.Selected = true;
            //        break;
            //    }
            //}
            //foreach (ListItem item in instructorList.Items)
            //{
            //    if (course.Instructor.Name == item.Value)
            //    {
            //        item.Selected = true;
            //        break;
            //    }
            //}

        }

        public override void RegistraterAction()
        {
            RegistraterActionTarget((AdminAction)ClassAdminAction.Save, typeof(ListClassInCourse));
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            NextPage(true);
        }

        protected void Back_Click(object sender, EventArgs e)
        {

        }
    }
}