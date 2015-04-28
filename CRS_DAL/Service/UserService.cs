using CRS_DAL.EF;
using CRS_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DAL.Service
{
    public class UserService
    {
        IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public User GetByLoginID(string loginID)
        {
            return userRepository.GetSingle(g => g.LoginID == loginID);
        }

        public void Add(User user)
        {
            if (!ExistsInInstance(user.LoginID))
                userRepository.Add(user);
            else
                throw new Exception(string.Format("user with LoginID={0} already exists"));
        }

        public bool ExistsInInstance(string loginID)
        {
            return userRepository.GetAll().SingleOrDefault(g => g.LoginID == loginID) != null;
        }
    }
}
