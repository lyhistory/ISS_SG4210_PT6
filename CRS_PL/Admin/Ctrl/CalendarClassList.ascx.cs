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

            TableCell statusID = new TableCell();
            statusID.Text = cls.Status.ToString();
            courseRow.Cells.Add(statusID);

            TableCell editID = new TableCell();
            HyperLink h = new HyperLink();
            h.Text = "Edit";
            h.NavigateUrl = "~/Admin/EditClass.aspx?" + CRSConstant.ParameterClassCode + "=" + cls.ClassCode;
            editID.Controls.Add(h);
            courseRow.Cells.Add(editID);

            TableCell closeID = new TableCell();
            LinkButton lb = new LinkButton();
            lb.Text = "Close";
            lb.CommandName = "Close";
            lb.CommandArgument = cls.ClassCode;
            lb.Click += new EventHandler(lb_Command);
            closeID.Controls.Add(lb);
            courseRow.Cells.Add(closeID);

            TableCell confirmID = new TableCell();
            lb = new LinkButton();
            lb.Text = "Confirm";
            lb.CommandName = "Confirm";
            lb.CommandArgument = cls.ClassCode;
            lb.Click += new EventHandler(lb_Command);
            confirmID.Controls.Add(lb);
            courseRow.Cells.Add(confirmID);

            TableCell cancelID = new TableCell();
            lb = new LinkButton();
            lb.Text = "Cancel";
            lb.CommandName = "Cancel";
            lb.CommandArgument = cls.ClassCode;
            lb.Click += new EventHandler(lb_Command);
            cancelID.Controls.Add(lb);
            courseRow.Cells.Add(cancelID);

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
            LinkButton lb = new LinkButton();
            
            if (lb.CommandName == "Close")
            {
                classManager.CloseCourseClass(classManager.GetCourseClassByCode(lb.CommandArgument));
            }
            else if (lb.CommandName == "Confirm")
            {
                classManager.ConfirmCourseClass(classManager.GetCourseClassByCode(lb.CommandArgument));
            }
            else if (lb.CommandName == "Cancel")
            {
                classManager.CancelCourseClass(classManager.GetCourseClassByCode(lb.CommandArgument));
            }
        }

        public List<CourseClass> courseClassList { get; set; }
        public ClassManager classManager { get; set; }
    }
}