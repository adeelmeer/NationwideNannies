using NationwideNannies.Data;
using NationwideNannies.Logging;
using NationwideNannies.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NationwideNannies.Services
{
    public class BlogService
    {
        NationWideDbContext dbContext = null;

        public BlogService()
        {
            this.dbContext = new NationWideDbContext();
        }

        public List<BlogPost> GetBlogPosts(bool isTestimonial)
        {
            List<BlogPost> results = null;

            try
            {
                var param = new SqlParameter("@isTestimonial", isTestimonial);
                results = this.dbContext.Database.SqlQuery<BlogPost>("usp_GetBlogPosts @isTestimonial", param).ToList();
            }
            catch (Exception ex)
            {
                Log4NetLogger.ExceptionTrace(ex, "[BlogService] GetBlogPosts()");
            }
            return results;
        }

        public BlogPost GetPostDetails(string slug)
        {
            BlogPost post = null;

            if(string.IsNullOrWhiteSpace(slug))
            {
                return null;
            }

            bool getPublishedOnly = true;
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                getPublishedOnly = false;
            }

            try
            {
                var results = this.dbContext.Database.SqlQuery<BlogPost>("usp_GetBlogPostDetails @slug, @getPublishedOnly",
                    new SqlParameter("@slug", slug),
                    new SqlParameter("@getPublishedOnly", getPublishedOnly)).ToList();

                if(results != null)
                {
                    post = results.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Log4NetLogger.ExceptionTrace(ex, "[BlogService] GetPostDetails()");
            }

            return post;
        }
    }
}
