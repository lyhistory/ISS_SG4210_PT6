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
            h.NavigateUrl = "~/Admin/EditCourse.aspx";
            editID.Controls.Add(h);
            courseRow.Cells.Add(editID);

            TableCell deleteID = new TableCell();
            h = new HyperLink();
            h.Text = "Delete";
            h.NavigateUrl = "";
            deleteID.Controls.Add(h);
            courseRow.Cells.Add(deleteID);

            TableCell updateID = new TableCell();
            h = new HyperLink();
            h.Text = "Enable/Disable";
            h.NavigateUrl = "";
            updateID.Controls.Add(h); 
            courseRow.Cells.Add(updateID);

            TableCell view = new TableCell();
            h = new HyperLink();
            h.Text = "Detail";
            h.NavigateUrl = "";
            view.Controls.Add(h);
            courseRow.Cells.Add(view);
            return courseRow;
        }

        public CourseCategory Category { get; set; }
    }
}