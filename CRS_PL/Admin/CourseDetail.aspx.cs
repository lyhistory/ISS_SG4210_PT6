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
    public partial class CourseDetail : CrsPageController
    {
        CourseManager manager = null;
        ClassManager classManager = null;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            manager = BLSession.CreateCourseManager();
            classManager = BLSession.CreateClassManager();

            if (this.IsPostBack)
                return;


            PopulateCourseDetail();
        }

        private void PopulateCourseDetail()
        {
            Course course = manager.GetCourseByCode(this.Request.QueryString.Get(CRSConstant.ParameterCourseCode));
            categoryID.Text = course.Category.Name;
            codeID.Text = course.Code;
            titleID.Text = course.CourseTitle;
            descriptionID.Text = course.Description;
            durationID.Text = course.Duration + "";
            feeID.Text = course.Fee;
            instructorID.Text = course.Instructor.Name;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ListCourse.aspx");
        }

        public override void RegistraterAction()
        {

        }
    }
}