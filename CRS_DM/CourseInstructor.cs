using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm
{
    public class CourseInstructor
    {
        public string ID { get; set; }
        public string Name {get;set;}
        public CourseInstructor(string ID,string name)
        {
            this.ID = ID;
            this.Name = name;
        }
    }
}
