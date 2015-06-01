using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using nus.iss.crs.dm.Course;

namespace CRS_SL
{

    public sealed class UpadateCancelStatus : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> Text { get; set; }

        public InArgument<CourseClass> courseClass { get; set; }

        public OutArgument<string> status { get; set; }
        public OutArgument<string > message { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument           
            string Text = context.GetValue(this.Text);
            CourseClass courseClass = context.GetValue(this.courseClass);

            context.SetValue(status, "Canceled");
            context.SetValue(message, "Class course canceled.");
            //status = "Canceled";
        }
    }
}
