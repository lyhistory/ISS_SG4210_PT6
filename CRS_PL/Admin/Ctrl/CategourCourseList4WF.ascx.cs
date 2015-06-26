using CRS_WF;
using nus.iss.crs.bl;
using nus.iss.crs.dm.Course;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin.Ctrl
{
    public partial class CategourCourseList4WF : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (CourseClass cls in CourseClassObjs)
            {
                Table1.Rows.Add(CreateCourseClassRow(cls));
            }
        }

        public TableRow CreateCourseClassRow(CourseClass cls)
        {

            TableRow courseRow = new TableRow();
            TableCell codeId = new TableCell();
            codeId.Text = cls.GetCourse().Code;
            courseRow.Cells.Add(codeId);

            TableCell nameID = new TableCell();
            nameID.Text = cls.GetCourse().CourseTitle;
            courseRow.Cells.Add(nameID);

            TableCell startDateID = new TableCell();
            startDateID.Text = cls.StartDate.ToString() + "";
            courseRow.Cells.Add(startDateID);

            TableCell endDateID = new TableCell();
            endDateID.Text = cls.EndDate.ToString();
            courseRow.Cells.Add(endDateID);

            TableCell clsSizeID = new TableCell();
            clsSizeID.Text = cls.Size.ToString();
            courseRow.Cells.Add(clsSizeID);

            TableCell noOfRegParticipant = new TableCell();
            noOfRegParticipant.Text = cls.NoOfRegedParticipant + "";
            courseRow.Cells.Add(noOfRegParticipant);
            switch (cls.Status)
            {
                case ClassStatus.Close:
                    {
                        TableCell cell = new TableCell();
                        LinkButton lbStart = new LinkButton();
                        lbStart.Text = "Start Workflow";
                        lbStart.CommandName = "start";
                        lbStart.CommandArgument = cls.ClassCode;
                        lbStart.Click += lbStart_Click;
                        cell.Controls.Add(lbStart);
                        courseRow.Cells.Add(cell); 
                        break;
                    }
                case ClassStatus.Confirmed:
                    {
                        TableCell lblCell = new TableCell();
                        Label lblStatus = new Label();
                        lblStatus.Text = "Confirmed";

                        lblCell.Controls.Add(lblStatus);
                        courseRow.Cells.Add(lblCell);

                        break;
                    }
                case ClassStatus.Canceled:
                    {
                        TableCell lblCell = new TableCell();
                        Label lblStatus = new Label();
                        lblStatus.Text = "Cancelled";

                        lblCell.Controls.Add(lblStatus);
                        courseRow.Cells.Add(lblCell);
                        break;
                    }
                case ClassStatus.ToConfirm:
                    {

                        TableCell cell = new TableCell();
                        LinkButton lbConfirm = new LinkButton();
                        lbConfirm.Text = "Confirm";
                        lbConfirm.CommandName = "confirm";
                        lbConfirm.CommandArgument = cls.ClassCode;
                        lbConfirm.Click += lbConfirm_Click;
                        cell.Controls.Add(lbConfirm);

                        cell.Controls.Add(new LiteralControl("   " )); 

                        LinkButton lbCancel= new LinkButton();
                        lbCancel.Text = "Cancel";
                        lbCancel.CommandName = "cancel";
                        lbCancel.CommandArgument = cls.ClassCode;
                        lbCancel.Click += lbCancel_Click;
                        cell.Controls.Add(lbCancel);

                        courseRow.Cells.Add(cell);  

                        break;
                    }
            }

            return courseRow;
        }

        void lbStart_Click(object sender, EventArgs e)
        {
             LinkButton lb = sender as LinkButton;

             CourseClass cls = clsManagerObj.GetCourseClassByCode(lb.CommandArgument);

             CourseConfirmationFlow wf = new CourseConfirmationFlow();
             wf.ArgCourseClass = new InOutArgument<CourseClass>(ctx => cls);
             wf.ArgManager = new InArgument<ClassManager>(ctx => clsManagerObj);
             WorkflowInvoker.Invoke(wf);
        }

        void lbConfirm_Click(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;

            CourseClass cls = clsManagerObj.GetCourseClassByCode(lb.CommandArgument);

            ManualConfirmActivity wf = new ManualConfirmActivity();
            wf.ArgCourseClass = new InArgument<CourseClass>(ctx => cls);
            wf.ArgManager = new InArgument<ClassManager>(ctx => clsManagerObj);
            WorkflowInvoker.Invoke(wf);
        }

        void lbCancel_Click(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;

            CourseClass cls = clsManagerObj.GetCourseClassByCode(lb.CommandArgument);

            ManualCancelActivity wf = new ManualCancelActivity();
            wf.ArgCourseClass = new InArgument<CourseClass>(ctx => cls);
            wf.ArgManager = new InArgument<ClassManager>(ctx => clsManagerObj);
            WorkflowInvoker.Invoke(wf);
        }

        public List<CourseClass> CourseClassObjs { get; set; }

        public ClassManager clsManagerObj { get; set; }
    }
}