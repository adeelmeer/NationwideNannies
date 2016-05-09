using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationwideNannies.Models
{
    public class ParentSearch
    {
        public ParentRequest SearchCriteria {get;set;}
        public List<ParentRequest> SearchResults { get; set; }

        public ParentSearch()
        {
            this.SearchCriteria = new ParentRequest();
            this.SearchResults = new List<ParentRequest>();
        }

        public class PSearchData
        {
            public string FullName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string PhoneAlt { get; set; }
            public string TypeOfChildCare { get; set; }
            public string JobDurationType { get; set; } // short term or long term
            public string ChildSchoolType { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string OfstedRequirement { get; set; }
            public string LiveInOut { get; set; }
            public int? SalaryPerWeek { get; set; }


        }

    }
}
