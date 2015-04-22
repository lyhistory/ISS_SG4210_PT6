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
        LoginManager lgManager = new LoginManager ();
        public User login(LogingStrategy strategy)
        {
            return lgManager.Login(strategy); 
        }
    }
}
