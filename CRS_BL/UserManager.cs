using nus.iss.crs.dm;
using nus.iss.crs.dm.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    public class UserManager
    {

        void AssignRole(User user, UserRole role)
        {
            UserExt ext = new UserExt(user);
            ext.AssignRole(role);
        }

        public bool createPublicUser(User user,ISession session) 
        {
            //public user

            //internal user need to check operator permission
            session.GetCurrentUser();
            return false;
        }
    }
}
