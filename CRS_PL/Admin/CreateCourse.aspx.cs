using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
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
        CourseManager manager = null;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (BLSession == null)
            {
                ISession session = new SessionImplement();
                manager = session.CreateCourseManager();
            }
            else
            {
                manager = BLSession.CreateCourseManager();
            }

            if (this.IsPostBack)
                return;

            foreach (CourseCategory category in manager.GetCourseCategoryList())
            {
                ListItem item = new ListItem(category.Name, category.ID);
                categoryList.Items.Add(item);
            }

            foreach (CourseInstructor instructor in manager.GetInstructorList())
            {
                ListItem item = new ListItem(instructor.Name);
                instructorList.Items.Add(item);
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            currentAction = (AdminAction)CourseAdminAction.Save;

            //CourseManager manager = BLSession.CreateCourseManager();

            ListItem itemCategory = categoryList.SelectedItem;            
            CourseCategory selectedCategory = null;

            foreach (CourseCategory category in manager.GetCourseCategoryList())
            {
                if (category.ID == itemCategory.Value)
                {
                    selectedCategory = category;
                    break;
                }
            }

            ListItem itemInstructor= instructorList.SelectedItem;
            CourseInstructor selectedInstructor = null;
            foreach (CourseInstructor instructor in manager.GetInstructorList())
            {
                if (instructor.Name == itemInstructor.Value)
                {
                    selectedInstructor = instructor;
                    break;
                }
            }

            Course course = new Course();
            course.Category = selectedCategory;

            course.Code = codeID.Text;
            course.CourseTitle = titleID.Text;
            course.Description = descriptionID.Text;
            course.Duration = int.Parse(durationID.Text);
            course.Fee = feeID.Text;
            course.Instructor = selectedInstructor;

            if (course.IsValid())
            { 
                //manager.SaveCourse(course);
                selectedCategory.AddCourse(course);
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