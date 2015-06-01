using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm.Course
{
    [DataContract]
    public class CourseClass
    {
        private Course course;
         
        public CourseClass(Course course)
        {
            this.course = course;
            course.AddClass(this); 
        }

        public Course GetCourse()
        {
            return course;
        }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public string ClassCode { get; set; }

        [DataMember]
        public int Size { get; set; }

        [DataMember]
        public ClassStatus Status { get; set; }

        //for template
        public int StartMonth
        {
            get
            {
                return StartDate.Month;
            }
        }
        public int StartDay
        {
            get
            {
                return StartDate.Day;
            }
        }

        public string DisplayStartDay { get; set; }
    }
}
