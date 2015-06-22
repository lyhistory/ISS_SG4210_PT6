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
    public partial class ListCourse : CrsPageController
    {

        protected override void Page_Load(object sender, EventArgs e)
        {
            ShowCourseList();
        }

        private void ShowCourseList()
        {
            foreach (CourseCategory courseCategory in CourseManager.GetCourseCategoryList())
            {
                CategoryCourseList table = (CategoryCourseList)Page.LoadControl("./Ctrl/CategoryCourseList.ascx");

                table.Category = courseCategory;
                //table.Category = testData.CreateCategory(); 
                PlaceHolder1.Controls.Add(table);
                Label newline = new Label();
                newline.Text = "<BR/>";
                PlaceHolder1.Controls.Add(newline);
            }
        }

        //private void TestData()
        //{
        //    ModelData testData = ModelData.GetInstance();
        //    testData.AddCourse4Categories();
        //    foreach (CourseCategory courseCategory in testData.GetCategories())
        //    {
        //        CategoryCourseList table = (CategoryCourseList)Page.LoadControl("./Ctrl/CategoryCourseList.ascx");

        //        table.Category = courseCategory;
        //        //table.Category = testData.CreateCategory(); 
        //        PlaceHolder1.Controls.Add(table);
        //        Label newline = new Label();
        //        newline.Text = "<BR/>";
        //        PlaceHolder1.Controls.Add(newline);
        //    }
        //}

        public override void RegistraterAction()
        {
            //throw new NotImplementedException();
        }
    }
}