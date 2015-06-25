using nus.iss.crs.dm.Course;
using System;
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
            //categoryID.Text = Category.Name;

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

            TableCell editID = new TableCell();
            HyperLink h = new HyperLink();
            h.Text = "Confirm";
            //h.NavigateUrl = "~/Admin/EditCourse.aspx?" + CRSConstant.ParameterCourseCode + "=" + course.Code;

            editID.Controls.Add(h);
            courseRow.Cells.Add(editID);

            TableCell deleteID = new TableCell();
            LinkButton lb = new LinkButton();
            lb.Text = "Cancel";

            lb.OnClientClick = "";
            deleteID.Controls.Add(lb);
            courseRow.Cells.Add(deleteID);
 
            return courseRow;
        }

        void lb_Click(Course course)
        {

        }

        //public CourseCategory Category { get; set; }
        public List<CourseClass> CourseClassObjs { get; set; }        
    }
}