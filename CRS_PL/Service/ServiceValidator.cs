using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Web;

namespace nus.iss.crs.pl.Service
{
    public class ServiceValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (!userName.Equals("user") || !password.Equals("password"))
                // throw new SecurityTokenException("Unknown user.");
                Console.Write("Unknown user");
            Console.Write("Done: Credentials accepted. \n");
        }
    }
}