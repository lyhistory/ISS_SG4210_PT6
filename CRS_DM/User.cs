using nus.iss.crs.dm.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm
{
    public class User
    {
        protected UserRole role = null;
                
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string RoleName { get; set; }

        public User()
        { }

                
        public virtual UserRole GetRole()
        {
            return role;
        }
         
    }
}
