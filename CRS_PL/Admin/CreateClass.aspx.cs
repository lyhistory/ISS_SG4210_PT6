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
    public partial class ClassCreation : CrsPageController
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            { }
            else
            {
                PopulateCategoryList();
            }

            
        }

        private void PopulateCategoryList()
        {
            categoryListID.Items.Add("Please select course category...");
            ModelData testData = ModelData.GetInstance();
            foreach (CourseCategory category in testData.GetCategories())
            {
                ListItem item = new ListItem(category.Name, category.ID);
                categoryListID.Items.Add(item);
            }
        }

        private void PopulateClourse(CourseCategory category)
        {
            foreach (Course course in category.GetCourses())
            {
                ListItem item = new ListItem(course.CourseTitle, course.Code);
                courseListID.Items.Add(item);
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            currentAction = (AdminAction)CourseAdminAction.Save;

            //CourseManager manager = BLSession.CreateCourseManager();

            ListItem itemCategory = categoryListID.SelectedItem;
            CourseCategory selectedCategory = null;

            //foreach (CourseCategory category in testData.GetCategories())
            //{
            //    if (category.ID == itemCategory.Value)
            //    {
            //        selectedCategory = category;
            //        break;
            //    }
            //}

            //ListItem itemInstructor = instructorList.SelectedItem;
            //CourseInstructor selectedInstructor = null;
            //foreach (CourseInstructor instructor in testData.GetInstructors())
            //{
            //    if (instructor.Name == itemInstructor.Value)
            //    {
            //        selectedInstructor = instructor;
            //        break;
            //    }
            //}
            ModelData testData = ModelData.GetInstance();
            ListItem item = courseListID.SelectedItem;
            Course selectedCourse = testData.GetCourse(item.Value);

            CourseClass cls = new CourseClass(selectedCourse);
            cls.ClassCode = classID.Text;
            cls.Size = int.Parse(sizeID.Text);
            cls.StartDate = DateTime.Parse(startDateID.Text);
            cls.EndDate = DateTime.Parse(endDateID.Text);
              


            //nus.iss.crs.pl.ActionTarget.CourseAdminAction

            NextPage(true);

        }

        protected void SaveAndNext_Click(object sender, EventArgs e)
        {

        }

        public override void RegistraterAction()
        {
            RegistraterActionTarget((AdminAction)ClassAdminAction.Save, typeof(ListClassInCourse));
        }

        protected void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
             ListItem item = categoryListID.SelectedItem;
            if (item == null)
                return;

            ModelData testData = ModelData.GetInstance();
            testData.AddCourseClasses();

            CourseCategory category = testData.GetCategory(item.Value);
            PopulateClourse(category);
             
        }

        protected void courseList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}