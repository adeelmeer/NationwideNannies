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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //HelperFacade hf = DBHelper.GetHelperFacade();

            //var dt = hf.LoadTable("Customers");

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactUs model)
        {
            // get email content
            string emailText = model.GetEmailText();
            string emailSubject = "Contact Us From";
            string toEmail = ConfigurationManager.AppSettings["EmployeeEmails"];

            try
            {
                Utilities.SendEmail(toEmail, emailSubject, emailText);
            }
            catch (Exception ex)
            {
                Log4NetLogger.ExceptionTrace(ex, "[HomeController] Contact() send email");
            }

            return View("ContactUsThankyou");
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
            string emailSubject = "Clients from";
            string toEmail = ConfigurationManager.AppSettings["EmployeeEmails"];

            try
            {
                Utilities.SendEmail(toEmail, emailSubject, emailText);
            }
            catch (Exception ex)
            {
                Log4NetLogger.ExceptionTrace(ex, "[HomeController] Parents() send email");
            }
            try
            {
                Task.Run(() =>
                {
                    // save form in database
                    NationWideDbContext dbContext = new NationWideDbContext();
                    dbContext.SaveParentForm(model);
                });

            }
            catch (Exception ex)
            {
                Log4NetLogger.ExceptionTrace(ex, "[HomeController] Parents() database save");
            }
            return View("ParentThankyou");
        }

        [Authorize]
        public ActionResult Admin()
        {
            return View();
        }

        //[Authorize]
        //public ActionResult ClientSearch()
        //{
          

        //    return View();
        //}

        //[Authorize]
        
        public ActionResult ClientSearch(ParentSearch model)
        {
            NationWideDbContext dbContext = new NationWideDbContext();
            var searchResults = dbContext.ClientSearch(model.SearchCriteria);


            model.SearchResults = searchResults;

            return View(model);
        }

        public ActionResult Jobs()
        {
            NannyJobEmployment model = new NannyJobEmployment();
            return View(model);
        }

        [HttpPost]
        public ActionResult Jobs(NannyJobEmployment model, HttpPostedFileBase image, HttpPostedFileBase resume)
        {
            // save files to disk
            string filePathResume = Utilities.SaveUploadedFile(model.FullName, resume, Constants.FolderUploadedResumes);
            string filePathPhoto = Utilities.SaveUploadedFile(model.FullName, image, Constants.FolderUploadedPhotos);


            // update model with file paths
            model.ResumeFilePath = filePathResume;
            model.ImageFilePath = filePathPhoto;

            // get email content
            string emailText = model.GetEmailText();
            string emailSubject = "Candidates From";
            string toEmail = ConfigurationManager.AppSettings["EmployeeEmails"];

            // add code to send email
            string fullPathResume = Utilities.GetAbsoluteFilePath(Constants.FolderUploadedResumes, filePathResume);
            string fullPathPhoto = Utilities.GetAbsoluteFilePath(Constants.FolderUploadedPhotos, filePathPhoto);

            try
            {
                Utilities.SendEmail(toEmail, emailSubject, emailText, new List<string>() { fullPathResume, fullPathPhoto });
            }
            catch (Exception ex)
            {
                Log4NetLogger.ExceptionTrace(ex, "[HomeController] Jobs() send email");
            }

            try
            {
                Task.Run(() =>
                {
                    // save form in database
                    NationWideDbContext dbContext = new NationWideDbContext();
                    dbContext.SaveJobForm(model);
                });
            }
            catch (Exception ex)
            {
                Log4NetLogger.ExceptionTrace(ex, "[HomeController] Jobs() database save");
            }
            return View("JobsThankyou");
        }

    }
}