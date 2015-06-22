using nus.iss.crs.bl;
using nus.iss.crs.dm.Course;
using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin
{
    public partial class ListCourseClassRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.IsPostBack)
            { }
            else
            {
                PopulateCourseCategoryList();
            }
        }

        private void PopulateCourseCategoryList()
        {
            categoryListID.Items.Add("Please select course category...");

            List<CourseCategory> courseCategoryList = CourseManager.GetCourseCategoryList();
            foreach (CourseCategory category in courseCategoryList)
            {
                ListItem item = new ListItem(category.Name, category.ID);
                categoryListID.Items.Add(item);
            }
        }

        protected void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem item = categoryListID.SelectedItem;
            if (item == null)
                return;

            List<CourseCategory> courseCategoryList = CourseManager.GetCourseCategoryList();
            foreach (CourseCategory courseCategory in courseCategoryList)
            {
                if (courseCategory.ID == item.Value)
                {
                    PopulateCourse(courseCategory);
                }
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

        protected void courseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem item = courseListID.SelectedItem;
            if (item == null)
                return;
            Course course = CourseManager.GetCourseByCode(item.Value);
            List<CourseClass> courseClassList = CourseManager.GetCourseClassList(course, DateTime.Now, DateTime.MaxValue);

            PopulateClass(courseClassList);
        }

        private void PopulateClass(List<CourseClass> courseClassList)
        {
            foreach(CourseClass courseClass in courseClassList)
            {
                ListItem item = new ListItem(courseClass.ClassCode, courseClass.ClassCode);
                classListID.Items.Add(item);
            }
        }

        protected void classListID_SelectedIndexChanged(object sender,EventArgs e)
        {

        }
    }
}