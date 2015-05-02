
using CRS_DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DAL.ModelMapper
{
    public class CourseClassMapper : CourseClass
    {
        public string CourseID { get; set; }
        public string CourseTitle { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Fee { get; set; }
        public string Instructors { get; set; }
        public int NumberOfDays { get; set; }
        public string CategoryID { get; set; }
    }
}
