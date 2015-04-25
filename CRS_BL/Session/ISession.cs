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
         CourseManager CreateCourseManager();


         void Release();
         User GetCurrentUser();
         bool Login(LogingStrategy strategy);
         bool IsValid();
    }
}
