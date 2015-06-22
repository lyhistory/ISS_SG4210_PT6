using nus.iss.crs.bl;
using nus.iss.crs.dm.Course;
using nus.iss.crs.pl.Admin.Ctrl;
using nus.iss.crs.pl.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin
{
    public partial class ListClassInCourse :CrsPageController
    {
        CourseManager manager = null;
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
            }
            else
            {
                PopulateCategoryList();
            }
            //TestData();
        }


        private void PopulateCategoryList()
        {
            categoryListID.Items.Add("Please select course category...");
            //ModelData testData = ModelData.GetInstance();
            foreach (CourseCategory courseCategory in manager.GetCourseCategoryList())
            { 
                ListItem item = new ListItem(courseCategory.Name,courseCategory.ID);
                categoryListID.Items.Add(item);
            }
        }

        //private void TestData()
        //{

        //    ModelData testData = ModelData.GetInstance();
            

        //    testData.AddCourseClasses();
        //    foreach (Course course in testData.GetCourses())
        //    {
        //        CourseClassList table = (CourseClassList)Page.LoadControl("./Ctrl/CourseClassList.ascx");

        //        table.course = course;
        //        PlaceHolder1.Controls.Add(table);
        //        Label newline = new Label();
        //        newline.Text = "<BR/>";
        //        PlaceHolder1.Controls.Add(newline);
        //    }
        //}


        public override void RegistraterAction()
        {
            
        }

        protected void categoryListID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load and display course and course class

            ListItem item = categoryListID.SelectedItem;
            if (item == null)
                return;

            //ModelData testData = ModelData.GetInstance();
            //testData.AddCourseClasses();
            //CourseCategory category = testData.GetCategory(item.Value);
            foreach (CourseCategory courseCategory in manager.GetCourseCategoryList())
            {
                if(courseCategory.ID == item.Value)
                {
                    PopulateClass(courseCategory);
                }
            }
            return;
        }


        private void PopulateClass(CourseCategory category)
        {
            foreach (Course course in category.GetCourses())
            {
                CourseClassList table = (CourseClassList)Page.LoadControl("./Ctrl/CourseClassList.ascx");

                table.course = course;
                PlaceHolder1.Controls.Add(table);
                Label newline = new Label();
                newline.Text = "<BR/>";
                PlaceHolder1.Controls.Add(newline);
            }
        }
    }
}