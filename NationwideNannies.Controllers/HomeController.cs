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

        public ActionResult AcceptableUsePolicy()
        {
            return View();
        }

        public ActionResult CookiePolicy()
        {
            return View();
        }

        public ActionResult EqualOpportunites()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult WebsiteTermsOfUse()
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

        public ActionResult Parents(int? clientId)
        {
            ParentRequest model = null;
            if (clientId.HasValue)
            {
                NationWideDbContext dbContext = new NationWideDbContext();
                var results = dbContext.ClientSearch(new ParentRequest() { Id = clientId.Value });
                if (results.Count == 1)
                {
                    model = results[0];
                }
            }

            if (model == null)
            {
                model = new ParentRequest();
            }

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
                string clientEmailText = Utilities.GetEmailTextClients(model.FullName);
                Utilities.SendEmail(model.Email, "Nationwide Nannies confirmation", clientEmailText);
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

        [HttpPost]
        public ActionResult UpdateClientData(ParentRequest model)
        {
            string message = "Record was updates successfully";
            try
            {
                Task.Run(() =>
                {
                    // save form in database
                    NationWideDbContext dbContext = new NationWideDbContext();
                    dbContext.UpdateParentForm(model);
                });
            }
            catch (Exception ex)
            {
                Log4NetLogger.ExceptionTrace(ex, "[HomeController] Parents() database save");
                message = "An error occured while saving the record";
            }

            ViewBag.InfoMessage = message;

            return View("InfoMessage");
        }


        [Authorize]
        public ActionResult Admin()
        {
            return View();
        }

        [Authorize]
        public ActionResult ClientSearch(ParentSearch model)
        {
            NationWideDbContext dbContext = new NationWideDbContext();
            if (model.Mode == 1)
            {
                var searchResults = dbContext.ClientSearch(model.SearchCriteria);
                model.SearchResults = searchResults;
            }

            model.Mode = 1;
            return View(model);
        }

        public ActionResult CandidateSearch(CandidateSearchData model)
        {
            NationWideDbContext dbContext = new NationWideDbContext();
            if (model.Mode == 1)
            {
                var searchResults = dbContext.CandidateSearch(model.SearchCriteria);
                model.SearchResults = searchResults;
            }
            else
            {
                model.SearchCriteria.HaveCriminalConvictions = string.Empty;
                model.SearchCriteria.HaveMedicalConditions = string.Empty;
                model.SearchCriteria.IsOfstedRegistered = string.Empty;
            }

            model.Mode = 1;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateCandidateData(NannyJobEmployment model, HttpPostedFileBase image, HttpPostedFileBase resume)
        {
            string message = "Record was updates successfully";

            string filePathResume = Utilities.SaveUploadedFile(model.FullName, resume, Constants.FolderUploadedResumes);
            string filePathPhoto = Utilities.SaveUploadedFile(model.FullName, image, Constants.FolderUploadedPhotos);


            // update model with file paths
            model.ResumeFilePath = filePathResume;
            model.ImageFilePath = filePathPhoto;

            try
            {
                Task.Run(() =>
                {
                    // save form in database
                    NationWideDbContext dbContext = new NationWideDbContext();
                    dbContext.UpdateJobForm(model);
                });
            }
            catch (Exception ex)
            {
                Log4NetLogger.ExceptionTrace(ex, "[HomeController] Parents() database save");
                message = "An error occured while saving the record";
            }

            ViewBag.InfoMessage = message;

            return View("InfoMessage");
        }

        public ActionResult Jobs(int? candidateId)
        {
            NannyJobEmployment model = null;
            if (candidateId.HasValue)
            {
                NationWideDbContext dbContext = new NationWideDbContext();
                var results = dbContext.CandidateSearch(new NannyJobEmployment() { Id = candidateId.Value });
                if (results.Count == 1)
                {
                    model = results[0];
                }
            }

            if (model == null)
            {
                model = new NannyJobEmployment();
            }
            
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
                string candidateEmailText = Utilities.GetEmailTextCandidates(model.FullName);
                Utilities.SendEmail(model.Email, "Nationwide Nannies confirmation", candidateEmailText);
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


        public ActionResult ForwardResumeToClient(int clientId, string email, string message)
        {
            NationWideDbContext dbContext = new NationWideDbContext();
            NannyJobEmployment searchCriteria = new NannyJobEmployment()
            {
                Id = clientId
            };

            var searchResults = dbContext.CandidateSearch(searchCriteria);

            if (searchResults.Count == 0)
            {
                return Json(new { success = false, responseText = "No Record found for Candidate." }, JsonRequestBehavior.AllowGet);
            }

            if (searchResults.Count > 1)
            {
                return Json(new { success = false, responseText = "Multiple records found for for Candidate." }, JsonRequestBehavior.AllowGet);
            }

            var candidateData = searchResults[0];

            // get email content
            string emailText = message;
            string emailSubject = "Nantionwide Nannies";
            string toEmail = ConfigurationManager.AppSettings["EmployeeEmails"];

            toEmail = string.Format("{0},{1}", email, toEmail);

            // add code to send email
            string fullPathResume = Utilities.GetAbsoluteFilePath(Constants.FolderUploadedResumes, candidateData.ResumeFilePath);
            string fullPathPhoto = Utilities.GetAbsoluteFilePath(Constants.FolderUploadedPhotos, candidateData.ImageFilePath);

            try
            {
                Utilities.SendEmail(toEmail, emailSubject, emailText, new List<string>() { fullPathResume, fullPathPhoto });
            }
            catch (Exception ex)
            {
                Log4NetLogger.ExceptionTrace(ex, "[HomeController] ForwardResumeToClient() send email");
            }

            return Json(new { success = true, responseText = "Your message successfuly sent!" }, JsonRequestBehavior.AllowGet);
        }
    }
}