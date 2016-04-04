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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Parents()
        {
            ParentRequest model = new ParentRequest();
            return View(model);
        }

        [HttpPost]
        public ActionResult Parents(ParentRequest model)
        {
            // get email content
            string emailText = model.GetEmailText();
            string emailSubject = "Nationwide Nannies";

            // add code to send email

            // add code to save form data in database

            return View("ParentThankyou");
        }


        public ActionResult Jobs()
        {
            NannyJobEmployment model = new NannyJobEmployment();
            return View(model);
        }

        [HttpPost]
        public ActionResult Jobs(NannyJobEmployment model, HttpPostedFileBase image, HttpPostedFileBase resume)
        {
            Helper.SaveUploadedFile(model.FirstName, model.LastName, resume, Constants.FolderUploadedResumes);
            Helper.SaveUploadedFile(model.FirstName, model.LastName, image, Constants.FolderUploadedPhotos);

            // save files i blob

            // update model with file ids

            // get email content
            string emailText = model.GetEmailText();
            string emailSubject = "Nationwide Nannies";

            // add code to send email

            // add code to save form data in database

            return View("JobsThankyou");
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}