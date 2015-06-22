using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin
{
    public partial class ListCourseRegistraton : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.IsPostBack)
            {
 
            }else
            {
                PopulateCourseList();
            }
        }

        private void PopulateCourseList()
        {
            courseListID.Items.Add("Please select course ...");

            //foreach (Registration courseCategory in C)
            //{
            //    ListItem item = new ListItem(courseCategory.Name, courseCategory.ID);
            //    categoryListID.Items.Add(item);
            //}
        }

    }
}