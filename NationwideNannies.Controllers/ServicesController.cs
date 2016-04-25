using NationwideNannies.Logging;
using NationwideNannies.Models;
using NationwideNannies.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NationwideNannies.Controllers
{
    public class ServicesController : Controller
    {
        public ActionResult Nannies()
        {
            return View();
        }

        public ActionResult Nurses()
        {
            return View();
        }

        public ActionResult BabySitters()
        {
            return View();
        }

        public ActionResult EmergencyChildcare()
        {
            return View();
        }
    }
}
