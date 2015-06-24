using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
using nus.iss.crs.dm.Course;
using nus.iss.crs.pl.Admin.Ctrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin
{
    public partial class ListCourseInCalendar : CrsPageController
    {
        CourseManager manager = null;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if(BLSession == null)
            {
                ISession session = new SessionImplement();
                manager = session.CreateCourseManager();
            }
            else
            {
                manager = BLSession.CreateCourseManager();
            }

            if(IsPostBack)
            {

            }
            else
            {
                //CalStartDate.Visible = false;
                //CalEndDate.Visible = false;
                PopulateCategoryList();
            }
        }

        private void PopulateCategoryList()
        {
            courseListID.Items.Add("ALL");
            foreach (Course course in manager.GetCourseList())
            {
                ListItem item = new ListItem(course.CourseTitle, course.Code);
                courseListID.Items.Add(item);
            }
        }

        //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (CalStartDate.Visible == false)
        //    {
        //        CalStartDate.Visible = true;
        //    }
        //    else
        //    {
        //        CalStartDate.Visible = false;
        //    }
        //}

        //protected void CalStartDate_SelectionChanged(object sender, ImageClickEventArgs e)
        //{
        //    txtStartDate.Text = CalStartDate.SelectedDate.ToShortDateString();
        //}
        //protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (CalEndDate.Visible == false)
        //    {
        //        CalEndDate.Visible = true;
        //    }
        //    else
        //    {
        //        CalEndDate.Visible = false;
        //    }
        //}

        //protected void CalEndDate_SelectionChanged(object sender, ImageClickEventArgs e)
        //{
        //    txtEndDate.Text = CalEndDate.SelectedDate.ToShortDateString();
        //}

        public override void RegistraterAction()
        {
            //throw new NotImplementedException();
        }

        private void ShowCourseClassList()
        {
            if (courseListID.SelectedValue == "ALL")
            {
                foreach(Course course in manager.GetCourseList())
                {
                    List<CourseClass> courseClassList = manager.GetCourseClassList(course, DateTime.Parse(txtStartDate.Text.ToString()), DateTime.Parse(txtEndDate.Text.ToString()));
                    CalendarClassList table = (CalendarClassList)Page.LoadControl("./Ctrl/CalendarClassList.ascx");
                    table.courseClassList = courseClassList;
                    PlaceHolder1.Controls.Add(table);
                }
            }
            else
            {
                Course course = manager.GetCourseByCode(courseListID.SelectedValue);
                List<CourseClass> courseClassList = manager.GetCourseClassList(course, DateTime.Parse(txtStartDate.Text.ToString()), DateTime.Parse(txtEndDate.Text.ToString()));
                CalendarClassList table = (CalendarClassList)Page.LoadControl("./Ctrl/CalendarClassList.ascx");
                table.courseClassList = courseClassList;
                PlaceHolder1.Controls.Add(table);
            }     
        }

        protected void SearchClass_Click(object sender, EventArgs e)
        {
            ShowCourseClassList();
        }

    }
}