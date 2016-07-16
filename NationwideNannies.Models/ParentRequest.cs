using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NationwideNannies.Models
{
    public class ParentRequest
    {
        public ParentRequest()
        {
            ListOfFacilitiesForLiveinNannies = new List<string>();
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

        public string IllnessOrAlergies { get; set; }
        public string SpecialDietaryNeeds { get; set; }
        public string ChildernHobbies { get; set; }
        public string ParentNantinalities { get; set; }
        public string ParentOccupations { get; set; }
        public string ParentReligions { get; set; }
        public string ParentLanguages { get; set; }
        public string MaritialStatus { get; set; }
        public string AdditionalPeopleInHouse { get; set; }
        public string FamilyHobbies { get; set; }
        public string HavePets { get; set; }
        public string PetDetails { get; set; }
        public string IsNannyRequiredToTravel { get; set; }
        public int? TripsPerYear { get; set; }
        public int? LengthOfTrip { get; set; }
        public string OtherDomesticStaff { get; set; }
        public string IsCarProvided { get; set; }
        public string CanNannyUseCar { get; set; }
        public string NannyDriveLicensePreference { get; set; }
        public string NannyAdditionalLanguage { get; set; }
        public string AdditionalLanguageLevel { get; set; }
        public string NannySmokingPreference { get; set; }
        public string MinRelevantCriteria { get; set; }

        [NotMapped]
        public List<string> ListOfFacilitiesForLiveinNannies { get; set; }
        public string LiveInNannyFaclities { get; set; }

        public string IsLiveInEveningBabbySitting { get; set; }
        public int? EveningBabaySittingPerWeek { get; set; }
        public string IsNannySoleCarer { get; set; }
        public string TimesParentsAway { get; set; }
        public string NannyResponsibilities { get; set; }
        public string AdditionalNannyResponsibilities { get; set; }
        public string AdditioanlBenefits { get; set; }
        public string HolidayEntitlement { get; set; }


        public void HandleMultiSelectFromView()
        {
            if (this.ListOfFacilitiesForLiveinNannies == null || this.ListOfFacilitiesForLiveinNannies.Count == 0)
            {
                this.LiveInNannyFaclities = string.Empty;
                return;
            }

            this.LiveInNannyFaclities = string.Join(",", this.ListOfFacilitiesForLiveinNannies);
        }

        public void HandleMultiSelectFromDB()
        {
            if (string.IsNullOrWhiteSpace(this.LiveInNannyFaclities))
            {
                return;
            }

            var spltitParts = this.LiveInNannyFaclities.Split(',');
            if (spltitParts != null)
            {
                this.ListOfFacilitiesForLiveinNannies = spltitParts.ToList();
            }
        }



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

            builder.AppendFormat("Known illnesses and/or allergies {0} <br/>", this.IllnessOrAlergies);
            builder.AppendFormat("Special dietary needs {0} <br/>", this.SpecialDietaryNeeds);
            builder.AppendFormat("Children’s hobbies and interests {0} <br/>", this.ChildernHobbies);
            builder.AppendFormat("Nationalities of Father and Mother {0} <br/>", this.ParentNantinalities);
            builder.AppendFormat("Occupations of Father and Mother {0} <br/>", this.ParentOccupations);
            builder.AppendFormat("Religion of Father and Mother  {0} <br/>", this.ParentReligions);
            builder.AppendFormat("What language(s) does your family speak? {0} <br/>", this.ParentLanguages);
            builder.AppendFormat("Maritial status : {0} <br/>", this.MaritialStatus);
            builder.AppendFormat("How many people live in the household?  {0} <br/>", this.AdditionalPeopleInHouse);
            builder.AppendFormat("What are your family hobbies and interests?    {0} <br/>", this.FamilyHobbies);
            builder.AppendFormat("Do you have any pets?  {0} <br/>", this.HavePets);
            builder.AppendFormat("Pet Details {0} <br/>", this.PetDetails);
            builder.AppendFormat("Do you require your nanny to accompany the family on trips abroad or within the UK? {0} <br/>", this.IsNannyRequiredToTravel);
            builder.AppendFormat("Number of trips per  year: {0} <br/>", this.TripsPerYear);
            builder.AppendFormat("Approximate length of a trip (days):   {0} <br/>", this.LengthOfTrip);
            builder.AppendFormat("Do you employ other domestic staff?  {0} <br/>", this.OtherDomesticStaff);
            builder.AppendFormat("Is a car provided? {0} <br/>", this.IsCarProvided);
            builder.AppendFormat("If yes, will the nanny have use of the car? {0} <br/>", this.CanNannyUseCar);
            builder.AppendFormat("Should the nanny have a driving licence?   {0} <br/>", this.NannyDriveLicensePreference);
            builder.AppendFormat("Should the nanny speak any other language (other than English)?  {0} <br/>", this.NannyAdditionalLanguage);
            builder.AppendFormat("If yes, what level?  {0} <br/>", this.AdditionalLanguageLevel);
            builder.AppendFormat("Should the nanny be a non-smoker?  {0} <br/>", this.NannySmokingPreference);
            builder.AppendFormat("Do you have a minimum relevant experience criteria? {0} <br/>", this.MinRelevantCriteria);
            builder.AppendFormat("If live in, will the nanny have: {0} <br/>", this.LiveInNannyFaclities);
            builder.AppendFormat("If live in, will you require babysitting in the evening:  {0} <br/>", this.IsLiveInEveningBabbySitting);
            builder.AppendFormat("How many evenings per week? {0} <br/>", this.EveningBabaySittingPerWeek);
            builder.AppendFormat("Will the nanny be the sole carer when parents are at work? {0} <br/>", this.IsNannySoleCarer);
            builder.AppendFormat("If yes, please specify the times parents are away for:  {0} <br/>", this.TimesParentsAway);
            builder.AppendFormat("Please specify responsibilities of the nanny?     {0} <br/>", this.NannyResponsibilities);
            builder.AppendFormat("Please specify any additional responsibilities  of a live in nanny?  {0} <br/>", this.AdditionalNannyResponsibilities);
            builder.AppendFormat("Addition benefits (as part of the package)? {0} <br/>", this.AdditioanlBenefits);
            builder.AppendFormat("Holiday entitlement in addition to the statutory holiday? {0} <br/>", this.HolidayEntitlement);

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
