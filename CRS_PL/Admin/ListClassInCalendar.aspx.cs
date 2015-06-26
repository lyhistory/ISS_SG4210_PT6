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
    public partial class ListClassInCalendar : CrsPageController
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

            PopulateCategoryList();
            ShowCourseClassList();
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
            ClassManager classManager = BLSession.CreateClassManager();
            int total = PlaceHolder1.Controls.Count-1;
            for (int i = total; i >=0; i--)
            {
                PlaceHolder1.Controls.RemoveAt(i);
            }
            if (courseListID.SelectedValue == "ALL")
            {

                foreach(Course course in manager.GetCourseList())
                {
                    DateTime startdate, enddate;
                    if (!DateTime.TryParse(txtStartDate.Text.ToString(), out startdate))
                    {
                        startdate = DateTime.MinValue;
                    }
                    if (!DateTime.TryParse(txtEndDate.Text.ToString(), out enddate))
                    {
                        enddate = DateTime.MaxValue;
                    }
                    List<CourseClass> courseClassList = manager.GetCourseClassList(course, startdate,enddate);
                    CalendarClassList table = (CalendarClassList)Page.LoadControl("./Ctrl/CalendarClassList.ascx");
                    table.courseClassList = courseClassList;
                    table.classManager = classManager;
                    PlaceHolder1.Controls.Add(table);
                }
            }
            else
            {
                Course course = manager.GetCourseByCode(courseListID.SelectedValue);
                List<CourseClass> courseClassList = manager.GetCourseClassList(course, DateTime.Parse(txtStartDate.Text.ToString()), DateTime.Parse(txtEndDate.Text.ToString()));
                CalendarClassList table = (CalendarClassList)Page.LoadControl("./Ctrl/CalendarClassList.ascx");
                table.courseClassList = courseClassList;
                table.classManager = classManager;
                
                PlaceHolder1.Controls.Add(table);
            }     
        }

        protected void SearchClass_Click(object sender, EventArgs e)
        {
            ShowCourseClassList();
        }

        public TableHeaderRow CreateClassHeader()
        {
            TableHeaderRow headerRow = new TableHeaderRow();

            TableHeaderCell classID = new TableHeaderCell();
            classID.Text = "Class ID";
            classID.ColumnSpan = 1;
            headerRow.Cells.Add(classID);

            TableHeaderCell Size = new TableHeaderCell();
            Size.Text = "Class ID";
            Size.ColumnSpan = 1;
            headerRow.Cells.Add(Size);

            TableHeaderCell startDate = new TableHeaderCell();
            startDate.Text = "Class ID";
            startDate.ColumnSpan = 1;
            headerRow.Cells.Add(startDate);

            TableHeaderCell endDate = new TableHeaderCell();
            endDate.Text = "Class ID";
            endDate.ColumnSpan = 1;
            headerRow.Cells.Add(endDate);

            TableHeaderCell Operation = new TableHeaderCell();
            Operation.Text = "Class ID";
            Operation.ColumnSpan = 1;
            headerRow.Cells.Add(Operation);

            return headerRow;
        }
    }
}