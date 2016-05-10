using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NationwideNannies.Models
{
   public class ParentRequest
    {
       public ParentRequest()
       {        
       }

        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneAlt { get; set; }
        public string TypeOfChildCare { get; set; }
        public string JobDurationType { get; set; } // short term or long term
        public string DaysOfWeekRequied { get; set; }
        public string ChildrenDetails { get; set; }
        public string ChildSchoolType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string OfstedRequirement { get; set; }
        public string HowDidYouHearAboutUs { get; set; }
        public string HaveUsedOurServices { get; set; }
        public string UsedOurServicesDetails { get; set; }
        public string EmploymentType { get; set; }
        public string LiveInOut { get; set; }
        public int? SalaryPerWeek { get; set; }
        public bool ReceiveMarketingEmails { get; set; }
        public bool AcceptTermConditions { get; set; }
        public string QualifiedNannies { get; set; }        
        public string PreferedTimeForCall { get; set; }
        public string Comments { get; set; }

        public string GetEmailText()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("Full Name: {0} <br/>", this.FullName);
            builder.AppendFormat("Address: {0} <br/>", this.Address);
            builder.AppendFormat("City: {0} <br/>", this.City);
            builder.AppendFormat("Post code: {0} <br/>", this.PostalCode);
            builder.AppendFormat("Preferred contact number: {0} <br/>", this.Phone);
            builder.AppendFormat("Alternate contact number: {0} <br/>", this.PhoneAlt);
            builder.AppendFormat("Preferred Time for a Call: {0} <br/>", this.PreferedTimeForCall);
            builder.AppendFormat("Email: {0} <br/>", this.Email);
            builder.AppendFormat("Type of childcare you are looking for: {0} <br/>", this.TypeOfChildCare);
            builder.AppendFormat("Length of service: {0} <br/>", this.JobDurationType);
            builder.AppendFormat("Employment Type: {0} <br/>", this.EmploymentType);
            builder.AppendFormat("Live in Status: {0} <br/>", this.LiveInOut);
            builder.AppendFormat("Days of the week required: {0} <br/>", this.DaysOfWeekRequied);
            builder.AppendFormat("Number of children caring for (including names, date of birth & gender): {0} <br/>", this.ChildrenDetails);
                  builder.AppendFormat("Do they attend?: {0} <br/>", this.ChildSchoolType);
            builder.AppendFormat("Prefered Start Date: {0} <br/>", this.StartDate);
            builder.AppendFormat("Preferred end of service date (for a temporary position): {0} <br/>", this.EndDate);
            builder.AppendFormat("Childcare qualified nannies only: {0} <br/>", this.QualifiedNannies);
            builder.AppendFormat("Do you require an Ofsted registered nanny?: {0} <br/>", this.OfstedRequirement);
            builder.AppendFormat("Salary/week (net): {0} <br/>", this.SalaryPerWeek);
            builder.AppendFormat("Additional information about your family or staff requirements : {0} <br/>", this.Comments);
            builder.AppendFormat("Where did you hear about Nationwide Nannies: {0} <br/>", this.HowDidYouHearAboutUs);
            builder.AppendFormat("Have you used any of our services before: {0} <br/>", this.HaveUsedOurServices);
            builder.AppendFormat("Please specify how and when you used our services: {0} <br/>", this.UsedOurServicesDetails);
            builder.AppendFormat("Receive Marketing Emails: {0} <br/>", this.ReceiveMarketingEmails);
            builder.AppendFormat("Accept Term and Comditions: {0} <br/>", this.AcceptTermConditions);            
            
            return builder.ToString();
        }
    }
}
