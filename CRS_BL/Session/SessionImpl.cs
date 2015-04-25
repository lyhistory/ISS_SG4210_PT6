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
            throw new NotImplementedException();
        }

        public bool Login()
        {
            throw new NotImplementedException();
        }


        public bool Login(dm.LogingStrategy strategy)
        {
            throw new NotImplementedException();
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
