using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm
{
    public class IDLoginStrategy:LogingStrategy
    {
        IndividualUser indiv = null;
        public IDLoginStrategy(User user)
        {
            indiv = (IndividualUser)user;
        }

        public string GetLoginID()
        {
            throw new NotImplementedException();
        }

        public string GetPassword()
        {
            throw new NotImplementedException();
        }
    }
}
