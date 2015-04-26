using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm
{
    public class PublicUser:User
    {
        public PublicUser()
        {
            this.UserID = "";//TODO: generate a random user id
            this.Password = "";//TODO: generate a random password
        }

    }
}
