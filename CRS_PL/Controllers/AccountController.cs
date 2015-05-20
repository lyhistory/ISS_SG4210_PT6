using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nus.iss.crs.pl.Controllers
{
    public class AccountController: AuthController
    {
        //Account Center
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}