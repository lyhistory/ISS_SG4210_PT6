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
        protected override void Page_Load(object sender, EventArgs e)
        {
            TestData();
        }

        private void TestData()
        {
            ModelData testData = ModelData.GetInstance();
            testData.AddCourseClasses();
            foreach (Course course in testData.GetCourses())
            {
                CourseClassList table = (CourseClassList)Page.LoadControl("./Ctrl/CourseClassList.ascx");

                table.course = course;
                PlaceHolder1.Controls.Add(table);
                Label newline = new Label();
                newline.Text = "<BR/>";
                PlaceHolder1.Controls.Add(newline);
            }
        }


        public override void RegistraterAction()
        {
            
        }

        protected void categoryListID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load and display course and course class

            //TestData();
        }
    }
}