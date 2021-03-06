﻿using CRS_WF;
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
    public partial class ConfirmCourseClassByAdmin : CrsPageController
    {

        //TODO
        CourseRegistrationManager manager = null;
        ClassManager clsManager = null;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            ShowCourseClassList();
        }

        private void ShowCourseClassList()
        {

            manager = BLSession.CreateCourseRegistrationManager();
            clsManager = BLSession.CreateClassManager();

            List<CourseClass> courseClasses = manager.GetCourseClassWithRegisterCount(DateTime.Now, ClassStatus.ToConfirm);

            CategourCourseList4WF table = (CategourCourseList4WF)Page.LoadControl("./Ctrl/CategourCourseList4WF.ascx");
            table.clsManagerObj = clsManager;
            table.CourseClassObjs = courseClasses;
            PlaceHolder1.Controls.Add(table);
            Label newline = new Label();
            newline.Text = "<BR/>";
            PlaceHolder1.Controls.Add(newline);

        }

        public override void RegistraterAction()
        {
            //throw new NotImplementedException();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //manager = BLSession.CreateCourseRegistrationManager();

            //List<CourseClass> courseClasses = manager.GetCourseClassWithRegisterCount(DateTime.Now, ClassStatus.ToConfirm);
            //CourseClass cls = courseClasses[0];

            //ClassManager clsManager = BLSession.CreateClassManager();
            //test wf = new test();
            //wf.ArgCourseClass = new InOutArgument<CourseClass>(ctx => cls);
            //wf.ArgManager = new InArgument<ClassManager>(ctx => clsManager);
            //WorkflowInvoker.Invoke(wf); 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //manager = BLSession.CreateCourseRegistrationManager();

            //List<CourseClass> courseClasses = manager.GetCourseClassWithRegisterCount(DateTime.Now, ClassStatus.ToConfirm);
            //CourseClass cls = courseClasses[0];

            //ClassManager clsManager = BLSession.CreateClassManager();
            //test wf = new test();
            //wf.ArgCourseClass = new InOutArgument<CourseClass>(ctx => cls);
            //wf.ArgManager = new InArgument<ClassManager>(ctx => clsManager);
            //WorkflowInvoker.Invoke(wf);
        }
    }
}