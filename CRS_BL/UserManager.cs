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
        private ISession _Session;

        public UserManager(ISession session)
        {
            _Session = session;
        }

        private void AssignRole(User user, UserRole role)
        {
            UserExt ext = new UserExt(user);
            ext.AssignRole(role);
        }

        public User CreateUser()
        {
            ///
            return new User();
        }
        

        public User CreateHRUser()
        {
            ///
            return new HRUser();
        }

        public bool SaveUser(User user) 
        {
            //Individul user,course admin,system admin

            //internal user need to check operator permission
            if (_Session.GetCurrentUser().GetRole() == null) 
            {
                throw new Exception("No Permission.");
            }
            return false;
        }

        public Company CreateCompany()
        {
            return new Company();
        }

        public bool SaveCompanyInformation(Company company)
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


        public User GetUser(string userid)
        {

            User u = new User();
            //u.GetRole

            return new User();//retrieve user from db, assign role 
        }

        public List<User> GetUserList()
        {
            List<User> userList = new List<User>();
            return userList; 
        }

        /// <summary>
        /// update, disable/enable, reset password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool EditUser(User user)
        {
            return false;
        }

        public string GenerateRandomPassword()
        {
            string password = Guid.NewGuid().ToString();
            return password;
        }
    }
}
