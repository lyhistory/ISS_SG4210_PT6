using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
using nus.iss.crs.pl.Admin.Ctrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin
{
    public partial class ListUser : CrsPageController
    {
        UserManager manager = null;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            ShowCourseList();
        }

        private void ShowCourseList()
        {
            //CourseManager manager = BLSession.CreateCourseManager();
            if (BLSession == null)
            {
                ISession session = new SessionImplement();
                manager = session.CreateUserManager();
            }
            else
            {
                manager = BLSession.CreateUserManager();
            }

            foreach (dm.User user in manager.GetUserList())
            {
                //UserList table = (UserList)Page.LoadControl("./Ctrl/UserList.ascx");

                //table.User = user;
                //PlaceHolder1.Controls.Add(table);
                //Label newline = new Label();
                //newline.Text = "<BR/>";
                //PlaceHolder1.Controls.Add(newline);
                Table1.Rows.Add(CreateCourseRow(user));
            }
        }

        public TableRow CreateCourseRow(dm.User user)
        {
            TableRow courseRow = new TableRow();

            TableCell logInID = new TableCell();
            logInID.Text = user.LoginID;
            courseRow.Cells.Add(logInID);

            TableCell name = new TableCell();
            name.Text = user.Name;
            courseRow.Cells.Add(name);

            TableCell contactNumber = new TableCell();
            contactNumber.Text = user.Email;
            courseRow.Cells.Add(contactNumber);

            TableCell companyName = new TableCell();
            companyName.Text = user.CompanyName;
            courseRow.Cells.Add(companyName);

            TableCell editID = new TableCell();
            HyperLink h = new HyperLink();
            h.Text = "Reset Password";
            h.NavigateUrl = "~/Account/ResetPassword";
            editID.Controls.Add(h);
            courseRow.Cells.Add(editID);

            //TableCell updateID = new TableCell();
            //h = new HyperLink();
            //h.Text = "Enable/Disable";
            //h.NavigateUrl = "";
            //updateID.Controls.Add(h);
            //courseRow.Cells.Add(updateID);

            return courseRow;
        }

        public override void RegistraterAction()
        {
            //throw new NotImplementedException();
        }
    }
}

