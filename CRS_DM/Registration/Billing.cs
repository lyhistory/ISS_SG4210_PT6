using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm.Registration
{
    [DataContract]
    public class Billing
    {
        [DataMember]
        public string PersonName { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string PostalCode { get; set; }
    }
}
