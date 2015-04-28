using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    public class ApplicationFacade
    {
        LoginManager loginManager = new LoginManager ();
        public User login(LogingStrategy strategy)
        {
            return loginManager.Login(strategy); 
        }
    }
}
