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
        
                
        //common for individual and staff
        public string UserID { get; set; }  //GUID
        public string LoginID { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        //for hr
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string JobTitle { get; set; }
        public string FaxNumber { get; set; }


        //roles
        protected UserRole role = null;

        public string RoleName { get; set; }

        public User()
        { }


        public virtual UserRole GetRole()
        {
            return role;
        }
         
    }
}
