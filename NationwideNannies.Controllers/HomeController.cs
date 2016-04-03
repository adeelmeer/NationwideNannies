using NationwideNannies.Models;
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
            //product.ImageMimeType = image.ContentType;
            //product.ImageData = new byte[image.ContentLength];
            //image.InputStream.Read(product.ImageData, 0, image.ContentLength);

            var streamImage = image.InputStream;
            var streamResume = resume.InputStream;

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