using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NationwideNannies.Models
{
    public class NannyJobEmployment
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneAlt { get; set; }
        public string PreferedPosition { get; set; }
        public string JobDurationType { get; set; } // short term or long term
        public string JobType { get; set; } //Live in, live out, junior nanny/mother’s helper, nanny house keeper, day time, evening/weekends, any time
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DBSDate { get; set; }
        public string Nationality { get; set; }
        public string MaritalStatus { get; set; }
        public string HaveChildren { get; set; }
        public string ChildrenDetails { get; set; }
        public string HaveCriminalConvictions { get; set; }
        public string CriminalConvictionDetails { get; set; }
        public string HaveMedicalConditions { get; set; }
        public string MedicalConditionDetails { get; set; }
        public string IsOfstedRegistered { get; set; }
        public DateTime OfstedDate { get; set; }
        public int DaysSickLastYear { get; set; }
        public int ExpectedSalary { get; set; }
        public string EligibleToWork { get; set; }
        public string Radius { get; set; }
        public string EmploymentType { get; set; }
        public string ChildAgeGroup { get; set; }
        public string PreferedTimeForCall { get; set; }
        public string Comments { get; set; }
        public string ImageFilePath { get; set; }
        public string ResumeFilePath { get; set; }
        public bool AcceptTermComditions { get; set; }


        public string GetEmailText()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("First Name: {0} <br/>", this.FirstName);
            builder.AppendFormat("Last Name: {0} <br/>", this.LastName);
            builder.AppendFormat("Email: {0} <br/>", this.Email);
            builder.AppendFormat("Phone: {0} <br/>", this.Phone);
            builder.AppendFormat("City: {0} <br/>", this.City);
            builder.AppendFormat("Eligible To Work in UK: {0} <br/>", this.EligibleToWork);
            builder.AppendFormat("Radius : {0} <br/>", this.Radius);
            builder.AppendFormat("Employment Type: {0} <br/>", this.EmploymentType);
            builder.AppendFormat("Child Age Group: {0} <br/>", this.ChildAgeGroup);
            builder.AppendFormat("Prefered Time For Call: {0} <br/>", this.PreferedTimeForCall);
            builder.AppendFormat("Comments: {0} <br/>", this.Comments);

            return builder.ToString();
        }
    }
}
