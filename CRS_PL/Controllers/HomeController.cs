using CRS_COMMON.Logs;
using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CR_PL.Controllers
{
    public class HomeController : Controller
    {
        private static LogHelper _log = LogHelper.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            _log.Debug("test about");
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            TestBL();

            return View();
        }

        public ActionResult TestBL()
        {
            nus.iss.crs.dm.User loginUser = new nus.iss.crs.dm.User();
            ISession session = SessionFactory.CreateSession();
            session.Login(new IDLoginStrategy(loginUser));

            User validUser = session.GetCurrentUser();
            validUser.GetRole();           
            

            return View();
        }
    }
}