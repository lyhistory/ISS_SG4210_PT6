using nus.iss.crs.bl;
using nus.iss.crs.dm;
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
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (this.IsPostBack)
                return;
            PopulateCouseDetail();
        }

        private void PopulateCouseDetail()
        {
            ParticipantManager participantManager = BLSession.CreateParticipantManager();
            Participant participant = participantManager.GetParticipantByParticipantID(this.Request.QueryString.Get(CRSConstant.ParameterParticipantID));

            UserManager userManager = BLSession.CreateUserManager();
            foreach (Company_DM company in userManager.GetCompanyList())
            {
                ListItem item = new ListItem(company.CompanyName, company.CompanyID);
                companyList.Items.Add(item);
            }

            idNumber.Text = participant.IDNumber;
            employmentStatus.Text = participant.EmploymentStatus;
            companyList.Text = participant.CompanyName;
            salutation.Text = participant.Salutation;
            jobTitle.Text = participant.JobTitle;
            department.Text = participant.Department;
            fullName.Text = participant.FullName;
            organizationSize.Text = participant.OrganizationSize;
            genderList.Text = participant.Gender;
            salaryRange.Text = participant.SalaryRange;
            nationality.Text = participant.Nationality;
            DOB.Text = participant.DOB.ToString();
            email.Text = participant.EMail;
            contactNumber.Text = participant.ContactNumber;
            dietaryRequirement.Text = participant.DietaryRequirement;
        }

         protected void Save_Click(object sender, EventArgs e)
        {
            ParticipantManager participantManager = BLSession.CreateParticipantManager();
            Participant tempParticipant = new Participant();
            currentAction = (AdminAction)CourseAdminAction.Edit;

            tempParticipant.IDNumber = idNumber.Text.ToString();
            tempParticipant.EmploymentStatus = employmentStatus.Text.ToString();
            tempParticipant.CompanyID = companyList.SelectedItem.Value;
            tempParticipant.CompanyName = companyList.SelectedValue;
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