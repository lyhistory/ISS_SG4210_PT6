using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
using nus.iss.crs.dm.Course;
using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin
{
    public partial class ListCourseClassRegistration : CrsPageController
    {

        //TODO
        CourseRegistrationManager manager = null;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            ShowRegistrationList();
        }
        private void ShowRegistrationList()
        {
            //CourseManager manager = BLSession.CreateCourseManager();
            if (BLSession == null)
            {
                ISession session = new SessionImplement();
                manager = session.CreateCourseRegistrationManager();
            }
            else
            {
                manager = BLSession.CreateCourseRegistrationManager();
            }

            foreach (Registration registration in manager.GetRegistrationList())
            {
                Table1.Rows.Add(CreateRegistrationRow(registration));
            }
        }

        private TableRow CreateRegistrationRow(Registration registration)
        {
            TableRow courseRow = new TableRow();

            TableCell fullName = new TableCell();
            fullName.Text = registration.ParticipantObj.FullName;
            courseRow.Cells.Add(fullName);

            TableCell companyName = new TableCell();
            companyName.Text = registration.ParticipantObj.CompanyName;
            courseRow.Cells.Add(companyName);

            TableCell courseCode = new TableCell();
            courseCode.Text = registration.CourseClassObj.GetCourse().Code;
            courseRow.Cells.Add(courseCode);

            TableCell courseName = new TableCell();
            courseName.Text = registration.CourseClassObj.GetCourse().Description;
            courseRow.Cells.Add(courseName);

            TableCell classCode = new TableCell();
            classCode.Text = registration.CourseClassObj.ClassCode;
            courseRow.Cells.Add(classCode);

            TableCell startDate = new TableCell();
            startDate.Text = registration.CourseClassObj.StartDate.ToString();
            courseRow.Cells.Add(startDate);

            TableCell endDate = new TableCell();
            endDate.Text = registration.CourseClassObj.EndDate.ToString();
            courseRow.Cells.Add(endDate);

            TableCell updateID = new TableCell();
            HyperLink h = new HyperLink();
            h.Text = "Enable/Disable";
            h.NavigateUrl = "";
            updateID.Controls.Add(h);
            courseRow.Cells.Add(updateID);

            TableCell editID = new TableCell();
            h = new HyperLink();
            h.Text = "Reset Password";
            h.NavigateUrl = "~/Account/ResetPassword";
            editID.Controls.Add(h);
            courseRow.Cells.Add(editID);

            return courseRow;
        }
        public override void RegistraterAction()
        {
            //throw new NotImplementedException();
        }
    }
}