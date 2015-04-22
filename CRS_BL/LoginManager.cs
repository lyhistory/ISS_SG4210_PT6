using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    public class LoginManager
    {
        public LoginManager()
        {}
    
        public User Login(LogingStrategy strategy)
        {
            LoginInfo info = new LoginInfo();
            info.loginId = strategy.GetLoginID();
            info.password = strategy.GetPassword();           

            //call dal
            //dal.login(logininfo)
            User user = new HRUser();//retrieve from DAL
            return user;
        }
    }
}
