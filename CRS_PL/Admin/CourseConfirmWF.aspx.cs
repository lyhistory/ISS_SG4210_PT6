using CRS_SL;
using nus.iss.crs.bl;
using nus.iss.crs.dm.Course;
using nus.iss.crs.pl.Admin.Ctrl;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin
{
    public partial class CourseConfirmWF : CrsPageController
    {

        //TODO
        CourseRegistrationManager manager = null;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            ShowCourseClassList();
        }

        private void ShowCourseClassList()
        {

            manager = BLSession.CreateCourseRegistrationManager();

            List<CourseClass> courseClasses = manager.GetCourseClassWithRegisterCount(DateTime.Now, ClassStatus.Close);            
            
            {
                CategourCourseList4WF table = (CategourCourseList4WF)Page.LoadControl("./Ctrl/CategourCourseList4WF.ascx");

                table.CourseClassObjs = courseClasses;
                PlaceHolder1.Controls.Add(table);
                Label newline = new Label();
                newline.Text = "<BR/>";
                PlaceHolder1.Controls.Add(newline);
            }
        }

        public override void RegistraterAction()
        {
            //throw new NotImplementedException();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            manager = BLSession.CreateCourseRegistrationManager();

            List<CourseClass> courseClasses = manager.GetCourseClassWithRegisterCount(DateTime.Now, ClassStatus.Close);

            Activity wf = new CRS_WF.CourseConfirmationFlow();

            WorkflowInvoker.Invoke(wf);
         
        }
    }
}