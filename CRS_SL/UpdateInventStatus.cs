using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using nus.iss.crs.dm.Course;
using nus.iss.crs.bl;

namespace CRS_WF
{

    public sealed class UpdateInventStatus : CodeActivity
    {
        // Define an activity input argument of type string 
        public InArgument<CourseClass> courseClass { get; set; }
        public InArgument<ClassManager> manager { get; set; }
 

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument           
        
            CourseClass courseClass = context.GetValue(this.courseClass);
            ClassManager manager = context.GetValue(this.manager);            

            manager.ToConfirmCourseClass(courseClass);
        }
    }
}
