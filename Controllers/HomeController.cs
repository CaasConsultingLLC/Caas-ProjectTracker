using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Caas_ProjectTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "CAAS Project Tracking Portal (CPTP)";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "For General Info:";

            return View();
        }
    }
}