using CRS_DAL.Repository;
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
    
        public User Login(LogingStrategy loginStrategy)
        {
            LoginInfo loginInfo = new LoginInfo();
            loginInfo.loginId = loginStrategy.GetLoginID();
            loginInfo.password = loginStrategy.GetPassword();
            

            //call dal
            //dal.login(logininfo)
            UnitOfWork unitOfWork = new UnitOfWork();
            //User currentUser = unitOfWork.UserService.GetByLoginID(loginInfo.loginId);
            UserExt user = new UserExt();
            //user.AssignRole();//retrieve role from db
            return user;
        }
    }
}
