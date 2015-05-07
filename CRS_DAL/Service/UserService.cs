using CRS_DAL.EF;
using CRS_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dm = nus.iss.crs.dm;
namespace CRS_DAL.Service
{
    public class UserService
    {
        IUnitOfWork unitOfWork;
        IRepository<User> userRepository;

        public UserService(IUnitOfWork uow,IRepository<User> userRepository)
        {
            this.unitOfWork = uow;
            this.userRepository = userRepository;
        }

        public dm.User GetByLoginID(string loginID)
        {
            var _user = userRepository.GetSingleOrDefault(g => g.LoginID == loginID);
            if (_user != null)
            {
                return new dm.User()
                {
                    UserID = _user.UserID,
                    LoginID=_user.LoginID,
                    Password = _user.Password,
                    RoleName = _user.UserType.Equals("2") ? "HR" : "User"
                };
            }
            return null;
        }
        
        public void Add(dm.User user)
        {
            if (!ExistsInInstance(user.UserID))
            {

                userRepository.Add(new User()
                {
                    UserID = Guid.NewGuid().ToString(),
                    LoginID=user.LoginID,
                    Password=user.Password,
                    UserType=user.RoleName.Equals("HR") ? 2 : 1
                });

                this.unitOfWork.Commit();
            }
            else
                throw new Exception(string.Format("user with LoginID={0} already exists"));
        }

        public bool ExistsInInstance(string loginID)
        {
            return userRepository.GetAll().SingleOrDefault(g => g.LoginID == loginID) != null;
        }
    }
}
