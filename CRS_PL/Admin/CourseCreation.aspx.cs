using nus.iss.crs.bl;
using nus.iss.crs.dm.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin
{
    public partial class CourseCreation : CrsPageController
    {

        protected  override void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            ISession session = (ISession) Session["BLSession"];
            if (session == null || !session.IsValid())
            {
                //redirect to login page
            }

            CourseManager manager = session.CreateCourseManager();
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
                manager.SaveCourse(course);
            }
            else 
            {
                //TODO
            }
        }
    }
}