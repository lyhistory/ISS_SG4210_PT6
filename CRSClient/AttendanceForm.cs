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

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
          AttendanceService.Participant[] students =   client.GetStudents(txtCourse.Text, startDate.Value, endDate.Value);

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
