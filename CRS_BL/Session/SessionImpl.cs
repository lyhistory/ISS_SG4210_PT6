using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl.Session
{
    public class SessionImpl:ISession
    {
        Guid sessionID = Guid.NewGuid();

        User currentUser;
        internal SessionImpl() { }

        public CourseManager CreateCourseManager()
        {    
            return new CourseManager(this);
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
            LoginManager manager = new LoginManager();
           currentUser= manager.Login(strategy);
           if (currentUser == null)
               return false;
           else
               return true;
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
