using NationwideNannies.Data;
using NationwideNannies.Logging;
using NationwideNannies.Models;
using NationwideNannies.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NationwideNannies.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index()
        {                   
            return View();
        }

        [Route("blog/post/{slug?}")]
        public ActionResult Post(string slug)
        {
            return View();
        }
    }
}
