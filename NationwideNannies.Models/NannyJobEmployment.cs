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
        public NannyJobEmployment()
        {
            HaveCriminalConvictions = "No"; 
            HaveMedicalConditions = "No";
            IsOfstedRegistered = "No";           
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
        public string PreferedPosition { get; set; }
        public string JobDurationType { get; set; } // short term or long term
        public string JobType { get; set; } //Live in, live out, junior nanny/mother’s helper, nanny house keeper, day time, evening/weekends, any time
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DBSDate { get; set; }
        public string HaveDBS { get; set; } // new
        public string Nationality { get; set; }
        public string StayInUKDuration { get; set; }
        public string MaritalStatus { get; set; }
        public string HaveChildren { get; set; }
        public string ChildrenDetails { get; set; }
        public string HaveCriminalConvictions { get; set; }
        public string CriminalConvictionDetails { get; set; }
        public string HaveMedicalConditions { get; set; }
        public string MedicalConditionDetails { get; set; }
        public string IsOfstedRegistered { get; set; }
        public DateTime? OfstedDate { get; set; }
        public int? DaysSickLastYear { get; set; }
        public string DaysSickLastYearDetails { get; set; }
        public int? ExpectedSalary { get; set; }
        public string EligibleToWork { get; set; }
        public string IsSmoker { get; set; } // new
        public DateTime? DOB { get; set; } // new
        public int? Radius { get; set; }
        public string EmploymentType { get; set; }
        public string ChildAgeGroup { get; set; }
        public string PreferedTimeForCall { get; set; }
        public string Comments { get; set; }
        public string ImageFilePath { get; set; }
        public string ResumeFilePath { get; set; }
        public bool AcceptTermConditions { get; set; }



        public string HaveChildcareQualification     { get; set; }
        public string ChildcareQualificationDetails { get; set; }
        public string HaveDrivingLicense { get; set; }
        public string AdditionalLanguages { get; set; }


        public string GetEmailText()
        {
            StringBuilder builder = new StringBuilder();

          

            builder.AppendFormat("Full Name: {0} <br/>", this.FullName);
            builder.AppendFormat("Date of birth: {0} <br/>", this.DOB);
            builder.AppendFormat("Address: {0} <br/>", this.Address);
            builder.AppendFormat("City: {0} <br/>", this.City);
            builder.AppendFormat("Post code: {0} <br/>", this.PostalCode);
            builder.AppendFormat("Preferred contact number: {0} <br/>", this.Phone);
            builder.AppendFormat("Alternate contact number: {0} <br/>", this.PhoneAlt);
            builder.AppendFormat("Preferred Time for a Call: {0} <br/>", this.PreferedTimeForCall);
            builder.AppendFormat("Email: {0} <br/>", this.Email);
            builder.AppendFormat("Job Radius (in km): {0} <br/>", this.Radius);
            builder.AppendFormat("Are you a smoker?: {0} <br/>", this.IsSmoker);
            builder.AppendFormat("Right to live &amp; work in UK: {0} <br/>", this.EligibleToWork);
            builder.AppendFormat("Preferred position: {0} <br/>", this.PreferedPosition);
            builder.AppendFormat("Position Type: {0} <br/>", this.JobType);
            builder.AppendFormat("Position seeking: {0} <br/>", this.JobDurationType);
            builder.AppendFormat("Hours seeking: {0} <br/>", this.EmploymentType);
            builder.AppendFormat("Prefered Start Date: {0} <br/>", this.StartDate);
            builder.AppendFormat("Prefered End Date: {0} <br/>", this.EndDate);
            builder.AppendFormat("Do you have an in date DBS?: {0} <br/>", this.HaveDBS);
            builder.AppendFormat("Date of last DBS obtained: {0} <br/>", this.DBSDate);

            builder.AppendFormat("Do you have a childcare qualification? {0} <br/>", this.HaveChildcareQualification);
            builder.AppendFormat("Details of qualification obtained {0} <br/>", this.ChildcareQualificationDetails);
            builder.AppendFormat("Do you have a valid UK driving license  {0} <br/>", this.HaveDrivingLicense);
            builder.AppendFormat("Do you speak any other language (other than English)?   {0} <br/>", this.AdditionalLanguages);

            builder.AppendFormat("Marital Status: {0} <br/>", this.MaritalStatus);
            builder.AppendFormat("Do you have children?: {0} <br/>", this.HaveChildren);
            builder.AppendFormat("Children Age: {0} <br/>", this.ChildrenDetails);
            builder.AppendFormat("Nationality: {0} <br/>", this.Nationality);
            builder.AppendFormat("How long have you been in the UK?: {0} <br/>", this.StayInUKDuration);
            builder.AppendFormat("Do you have any criminal convictions?: {0} <br/>", this.HaveCriminalConvictions);
            builder.AppendFormat("Criminal conviction details: {0} <br/>", this.CriminalConvictionDetails);
            builder.AppendFormat("Do you have any known medical/health conditions?: {0} <br/>", this.HaveMedicalConditions);
            builder.AppendFormat("Medical/health condition details: {0} <br/>", this.MedicalConditionDetails);
            builder.AppendFormat("Are you Ofsted registered?: {0} <br/>", this.IsOfstedRegistered);
            builder.AppendFormat("Please state date when registration was applied for/issued: {0} <br/>", this.OfstedDate);
            builder.AppendFormat("Days off sick in the last 12 months: {0} <br/>", this.DaysSickLastYear);
            builder.AppendFormat("Comments for sick days: {0} <br/>", this.DaysSickLastYearDetails);
            builder.AppendFormat("Expected Salary: {0} <br/>", this.ExpectedSalary);
            builder.AppendFormat("Experience with age groups: {0} <br/>", this.ChildAgeGroup);
            builder.AppendFormat("Cover letter that will support your application (including skills, languages spoken, training obtained etc : {0} <br/>", this.Comments);
            builder.AppendFormat("Accepted Terms and Consitions: {0} <br/>", this.AcceptTermConditions);
           
            return builder.ToString();
        }
    }
}
