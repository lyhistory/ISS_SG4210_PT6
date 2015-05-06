using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl.Session
{
    public class SessionImplement:ISession
    {
        public string sessionID;
        public DateTime lastUpdateTime;
        User currentUser;

        internal SessionImplement() 
        {
            sessionID = Guid.NewGuid().ToString();
            lastUpdateTime = DateTime.Now;
            currentUser = null;
        }

        public string GetSessionID()
        {
            return sessionID;
        }

        public DateTime GetLastUpdateTime() 
        {
            return lastUpdateTime;
        }

        public dm.User GetCurrentUser()
        {
            return this.currentUser;
        }

        public bool Login()
        {
            throw new NotImplementedException();
        }

        public bool Login(LogingStrategy strategy)
        {
            //throw new NotImplementedException();
            LoginManager loginManager = new LoginManager();
            currentUser = loginManager.Login(strategy);

           if (currentUser == null)
               return false;
           else
               return true;
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public void Release()
        {
            throw new NotImplementedException();
        }

        public CourseManager CreateCourseManager()
        {
            return new CourseManager(this);
        }

        //public CourseRegistrationManager CreateCourseRegistrationManager()
        //{
        //    return new CourseRegistrationManager(this);
        //}

        public UserManager CreateUserManager() {
            return new UserManager(this);
        }
    }
}
