using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm
{
    public class HRUser:User
    {
        public HRUser()
        { }
        public HRUser(string email, Company company)
        {
        }

        public string email { get; set; }
    }
}
