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
    public partial class LoginForm : Form
    {
        private LoginInfo info = new LoginInfo();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            info.LoginId = txtLoginID.Text;
            info.Password = txtPassword.Text;
            this.DialogResult = DialogResult.OK;
        }

        internal  LoginInfo LoginInfoObj
        {
            get { return info; }
        }
    }
}
