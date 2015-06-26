using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using nus.iss.crs.dm.Course;
using nus.iss.crs.bl;
using CRS_COMMON.Logs;
using nus.iss.crs.dm.Registration;

namespace CRS_WF
{

    public sealed class NotifyByEmail : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> Text { get; set; }
        
        public InArgument<CourseClass> courseClass { get; set; }

        public InArgument<ClassManager> manager { get; set; }
        
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            LogHelper _log = LogHelper.GetLogger(typeof(NotifyByEmail));
            // Obtain the runtime value of the Text input argument
            string text = context.GetValue(this.Text);
            
            CourseClass courseClass = context.GetValue(this.courseClass);
            ClassManager manager = context.GetValue(this.manager);

            //course class has been cancele
            //log cancalled for each participant registered as email sending
            List<Participant> participantList = manager.GetCourseClassParticipantList(courseClass);
            foreach (Participant participant in participantList)
            {
                if (courseClass.Status == ClassStatus.Canceled)
                {
                    _log.Debug(string.Format("Send Email: Participant:{0},Course:{1},Class:{2},Status:Canceled", participant.FullName, courseClass.CourseObj.CourseTitle, courseClass.ClassCode));
                }
                else if (courseClass.Status == ClassStatus.Confirmed)
                {
                    _log.Debug(string.Format("Send Email: Participant:{0},Course:{1},Class:{2},Status:Confirmed", participant.FullName, courseClass.CourseObj.CourseTitle, courseClass.ClassCode));
                }
            }
        }
    }
}
