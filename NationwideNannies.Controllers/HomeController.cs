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

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult Index4()
        {
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
                    model.HandleMultiSelectFromDB();
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
           
            var vInfo = ValidateClientsForm(model);

            if (!vInfo.IsValid)
            {
                ViewBag.ValidationMessage = vInfo.Message;
                return View(model);
            }

            model.HandleMultiSelectFromView();


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

            Task.Run(() =>
            {
                try
                {
                    // save form in database
                    NationWideDbContext dbContext = new NationWideDbContext();
                    dbContext.SaveParentForm(model);
                }
                catch (Exception ex)
                {
                    Log4NetLogger.ExceptionTrace(ex, "[HomeController] Parents() database save");
                }
            });



            return View("ParentThankyou");
        }

        [HttpPost]
        public ActionResult DeleteClientData(ParentRequest model)
        {
            string message = "Record was deleted successfully";


            Task.Run(() =>
            {
                try
                {
                    // save form in database
                    NationWideDbContext dbContext = new NationWideDbContext();
                    dbContext.DeleteParentForm(model);
                }
                catch (Exception ex)
                {
                    Log4NetLogger.ExceptionTrace(ex, "[HomeController] DeleteClientData() database save");
                    message = "An error occured while saving the record";
                }
            });

            ViewBag.InfoMessage = message;

            return View("InfoMessage");
        }

        [HttpPost]
        public ActionResult UpdateClientData(ParentRequest model)
        {
            string message = "Record was updates successfully";
            model.HandleMultiSelectFromView();

            Task.Run(() =>
            {
                try
                {
                    // save form in database
                    NationWideDbContext dbContext = new NationWideDbContext();
                    dbContext.UpdateParentForm(model);
                }
                catch (Exception ex)
                {
                    Log4NetLogger.ExceptionTrace(ex, "[HomeController] Parents() database save");
                    message = "An error occured while saving the record";
                }
            });

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
        public ActionResult DeleteCandidateData(NannyJobEmployment model, HttpPostedFileBase image, HttpPostedFileBase resume)
        {
            string message = "Record was deleted successfully";


            Task.Run(() =>
            {
                try
                {
                    // save form in database
                    NationWideDbContext dbContext = new NationWideDbContext();
                    dbContext.DeleteJobForm(model);
                }
                catch (Exception ex)
                {
                    Log4NetLogger.ExceptionTrace(ex, "[HomeController] DeleteCandidateData() database save");
                    message = "An error occured while saving the record";
                }
            });

            ViewBag.InfoMessage = message;

            return View("InfoMessage");
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


            Task.Run(() =>
            {
                try
                {
                    // save form in database
                    NationWideDbContext dbContext = new NationWideDbContext();
                    dbContext.UpdateJobForm(model);
                }
                catch (Exception ex)
                {
                    Log4NetLogger.ExceptionTrace(ex, "[HomeController] Parents() database save");
                    message = "An error occured while saving the record";
                }
            });

            ViewBag.InfoMessage = message;

            return View("InfoMessage");
        }

        public ActionResult Jobs(int? candidateId)
        {
            NannyJobEmployment model = null;
            if (candidateId.HasValue)
            {
                NationWideDbContext dbContext = new NationWideDbContext();
                var searchCriteria = new NannyJobEmployment()
                {
                    Id = candidateId.Value,
                    HaveCriminalConvictions = string.Empty,
                    HaveMedicalConditions = string.Empty,
                    IsOfstedRegistered = string.Empty
                };

                var results = dbContext.CandidateSearch(searchCriteria);
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
            var vInfo = ValidateCandidatesForm(model, image, resume);

            if (!vInfo.IsValid)
            {
                ViewBag.ValidationMessage = vInfo.Message;
                return View(model);
            }

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

            Task.Run(() =>
            {
                try
                {
                    // save form in database
                    NationWideDbContext dbContext = new NationWideDbContext();
                    dbContext.SaveJobForm(model);
                }
                catch (Exception ex)
                {
                    Log4NetLogger.ExceptionTrace(ex, "[HomeController] Jobs() database save");
                }
            });

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
            string emailText = message.Replace("[para]", "<br /><br />").Replace("[newline]", "<br />").Replace("[CandidateName]", candidateData.FullName);
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


        #region Validation

        public class FormValidationInfo
        {
            public bool IsValid { get; set; }
            public string Message { get; set; }
        }
        public FormValidationInfo ValidateCandidatesForm(NannyJobEmployment model, HttpPostedFileBase image, HttpPostedFileBase resume)
        {
            bool result = true;
            string message = string.Empty;

            if (string.IsNullOrWhiteSpace(model.FullName))
            {
                result = false;
                message += "<li> Name  </li>";
            }
            if (model.DOB == null)
            {
                result = false;
                message += "<li> Date of Birth </li>";
            }
            if (string.IsNullOrWhiteSpace(model.Address))
            {
                result = false;
                message += "<li>  Address  </li>";
            }

            if (string.IsNullOrWhiteSpace(model.City))
            {
                result = false;
                message += "<li>  City  </li>";
            }

            if (string.IsNullOrWhiteSpace(model.PostalCode))
            {
                result = false;
                message += "<li>  Postal Code  </li>";
            }

            if (string.IsNullOrWhiteSpace(model.Phone))
            {
                result = false;
                message += "<li>  Preferred contact number  </li>";
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                result = false;
                message += "<li>  Email  </li>";
            }

            if (string.IsNullOrWhiteSpace(model.IsSmoker))
            {
                result = false;
                message += "<li>  Are you a smoker?  </li>";
            }

            if (model.HaveDBS.Equals("Yes", StringComparison.InvariantCultureIgnoreCase) && model.DBSDate == null)
            {
                result = false;
                message += "<li>  Date of last DBS obtained?  </li>";
            }

            if (model.StartDate == null)
            {
                result = false;
                message += "<li>  Prefered Start Date  </li>";
            }

            if (string.IsNullOrWhiteSpace(model.Nationality))
            {
                result = false;
                message += "<li>  Nationality  </li>";
            }

            if (string.IsNullOrWhiteSpace(model.StayInUKDuration))
            {
                result = false;
                message += "<li>  How long have you been in the UK?  </li>";
            }

            if (model.DaysSickLastYear == null)
            {
                result = false;
                message += "<li>  Days off sick in the last 12 months  </li>";
            }

            if (model.ExpectedSalary == null)
            {
                result = false;
                message += "<li>  Salary/week (net) </li>";
            }

            if (string.IsNullOrWhiteSpace(model.Comments))
            {
                result = false;
                message += "<li>  Cover letter  </li>";
            }

            if (!model.AcceptTermConditions)
            {
                result = false;
                message += "<li>  Accept terms and conditions  </li>";
            }

            if (!string.IsNullOrWhiteSpace(message))
            {
                message = "Please provide following <ul>" + message + "</ul>";
            }

            if (image == null)
            {
                result = false;
                message += "<li> Photo  </li>";
            }


            if (resume == null)
            {
                result = false;
                message += "<li> Resume  </li>";
            }

            FormValidationInfo vInfo = new FormValidationInfo() { IsValid = result, Message = message };

            return vInfo;
        }

        public FormValidationInfo ValidateClientsForm(ParentRequest model)
        {
            bool result = true;
           string message = string.Empty;

            if (string.IsNullOrWhiteSpace(model.FullName))
            {
                result = false;
                message += "<li> Name  </li>";
            }
            if (string.IsNullOrWhiteSpace(model.Address))
            {
                result = false;
                message += "<li>  Address  </li>";
            }

            if (string.IsNullOrWhiteSpace(model.City))
            {
                result = false;
                message += "<li>  City  </li>";
            }

            if (string.IsNullOrWhiteSpace(model.PostalCode))
            {
                result = false;
                message += "<li>  Postal Code  </li>";
            }

            if (string.IsNullOrWhiteSpace(model.Phone))
            {
                result = false;
                message += "<li>  Preferred contact number  </li>";
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                result = false;
                message += "<li>  Email  </li>";
            }

            if (model.StartDate == null)
            {
                result = false;
                message += "<li>  Prefered Start Date  </li>";
            }


            if (string.IsNullOrWhiteSpace(model.DaysOfWeekRequied))
            {
                result = false;
                message += "<li>  Days of the week required   </li>";
            }

            if (string.IsNullOrWhiteSpace(model.ChildrenDetails))
            {
                result = false;
                message += "<li>  Number of children caring for   </li>";
            }

            if (string.IsNullOrWhiteSpace(model.ParentNantinalities))
            {
                result = false;
                message += "<li> Nationalities of Father and Mother </li>";
            }

            if (string.IsNullOrWhiteSpace(model.ParentOccupations))
            {
                result = false;
                message += "<li> Occupations of Father and Mother   </li>";
            }

            if (string.IsNullOrWhiteSpace(model.ParentReligions))
            {
                result = false;
                message += "<li> Religion of Father and Mother </li>";
            }

            if (string.IsNullOrWhiteSpace(model.ParentLanguages))
            {
                result = false;
                message += "<li> What language(s) does your family speak? </li>";
            }

            if (string.IsNullOrWhiteSpace(model.MaritialStatus))
            {
                result = false;
                message += "<li> Maritial status </li>";
            }

            if (string.IsNullOrWhiteSpace(model.HavePets))
            {
                result = false;
                message += "<li> Do you have any pets </li>";
            }

            if (string.IsNullOrWhiteSpace(model.IsNannyRequiredToTravel))
            {
                result = false;
                message += "<li> Is Nanny required to accompany the family on trips abroad or within the UK?</li>";
            }

            if (string.IsNullOrWhiteSpace(model.IsCarProvided))
            {
                result = false;
                message += "<li> Is a car provided? </li>";
            }

            if (string.IsNullOrWhiteSpace(model.NannyDriveLicensePreference))
            {
                result = false;
                message += "<li> Should the nanny have a driving licence? </li>";
            }

            if ("Live in".Equals(model.LiveInOut, StringComparison.InvariantCultureIgnoreCase) && string.IsNullOrWhiteSpace(model.IsLiveInEveningBabbySitting))
            {
                result = false;
                message += "<li> If live in, will you require babysitting in the evening </li>";
            }

            if (string.IsNullOrWhiteSpace(model.IsNannySoleCarer))
            {
                result = false;
                message += "<li> Will the nanny be the sole carer when parents are at work? </li>";
            }

            if (string.IsNullOrWhiteSpace(model.NannyDriveLicensePreference))
            {
                result = false;
                message += "<li> Should the nanny have a driving licence?  </li>";
            }

            if (model.SalaryPerWeek == null)
            {
                result = false;
                message += "<li>  Salary/week (net) </li>";
            }

            if (!model.AcceptTermConditions)
            {
                result = false;
                message += "<li>  Accept terms and conditions  </li>";
            }



            if (!string.IsNullOrWhiteSpace(message))
            {
                message = "Please provide following <ul>" + message + "</ul>";
            }


            FormValidationInfo vInfo = new FormValidationInfo() { IsValid = result, Message = message };

            return vInfo;
        }
        #endregion
    }
}