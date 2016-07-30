using NationwideNannies.Data;
using NationwideNannies.Logging;
using NationwideNannies.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            try
            {
                var param = new SqlParameter("@slug", slug);
                var results = this.dbContext.Database.SqlQuery<BlogPost>("usp_GetBlogPostDetails @slug", param).ToList();

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
