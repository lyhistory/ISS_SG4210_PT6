using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
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
            //test data by LanXM
            //ModelData testData = ModelData.GetInstance();

            //Session Facade by Tong
            //ISession session = new SessionImplement();
            //CourseManager courseManager = session.CreateCourseManager();
            //List<CourseCategory> courseCategoryList = courseManager.GetCourseCategoryList();

            //Static method by LiuYue
            List<CourseCategory> courseCategoryList = CourseManager.GetCourseCategoryList();
            foreach (CourseCategory category in courseCategoryList)
            {
                ListItem item = new ListItem(category.Name, category.ID);
                categoryListID.Items.Add(item);
            }
        }

        private void PopulateCourse(CourseCategory category)
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

            CourseManager courseManager = BLSession.CreateCourseManager();

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

            //ModelData testData = ModelData.GetInstance();
            //ListItem item = courseListID.SelectedItem;
            //Course selectedCourse = testData.GetCourse(item.Value);
            ListItem item = courseListID.SelectedItem;
            Course selectedCourse = CourseManager.GetCourseByCode(item.Value);

            CourseClass cls = new CourseClass(selectedCourse);
            cls.ClassCode = classID.Text;
            cls.Size = int.Parse(sizeID.Text);
            cls.StartDate = DateTime.Parse(startDateID.Text);
            cls.EndDate = DateTime.Parse(endDateID.Text);

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

            //ModelData testData = ModelData.GetInstance();
            //testData.AddCourseClasses();
            //CourseCategory category = testData.GetCategory(item.Value);
            //PopulateClourse(category);

            List<CourseCategory> courseCategoryList = CourseManager.GetCourseCategoryList();
            foreach(CourseCategory courseCategory in courseCategoryList)
            {
                if(courseCategory.ID == item.Value)
                {
                    PopulateCourse(courseCategory);
                }
            }
        }

        protected void courseList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}