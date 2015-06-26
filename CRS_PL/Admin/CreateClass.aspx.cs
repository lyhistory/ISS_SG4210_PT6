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
            { }
            else
            {
                PopulateCategoryList();
            }


        }

        private void PopulateCategoryList()
        {
            categoryListID.Items.Add("Please select course category...");
            List<CourseCategory> courseCategoryList = manager.GetCourseCategoryList();
            foreach (CourseCategory category in courseCategoryList)
            {
                ListItem item = new ListItem(category.Name, category.ID);
                categoryListID.Items.Add(item);
            }
        }

        private void PopulateCourse(CourseCategory category)
        {
            foreach (Course course in manager.GetCourseListByCategory(category))
            {
                ListItem item = new ListItem(course.CourseTitle, course.Code);
                courseListID.Items.Add(item);
            }
        }

        protected void startDateID_TextChanged(object sender, EventArgs e)
        {
            ClassManager classManager = BLSession.CreateClassManager();
            Course course = manager.GetCourseByCode(courseListID.SelectedItem.Value);
            endDateID.Text = classManager.AutoGenerateCourseClassEndDate(course,DateTime.Parse(startDateID.Text.ToString())).ToString();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            currentAction = (AdminAction)CourseAdminAction.Save;

            CourseManager courseManager = BLSession.CreateCourseManager();

            ListItem itemCategory = categoryListID.SelectedItem;

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
            CourseManager manager = BLSession.CreateCourseManager();
            ListItem item = courseListID.SelectedItem;
            Course selectedCourse = manager.GetCourseByCode(item.Value);

            CourseClass cls = new CourseClass(selectedCourse);
            cls.ClassCode = classID.Text;
            cls.Size = int.Parse(sizeID.Text);
            cls.StartDate = DateTime.Parse(startDateID.Text);
            cls.EndDate = DateTime.Parse(endDateID.Text);
            ClassManager classManager = BLSession.CreateClassManager();
            classManager.CreateCourseClass(cls);

            NextPage(true);
        }

        protected void SaveAndNext_Click(object sender, EventArgs e)
        {

        }

        public override void RegistraterAction()
        {
            RegistraterActionTarget((AdminAction)ClassAdminAction.Save, typeof(ListClassInCalendar));
        }

        protected void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem item = categoryListID.SelectedItem;
            if (item == null)
                return;

            CourseManager manager = BLSession.CreateCourseManager();
            List<CourseCategory> courseCategoryList = manager.GetCourseCategoryList();
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