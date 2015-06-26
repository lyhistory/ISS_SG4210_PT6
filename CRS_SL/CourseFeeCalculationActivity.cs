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

    public sealed class CourseFeeCalculationActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> Text { get; set; }

        public InArgument<CourseClass> courseClass { get; set; }

        public InArgument<ClassManager> manager { get; set; }


        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            LogHelper _log = LogHelper.GetLogger(typeof(CourseFeeCalculationActivity));
            // Obtain the runtime value of the Text input argument
            string text = context.GetValue(this.Text);
 
            CourseClass courseClass = context.GetValue(this.courseClass);
            ClassManager manager = context.GetValue(this.manager);

            //get participant list of class
            //check participant id type ==> local or foreigner
            //30% for local subsidy
            //log result in log file
            List<Participant> participantList = manager.GetCourseClassParticipantList(courseClass);
            foreach (Participant participant in participantList)
            {
                //for local subsidy
                if (participant.IsLocal == 1)
                {
                    string fee = courseClass.CourseObj.Fee;
                    string subsidy = (double.Parse(fee) * 0.3).ToString();
                    _log.Debug(string.Format("Send Email: Participant:{0},Fee:{1},Subsidy:{2}", participant.FullName, fee, subsidy));
                }
                else if (participant.IsLocal == 0)
                {
                    string fee = courseClass.CourseObj.Fee;
                    string subsidy = "0";
                    _log.Debug(string.Format("Send Email: Participant:{0},Fee:{1},Subsidy:{2}", participant.FullName, fee, subsidy));
                }
            } 
        }
    }
}
