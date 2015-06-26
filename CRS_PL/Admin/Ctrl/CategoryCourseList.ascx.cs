using nus.iss.crs.bl;
using nus.iss.crs.dm.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin.Ctrl
{
    public partial class CategoryCourseList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryID.Text = Category.Name;

            foreach (Course course in Category.GetCourses())
            {
                Table1.Rows.Add(CreateCourseRow(course));
            }
        }

        public TableRow CreateCourseRow(Course course)
        {

            TableRow courseRow = new TableRow();
            TableCell codeId = new TableCell();
            codeId.Text = course.Code;
            courseRow.Cells.Add(codeId);

            TableCell nameID = new TableCell();
            nameID.Text = course.CourseTitle;
            courseRow.Cells.Add(nameID);

            TableCell durationID = new TableCell();
            durationID.Text = course.Duration + "";
            courseRow.Cells.Add(durationID);

            TableCell instructorID = new TableCell();
            instructorID.Text = course.Instructor.Name;
            courseRow.Cells.Add(instructorID);

            TableCell feeID = new TableCell();
            feeID.Text = course.Fee;
            courseRow.Cells.Add(feeID);

            TableCell editID = new TableCell();
            HyperLink h = new HyperLink();
            h.Text = "Edit";
            h.NavigateUrl = "~/Admin/EditCourse.aspx?"+CRSConstant.ParameterCourseCode+"=" + course.Code;
            editID.Controls.Add(h);
            courseRow.Cells.Add(editID);

            TableCell deleteID = new TableCell();
            //LinkButton lb = new LinkButton();
            //lb.Text = "Delete";
            //lb.PostBackUrl = "#";
            //lb.OnClientClick = "javascript:abc('"+course.Code+"'); return false;";
            LinkButton lb = new LinkButton();
            lb.Text = "Delete";
            lb.CommandName = "Delete";
            lb.CommandArgument = course.Code;
            lb.Click += new EventHandler(lb_Command);
            deleteID.Controls.Add(lb);
            courseRow.Cells.Add(deleteID);

            TableCell updateID = new TableCell();
            lb = new LinkButton();
            lb.Text = "Enable /Disable";
            lb.CommandName = "Disable";
            lb.CommandArgument = course.Code;
            lb.Click += new EventHandler(lb_Command);
            updateID.Controls.Add(lb);
            courseRow.Cells.Add(updateID);


            TableCell view = new TableCell();
            h = new HyperLink();
            h.Text = "Detail";
            h.NavigateUrl = "";
            view.Controls.Add(h);
            courseRow.Cells.Add(view);
            return courseRow;
        }

        protected void lb_Command(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;
            
            if (lb.CommandName == "Delete")
            {
                courseManager.DeleteCourse(lb.CommandArgument);
            }
            else if(lb.CommandName == "Disable")
            {
                courseManager.ChangeCourseStatus(lb.CommandArgument);
            }
        }

        public CourseCategory Category { get; set; }
        public CourseManager courseManager { get; set; }
    }
}