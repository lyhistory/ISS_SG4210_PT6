using nus.iss.crs.dm;
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

        }

        public TableRow CreateCourseRow(User user)
        {

            TableRow courseRow = new TableRow();
            TableCell userID = new TableCell();
            userID.Text = user.UserID;
            courseRow.Cells.Add(userID);

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

            TableCell status = new TableCell();
            status.Text = "Enable";//(user.Status is true)? "Enable"："Disable"；
            courseRow.Cells.Add(status);

            TableCell editID = new TableCell();
            HyperLink h = new HyperLink();
            h.Text = "Edit";
            h.NavigateUrl = "~/Admin/EditUser.aspx?" + CRSConstant.ParameterUserID + "=" + user.UserID;

            editID.Controls.Add(h);
            courseRow.Cells.Add(editID);

            TableCell deleteID = new TableCell();
            LinkButton lb = new LinkButton();
            lb.Text = "Delete";

            lb.OnClientClick = "";
            deleteID.Controls.Add(lb);
            courseRow.Cells.Add(deleteID);

            TableCell updateID = new TableCell();
            h = new HyperLink();
            h.Text = "Enable/Disable";
            h.NavigateUrl = "";
            updateID.Controls.Add(h);
            courseRow.Cells.Add(updateID);

            return courseRow;
        }

        void lb_Click(User user)
        {

        }

        public User User { get; set; }
    }
}