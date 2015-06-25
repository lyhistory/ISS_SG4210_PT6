using nus.iss.crs.bl;
using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin
{
    public partial class EditCourseRegistration : CrsPageController
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (this.IsPostBack)
                return;
            PopulateCouseDetail();
        }

        private void PopulateCouseDetail()
        {

        }

         protected void Save_Click(object sender, EventArgs e)
        {
            ParticipantManager participantManager = BLSession.CreateParticipantManager();
            Participant tempParticipant = new Participant();

            tempParticipant.IDNumber = idNumber.Text.ToString();
            tempParticipant.EmploymentStatus = employmentStatus.Text.ToString();
            tempParticipant.CompanyID = companyID.Text.ToString();
            tempParticipant.CompanyName = companyName.Text.ToString();
            tempParticipant.Salutation = salutation.Text.ToString();
            tempParticipant.JobTitle = jobTitle.Text.ToString();
            tempParticipant.Department = department.Text.ToString();
            tempParticipant.FullName = fullName.Text.ToString();
            tempParticipant.OrganizationSize = organizationSize.Text.ToString();
            tempParticipant.Gender = genderList.SelectedValue.ToString();
            tempParticipant.SalaryRange = salaryRange.Text.ToString();
            tempParticipant.Nationality = nationality.Text.ToString();
            tempParticipant.DOB = DateTime.Parse(DOB.Text.ToString());
            tempParticipant.EMail = email.Text.ToString();
            tempParticipant.ContactNumber = contactNumber.Text.ToString();
            tempParticipant.DietaryRequirement = dietaryRequirement.Text.ToString();

            //TODO
            participantManager.EditPariticipant(tempParticipant);
            NextPage(true);
        }

        public override void RegistraterAction()
        {
            RegistraterActionTarget((AdminAction)CourseAdminAction.Edit, typeof(ListRegistration));
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            NextPage(true);
        }

    }
}