using CRSClient.AttendanceService;
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
    public partial class AttendanceForm : Form
    {
        AttendanceService.AttendanceServiceClient client = new AttendanceService.AttendanceServiceClient();
        public AttendanceForm()
        {
            InitializeComponent();
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            //client.GetStudents()
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Participant owner = null;
            foreach (ListViewItem item in lvStudent.Items)
            {
                Participant p = (Participant)item.Tag;
                if (p.IDNumber == txtID.Text)
                { 
                    owner = p;
                    break;
                }
            }
            string status =  client.SubmitAttendance(owner.ParticipantID, AttendanceStatus.Attended, txtRemark.Text, txtCourse.Text, startDate.Value, endDate.Value);
            MessageBox.Show("Submit Status:" + status);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCourse.Text))
            {
                MessageBox.Show("Please input your course code");
                return;
            }
          AttendanceService.Participant[] students =   client.GetStudents(txtCourse.Text, startDate.Value, endDate.Value);
          if (students == null)
          {
              MessageBox.Show("No Student for this course with the date");
              return;
          }
          lvStudent.Items.Clear();
          foreach (Participant p in students)
          {
              ListViewItem item = new ListViewItem(p.FullName);
              item.Tag = p;
              if (p.IDNumber == txtID.Text)
              {
                  item.BackColor = Color.Orange;
              }
              lvStudent.Items.Add(item);
          }
        }
    }
}
