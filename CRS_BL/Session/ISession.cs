using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    public interface ISession
    {
        void Release();
        bool IsValid();
        bool Login(LogingStrategy strategy);
        
        User GetCurrentUser();
        CourseManager CreateCourseManager();
    }
}
