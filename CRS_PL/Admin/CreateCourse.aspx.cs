using nus.iss.crs.bl;
using nus.iss.crs.dm;
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
    public partial class CreateCourse : CrsPageController
    {

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (this.IsPostBack)
                return;
            ModelData testData = new ModelData();
            foreach (CourseCategory category in testData.GetCategories())
            {
                ListItem item = new ListItem(category.Name, category.ID);
                categoryList.Items.Add(item);
            }

            foreach (CourseInstructor instructor in testData.GetInstructors())
            {
                ListItem item = new ListItem(instructor.Name);
                instructorList.Items.Add(item);
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            currentAction = (AdminAction)CourseAdminAction.Save;

            //CourseManager manager = BLSession.CreateCourseManager();
            Course course = new Course();
            course.Category = new CourseCategory("ID", "Category Name", "Description");

            course.Code = "123456";
            course.CourseTitle = "title";
            course.Description = "description";
            course.Duration = 3;
            course.Fee = "2000";
            course.Instructor = new dm.CourseInstructor("abc");

            if (course.IsValid())
            {
                //manager.SaveCourse(course);
            }
            else 
            {
                //TODO
            }

            //nus.iss.crs.pl.ActionTarget.CourseAdminAction

            NextPage(true);
            
        }

        protected void SaveAndNext_Click(object sender, EventArgs e)
        {

        }

        public override void RegistraterAction()
        {
            RegistraterActionTarget((AdminAction)CourseAdminAction.Save, typeof(ListCourse));
        }
    }
}