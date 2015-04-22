using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm
{
    public class NonLoginStrategy:LogingStrategy
    {

        public string GetLoginID()
        {
            return "";
        }

        public string GetPassword()
        {
            return "";
        }
    }
}
