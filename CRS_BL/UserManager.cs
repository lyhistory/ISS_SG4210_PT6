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
            //Individul user,course admin,system admin

            //internal user need to check operator permission
            if (session.GetCurrentUser().GetRole() == null) 
            {
                throw new Exception("No Permission.");
            }
            return false;
        }

        public bool createHRUser(User user, ISession session)
        {
            //HR user,email address as user Id
            if (session.GetCurrentUser().GetRole() == null) 
            {
                throw new Exception("No Permission.");
            }

            return false;
        }

        public bool registerCompanyInformation(Company company)
        {
            return false;
        }

        public Company GetCompanyByID(string companyID)
        {
            Company company = new Company();
            return company;
        }

        public List<Company> GetCompanyList()
        {
            List<Company> companyList = new List<Company>();
            return companyList;
        }
    }
}
