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
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string EmploymentType { get; set; }
        public string LiveInOut { get; set; }
        public int SalaryPerWeek { get; set; }
        public string QualifiedNannies { get; set; }
        public string ChildAgeGroup { get; set; }
        public string PreferedTimeForCall { get; set; }
        public string Comments { get; set; }

        public string GetEmailText()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("First Name: {0} <br/>", this.FirstName);
            builder.AppendFormat("Last Name: {0} <br/>", this.LastName);
            builder.AppendFormat("Email: {0} <br/>", this.Email);
            builder.AppendFormat("Phone: {0} <br/>", this.Phone);
            builder.AppendFormat("City: {0} <br/>", this.City);
            builder.AppendFormat("Employment Type: {0} <br/>", this.EmploymentType);
            builder.AppendFormat("Live in or Live out Nanny: {0} <br/>", this.LiveInOut);
            builder.AppendFormat("SalaryPerWeek: {0} <br/>", this.SalaryPerWeek);
            builder.AppendFormat("Qualified Nannies Only: {0} <br/>", this.QualifiedNannies);
            builder.AppendFormat("Child Age Group: {0} <br/>", this.ChildAgeGroup);
            builder.AppendFormat("Prefered Time For Call: {0} <br/>", this.PreferedTimeForCall);
            builder.AppendFormat("Comments: {0} <br/>", this.Comments);

            return builder.ToString();
        }
    }
}
