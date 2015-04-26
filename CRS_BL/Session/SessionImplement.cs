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
        string sessionID;
        DateTime lastUpdateTime;
        User currentUser;

        internal SessionImplement() 
        {
            
        }

        public void Release()
        {
            throw new NotImplementedException();
        }

        public dm.User GetCurrentUser()
        {
            return this.currentUser;
        }

        public bool Login()
        {
            throw new NotImplementedException();
        }


        public bool Login(dm.LogingStrategy strategy)
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

        public string getSessionID() 
        {
            Guid sessionID = new Guid();
            sessionID = Guid.NewGuid();
            return sessionID.ToString();
        }

        public CourseManager CreateCourseManager()
        {
            return new CourseManager(this);
        }

        public UserManager CreateUserManager() {
            return new UserManager();
        }
    }
}
