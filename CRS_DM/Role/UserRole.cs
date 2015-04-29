using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm.Role
{
    public class UserRole
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }

        public long AccessPermission { get; set; }//temporary 
        public long DeniedPermission { get; set; }//temporary 
    }
}
