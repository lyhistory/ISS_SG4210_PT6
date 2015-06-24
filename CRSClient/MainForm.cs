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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnRegistrateCourse_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
           // if (login.ShowDialog() == DialogResult.OK)
            {
                CourseRegstrationForm registrationForm = new CourseRegstrationForm(login.LoginInfoObj);
                registrationForm.ShowDialog();
            }
            
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            AttendanceForm form = new AttendanceForm();
            form.ShowDialog();
        }

        private void btnCourseComplete_Click(object sender, EventArgs e)
        {

        }

        private void btnCourseConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}
