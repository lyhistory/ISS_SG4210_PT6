using CRSClient.CourseRegistrationService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRSClient
{
    public partial class CourseRegstrationForm : Form
    {
        CourseRegistrationService.CourseRegistrationServiceClient client = new CourseRegistrationService.CourseRegistrationServiceClient();
        internal CourseRegstrationForm(LoginInfo info)
        {
            InitializeComponent();
            //client.ClientCredentials.UserName.UserName = info.LoginId;
            //client.ClientCredentials.UserName.Password = info.Password;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration ();
            Billing billInfo = new Billing ();
            billInfo.Address = "NUS";
            billInfo.Country = "Singapore";
            billInfo.PersonName = "abc";
            billInfo.PostalCode = "123456";
            
            reg.billingInfo = billInfo;
            reg.DietaryRequirement = "any";
            reg.OrganizationSize = "100";
            reg.Sponsorship = "self";


            ComboItem item =(ComboItem)courseList.SelectedItem;
            Course c = (Course) item.Tag ;


            ComboItem itemP = (ComboItem)cboParticipants.SelectedItem;
            Participant p = (Participant)itemP.Tag;


            client.RegistrateCourse(reg, txtCompanyName.Text, p.IDNumber, c.Code, startDate.Value, endDate.Value);
            
        }

        private void CourseRegstrationForm_Load(object sender, EventArgs e)
        {
            Course[] courses =  client.GetCourses(DateTime.Now, DateTime.Now);
            foreach (Course c in courses)
            {
                ComboItem item = new ComboItem("(" + c.Code + ") " + c.CourseTitle, c.Code, c);
                courseList.Items.Add(item);
            }

            txtCompanyName.Text = "aft";

            Participant[] participants = client.GetEmployees(txtCompanyName.Text);

            foreach (Participant p in participants)
            {
                ComboItem item = new ComboItem("(" + p.IDNumber+ ") " + p.FullName, p.IDNumber, p);
                cboParticipants.Items.Add(item);
            }
        }
    }
}
