using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm
{
    public class EmailLoginStrategy:LogingStrategy
    {
        HRUser hr = null;

        public EmailLoginStrategy(User user)
        {
            hr = (HRUser)user;
        }

        public string GetLoginID()
        {
            return hr.email;
        }

        public string GetPassword()
        {
            throw new NotImplementedException();
        }
    }
}
