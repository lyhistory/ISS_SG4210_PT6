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
            Course course = manager.CreateCourse();
            course.category = new Category("ID", "Category Name", "Description");
        } 

    }
}