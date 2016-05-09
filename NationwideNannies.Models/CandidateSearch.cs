using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationwideNannies.Models
{
   public class CandidateSearchData
    {
        public NannyJobEmployment SearchCriteria {get;set;}
        public List<NannyJobEmployment> SearchResults { get; set; }
        public int Mode { get; set; }


        public CandidateSearchData()
        {
            this.SearchCriteria = new NannyJobEmployment();
            this.SearchResults = new List<NannyJobEmployment>();
        }    
    }
}
