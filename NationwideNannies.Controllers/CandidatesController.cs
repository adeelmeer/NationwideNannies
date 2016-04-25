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
  public  class CandidatesController : Controller
    {
      public ActionResult WorkingWithYou()
      {
          return View();
      }

      public ActionResult RoleResponsibilitiesNanny()
      {
          return View();
      }

      public ActionResult ObtainQualification()
      {
          return View();
      }

      public ActionResult SelectionNannies()
      {
          return View();
      }

      public ActionResult SelectionBabySitters()
      {
          return View();
      }

      public ActionResult CurrentVacancies()
      {
          return View();
      }
    }
}
