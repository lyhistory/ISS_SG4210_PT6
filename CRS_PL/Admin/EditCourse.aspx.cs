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
    public partial class EditCourse : CrsPageController
    {
        private CourseInstructor selectedInstructor = null;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (this.IsPostBack)
                return;
            PopulateCouseDetail();
        }

        void PopulateCouseDetail()
        {
            //retrieve parameter from request
            //retrieve data by parameter from BL
            CourseManager manager = BLSession.CreateCourseManager();
            foreach (CourseCategory category in manager.GetCourseCategoryList())
            {
                ListItem item = new ListItem(category.Name, category.ID);
                categoryList.Items.Add(item);
            }

            foreach (CourseInstructor instructor in manager.GetInstructorList())
            {
                if (selectedInstructor == null)
                    selectedInstructor = instructor;
                ListItem item = new ListItem(instructor.Name);
                instructorList.Items.Add(item);
            }

            Course course = manager.GetCourseByCode(this.Request.QueryString.Get(CRSConstant.ParameterCourseCode));
            codeID.Text = course.Code;
            titleID.Text = course.CourseTitle;
            descriptionID.Text = course.Description;
            durationID.Text = course.Duration + "";
            feeID.Text = course.Fee;

            foreach (ListItem item in categoryList.Items)
            {
                if (course.Category.ID == item.Value)
                {
                    item.Selected = true;
                    break;
                }
            }
            foreach (ListItem item in instructorList.Items)
            {
                if (course.Instructor.Name == item.Value)
                {
                    item.Selected = true;
                    break;
                }
            }
        }

        public override void RegistraterAction()
        {
            RegistraterActionTarget((AdminAction)CourseAdminAction.Save, typeof(ListCourse));
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            CourseManager manager = BLSession.CreateCourseManager();
            Course tempCourse = new Course();
            tempCourse.Code = codeID.Text.ToString();
            tempCourse.CourseTitle = titleID.Text.ToString();
            tempCourse.Description = descriptionID.Text.ToString();
            tempCourse.Duration = Convert.ToInt32(durationID.Text.ToString());
            tempCourse.Fee = feeID.Text.ToString();
            
            string categoryID = categoryList.SelectedItem.Value;
            if(string.IsNullOrEmpty (categoryID))
                return;
            tempCourse.Category = manager.GetCourseCategoryByID(categoryID);

            string instructorID = instructorList.SelectedItem.Value;
            if (string.IsNullOrEmpty(instructorID))
                return;
            tempCourse.Instructor = manager.GetInstructorByID(instructorID);

            manager.EditCourse(tempCourse);
            NextPage(true);
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            NextPage(false);
        }
    }
}