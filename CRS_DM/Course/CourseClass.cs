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
        public Course CourseObj{get;set;}
         
        public CourseClass(Course course)
        {
            this.CourseObj = course;
            course.AddClass(this); 
        }

        public CourseClass()
        {
        }

        public Course GetCourse()
        {
            return CourseObj;
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

        public int NoOfRegedParticipant { get; set; }
    }
}
