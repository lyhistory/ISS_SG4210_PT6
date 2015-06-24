using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin.Ctrl
{
    public partial class UserList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (dm.User user in userList)
            {
                Table1.Rows.Add(CreateUserRow(user));
            }
        }

        private TableRow CreateUserRow(dm.User user)
        {
            TableRow courseRow = new TableRow();

            TableCell logInID = new TableCell();
            logInID.Text = user.LoginID;
            courseRow.Cells.Add(logInID);

            TableCell name = new TableCell();
            name.Text = user.Name;
            courseRow.Cells.Add(name);

            TableCell email = new TableCell();
            email.Text = user.Email;
            courseRow.Cells.Add(email);

            TableCell contactNumber = new TableCell();
            contactNumber.Text = user.ContactNumber;
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

            TableCell disableID = new TableCell();
            LinkButton lb = new LinkButton();
            lb.Text = "Enable/ Disable";
            lb.OnClientClick = "";
            disableID.Controls.Add(lb);
            courseRow.Cells.Add(disableID);

            return courseRow;
        }

        public List<dm.User> userList { get; set; }
    }
}