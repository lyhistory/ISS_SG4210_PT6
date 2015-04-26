using nus.iss.crs.dm;
using nus.iss.crs.dm.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    public class UserExt:User
    {
        User user;

        public UserExt()
        {
            user = new User();
        }


        public UserExt(User user)
        {
            this.user = user;
        }

        internal void AssignRole(UserRole role)
        {            
            this.role = role;
        }

        public override UserRole GetRole()
        {
            if (this.role == null)
            {
                //call DAL to retrieve role
            }
            return base.GetRole(); 
        }
    }
}
