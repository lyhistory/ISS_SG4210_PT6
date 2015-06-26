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
            LinkButton lbClose = new LinkButton();
            lbClose.Text = "Close";
            lbClose.CommandName = "Close";
            lbClose.CommandArgument = cls.ClassCode;
            lbClose.Click += lbClose_Click;
            closeID.Controls.Add(lbClose);
            courseRow.Cells.Add(closeID);

            TableCell confirmID = new TableCell();
            LinkButton lbConfirm = new LinkButton();
            lbConfirm.Text = "Confirm";
            lbConfirm.CommandName = "Confirm";
            lbConfirm.CommandArgument = cls.ClassCode;
            lbConfirm.Click += lbConfirm_Click;
            confirmID.Controls.Add(lbConfirm);
            courseRow.Cells.Add(confirmID);

            TableCell cancelID = new TableCell();
            LinkButton lbCancel = new LinkButton();
            lbCancel.Text = "Cancel";
            lbCancel.CommandName = "Cancel";
            lbCancel.CommandArgument = cls.ClassCode;
            lbCancel.Click += lbCancel_Click;
            cancelID.Controls.Add(lbCancel);
            courseRow.Cells.Add(cancelID);

            TableCell view = new TableCell();
            h = new HyperLink();
            h.Text = "Detail";
            h.NavigateUrl = "";
            view.Controls.Add(h);
            courseRow.Cells.Add(view);
            return courseRow;
        }

        void lbClose_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;

            classManager.CloseCourseClass(classManager.GetCourseClassByCode(lb.CommandArgument));
            Response.Redirect("~/Admin/ListClassInCalendar.aspx");
        }
        void lbConfirm_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;

            classManager.ConfirmCourseClass(classManager.GetCourseClassByCode(lb.CommandArgument));
            Response.Redirect("~/Admin/ListClassInCalendar.aspx");
        }
        void lbCancel_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;

            classManager.CancelCourseClass(classManager.GetCourseClassByCode(lb.CommandArgument));
            Response.Redirect("~/Admin/ListClassInCalendar.aspx");
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
            Response.Redirect("~/Admin/ListClassInCalendar.aspx");
        }

        public List<CourseClass> courseClassList { get; set; }
        public ClassManager classManager { get; set; }
    }
}