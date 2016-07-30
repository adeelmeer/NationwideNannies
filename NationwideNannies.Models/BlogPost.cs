using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationwideNannies.Models
{
    public class BlogPost
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostContent { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Slug { get; set; }
    }
}
