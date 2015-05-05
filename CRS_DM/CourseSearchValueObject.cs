using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm
{
    public class CourseSearchValueObject:BaseSearchValueObject
    {
        public string coursecode { get; set; }
        public string coursetitle { get; set; }
        public string coursedesc { get; set; }
        public string instructors { get; set; }
        public string categoryname { get; set; }
    }
}
