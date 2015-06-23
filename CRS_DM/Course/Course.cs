using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm.Course
{
    [DataContract]
    public class Course
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string CourseTitle { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Fee { get; set; }

        [DataMember]
        public string ClassTime { get; set; }
        
        public CourseInstructor Instructor { get; set; }

        [DataMember]
        public int Duration { get; set; }

        public CourseCategory Category { get; set; }
        public CourseStatus Status { get; set; }

        public bool IsValid()
        {            
            if (Duration< 1 || Duration > 6)
                return false;
            if (Instructor == null)
                return false;
            if (Category == null)
                return false;
            if (string.IsNullOrWhiteSpace(Code))
                return false;

            return true;
        }

        protected List<CourseClass> _CourseClasses = new List<CourseClass>();
        public List<CourseClass> CourseClasses { get { return _CourseClasses; } set { _CourseClasses = value; } }
        public Dictionary<string, string> MonthCourseClass
        {
            get
            {
                Dictionary<string, string> _groupbyMonth = new Dictionary<string, string>();
                foreach (var item in GetClassList())
                {
                    if (_groupbyMonth.ContainsKey(item.StartMonth.ToString()))
                    {
                        _groupbyMonth[item.StartMonth.ToString()] += "," + item.StartDay;
                    }
                    else
                    {
                        _groupbyMonth[item.StartMonth.ToString()] = item.StartDay.ToString();
                    }
                }
                return _groupbyMonth;
            }
        }
        public  List<CourseClass> GetClassList()
        {
            return _CourseClasses;
        }

        
        /// <summary>
        /// one class belong to one course, not allow to add a class with different course
        /// </summary>
        /// <param name="cls"></param>
 
        public void AddClass(CourseClass cls)
        {
            if (_CourseClasses.Contains(cls))
                return;
            if (!cls.GetCourse().Code.Equals(this.Code))
                return;
            _CourseClasses.Add(cls);
        }

        public void AddClassList(List<CourseClass> classes)
        {
            foreach (CourseClass cls in classes)
                AddClass(cls);             
        }
    }
}
