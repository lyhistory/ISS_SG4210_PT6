using nus.iss.crs.dm.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin.Ctrl
{
    public partial class CalendarClassList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (CourseClass courseClass in courseClassList)
            {
                Table1.Rows.Add(CreateClassRow(courseClass));
            }
        }

        public TableRow CreateClassRow(CourseClass cls)
        {

            TableRow courseRow = new TableRow();
            TableCell classID = new TableCell();
            classID.Text = cls.ClassCode;
            courseRow.Cells.Add(classID);

            TableCell sizeID = new TableCell();
            sizeID.Text = cls.Size + "";
            courseRow.Cells.Add(sizeID);

            TableCell startDateID = new TableCell();
            startDateID.Text = cls.StartDate.ToString() + "";
            courseRow.Cells.Add(startDateID);

            TableCell endDateID = new TableCell();
            endDateID.Text = cls.EndDate.ToString();
            courseRow.Cells.Add(endDateID);

            TableCell editID = new TableCell();
            HyperLink h = new HyperLink();
            h.Text = "Edit";
            h.NavigateUrl = "~/Admin/EditClass.aspx";
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

        public List<CourseClass> courseClassList { get; set; }
    }
}