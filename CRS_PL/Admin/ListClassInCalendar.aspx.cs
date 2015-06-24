using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
using nus.iss.crs.dm.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin
{
    public partial class ListCourseInCalendar : CrsPageController
    {
        CourseManager manager = null;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if(BLSession == null)
            {
                ISession session = new SessionImplement();
                manager = session.CreateCourseManager();
            }
            else
            {
                manager = BLSession.CreateCourseManager();
            }

            if(IsPostBack)
            {

            }
            else
            {
                CalStartDate.Visible = false;
            }
        }

        private void ShowCourseClassList()
        {
            //List<CourseClass> courseClassList = manager.GetCourseClassList(null,)
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (CalStartDate.Visible == false)
            {
                CalStartDate.Visible = true;
            }
            else
            {
                CalStartDate.Visible = false;
            }
        }

        protected void ImageButton1_SelectionChanged(object sender, ImageClickEventArgs e)
        {
            txtStartDate.Text = CalStartDate.SelectedDate.ToString();
        }

        public override void RegistraterAction()
        {
            //throw new NotImplementedException();
        }
    }
}