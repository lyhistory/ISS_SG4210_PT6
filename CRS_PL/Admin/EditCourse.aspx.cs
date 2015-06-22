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

        private CourseCategory selectedCategory = null;
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
            //populate category and instructor
            //TestDat();

            ////retrieve parameter from request
            
            ////retrieve data by parameter from BL
            //Course course = new Course();
            //course.Category = selectedCategory;
            //course.Instructor = selectedInstructor;
            //course.Code = "123456";
            //course.CourseTitle = "title";
            //course.Description = "description";
            //course.Duration = 3;
            //course.Fee = "2000";
            CourseManager manager = BLSession.CreateCourseManager();
            Course course = manager.GetCourseByCode(this.Request.QueryString(CRSConstant.ParameterCourseCode));
            //populate data 
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

        private void TestDat()
        {
            Random r = new Random();
            ModelData testData = ModelData.GetInstance();
            List<CourseCategory> categoryListObj = testData.GetCategories();
            foreach (CourseCategory category in categoryListObj)
            {     
                ListItem item = new ListItem(category.Name, category.ID);
                categoryList.Items.Add(item);
            }

            selectedCategory = categoryListObj[r.Next(categoryListObj.Count - 1)];

            List<CourseInstructor> instructorListObj = testData.GetInstructors();
            foreach (CourseInstructor instructor in instructorListObj)
            {
                if (selectedInstructor == null)
                    selectedInstructor = instructor;
                ListItem item = new ListItem(instructor.Name);
                instructorList.Items.Add(item);
            }

            selectedInstructor = instructorListObj[r.Next(instructorListObj.Count - 1)];
        }

        public override void RegistraterAction()
        {
            RegistraterActionTarget((AdminAction)CourseAdminAction.Save, typeof(ListCourse));
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