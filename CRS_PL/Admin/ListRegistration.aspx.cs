using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
using nus.iss.crs.dm;
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
    public partial class ListRegistration : CrsPageController
    {
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

            List<Registration> regs = manager.GetRegistrationList();
            if (regs == null)
                return;
            foreach (Registration registration in regs)
            {
                if (registration.CourseClassObj != null)
                {
                    Table1.Rows.Add(CreateRegistrationRow(registration));
                }
                
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
            courseName.Text = registration.CourseClassObj.GetCourse().CourseTitle;
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

            //TableCell disableID = new TableCell();
            //LinkButton lb = new LinkButton();
            //lb.Text = "Enable /Disable";
            //lb.CommandName = "Disable";
            //lb.CommandArgument = registration.RegID;
            //lb.Click += new EventHandler(lb_Command);
            //disableID.Controls.Add(lb);
            //courseRow.Cells.Add(disableID);

            TableCell moveID = new TableCell();
            HyperLink h = new HyperLink();
            h.Text = "Move";
            h.NavigateUrl = "";
            moveID.Controls.Add(h);
            courseRow.Cells.Add(moveID);

            TableCell editID = new TableCell();
            h = new HyperLink();
            h.Text = "Edit";
            h.NavigateUrl = "~/Admin/EditCourseRegistration.aspx?" + CRSConstant.ParameterParticipantIDNumber + "=" + registration.ParticipantObj.IDNumber;
            editID.Controls.Add(h);
            courseRow.Cells.Add(editID);

            TableCell cancelID = new TableCell();
            LinkButton lb = new LinkButton();
            lb.Text = "Cancel";
            lb.CommandName = "Cancel";
            lb.CommandArgument = registration.RegID;
            lb.Click += new EventHandler(lb_Command);
            cancelID.Controls.Add(lb);
            courseRow.Cells.Add(cancelID);

            return courseRow;
        }

        protected void lb_Command(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;

            if (lb.CommandName == "Cancel")
            {
                //manager.DeleteCourse(lb.CommandArgument);
            }
        }

        public override void RegistraterAction()
        {
            //throw new NotImplementedException();
        }

        protected void SearchRegistration_Click(object sender, EventArgs e)
        {
            TableRow row1 = Table1.Rows[0];
            Table1.Rows.Clear();
            Table1.Rows.Add(row1);

            List<Registration> registrationList = new List<Registration>();
            Participant tempParticipant = new Participant();

            // 0.base on participant name; 1.base on participant IDNumber; 2.company
            if (searchConditionList.SelectedIndex == 0)
            {
                tempParticipant.FullName = searchValue.Text.ToString();
                registrationList = manager.GetRegistrationListByParticipant(tempParticipant);
            }
            else if (searchConditionList.SelectedIndex == 1)
            {
                tempParticipant.IDNumber = searchValue.Text.ToString();
                registrationList = manager.GetRegistrationListByParticipant(tempParticipant);
            }
            else if (searchConditionList.SelectedIndex == 2)
            {
                UserManager userManager = BLSession.CreateUserManager();
                Company_DM tempCompany = userManager.GetCompanyByName(searchValue.Text.ToString());
                registrationList = manager.GetRegistrationListByCompany(tempCompany);
            }

            if (registrationList != null)
            {
                foreach (Registration registration in registrationList)
                {
                    if (registration.CourseClassObj != null)
                    {
                        Table1.Rows.Add(CreateRegistrationRow(registration));
                    }
                }
            }
        }

    }
}