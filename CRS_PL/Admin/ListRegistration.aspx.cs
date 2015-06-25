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

            foreach (Registration registration in manager.GetRegistrationList())
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

            TableCell disableID = new TableCell();
            LinkButton disableLb = new LinkButton();
            disableLb.Text = "Enable /Disable";
            disableLb.OnClientClick = "javascript:return ChangeRegistrationStatus(this);";
            disableLb.CommandName = "Disable";
            disableLb.CommandArgument = registration.RegID;
            disableID.Controls.Add(disableLb);
            courseRow.Cells.Add(disableID);

            TableCell editID = new TableCell();
            HyperLink h = new HyperLink();
            h.Text = "Move";
            h.NavigateUrl = "";
            editID.Controls.Add(h);
            courseRow.Cells.Add(editID);

            TableCell cancelID = new TableCell();
            LinkButton cancelLb = new LinkButton();
            cancelLb.Text = "Cancel";
            cancelLb.OnClientClick = "javascript:return CancelRegistration(this);";
            cancelID.Controls.Add(cancelLb);
            courseRow.Cells.Add(cancelID);

            return courseRow;
        }

        protected void ChangeRegistrationStatus_Click(object sender, EventArgs e )
        {

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