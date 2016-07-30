using NationwideNannies.Data;
using NationwideNannies.Logging;
using NationwideNannies.Models;
using NationwideNannies.Services;
using NationwideNannies.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NationwideNannies.Controllers
{
    public class BlogController : Controller
    {
        BlogService service = null;
        public BlogController()
        {
            this.service = new BlogService();
        }

        public ActionResult Index()
        {          
            List<BlogPost> posts = this.service.GetBlogPosts(false);
            return View(posts);
        }

        [Route("blog/post/{slug?}")]
        public ActionResult Post(string slug)
        {
            var post = this.service.GetPostDetails(slug);
            return View(post);
        }
    }
}
