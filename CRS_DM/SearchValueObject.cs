using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm
{
    public class BaseSearchValueObject
    {
        public string doc_type { get; set; }
        public string crs_id { get; set; }
        public string coursecode { get; set; }
        public string categoryname { get; set; }
        public string coursedesc { get; set; }
        public string instructors { get; set; }
        public string coursetitle { get; set; }
    }
}
