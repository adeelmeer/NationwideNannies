using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NationwideNannies.Models
{
   public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PreferedTimeForCall { get; set; }
        public string Comments { get; set; }

        public string GetEmailText()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("Name: {0} <br/>", this.Name);
            builder.AppendFormat("Email: {0} <br/>", this.Email);
            builder.AppendFormat("Phone: {0} <br/>", this.Phone);            
            builder.AppendFormat("Prefered Time For Call: {0} <br/>", this.PreferedTimeForCall);
            builder.AppendFormat("Comments: {0} <br/>", this.Comments);
            
            return builder.ToString();
        }
    }
}
