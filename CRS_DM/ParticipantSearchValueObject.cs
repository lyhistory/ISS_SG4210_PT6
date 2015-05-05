using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm
{
    public class ParticipantSearchValueObject:BaseSearchValueObject
    {
        public string idnumber { get; set; }
        public string fullname { get; set; }
        public string companyname { get; set; }
    }
}
