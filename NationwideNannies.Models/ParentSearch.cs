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
        public int Mode { get; set; }
        

        public ParentSearch()
        {
            this.SearchCriteria = new ParentRequest();
            this.SearchResults = new List<ParentRequest>();
        }      
    }
}
