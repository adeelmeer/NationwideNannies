using NationwideNannies.Data;
using NationwideNannies.Logging;
using NationwideNannies.Models;
using NationwideNannies.Utils;
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

        public List<BlogPost> GetBlogPosts()
        {
            List<BlogPost> results = null;
            string cacheKey = "PublishedBlogPosts";

            results =  CacheHelper.GetFromCache<List<BlogPost>>(cacheKey);

            if(results != null && results.Count != 0)
            {
                return results;
            }

            try
            {               
                results = this.dbContext.Database.SqlQuery<BlogPost>("usp_GetPublishedBlogPosts").ToList();
                CacheHelper.AddToCache<List<BlogPost>>(results, cacheKey);
            }
            catch (Exception ex)
            {
                Log4NetLogger.ExceptionTrace(ex, "[BlogService] GetBlogPosts()");
            }
           
            return results;
        }

        public List<BlogPost> GetTestimonails(bool homePageOnly)
        {
            List<BlogPost> results = null;
            string cacheKey = "Testimonails";

            results = CacheHelper.GetFromCache<List<BlogPost>>(cacheKey);

            if (results == null || results.Count == 0)
            {
                try
                {
                    results = this.dbContext.Database.SqlQuery<BlogPost>("usp_GetTestimonials").ToList();
                    CacheHelper.AddToCache(results, cacheKey);
                }
                catch (Exception ex)
                {
                    Log4NetLogger.ExceptionTrace(ex, "[BlogService] GetTestimonails()");
                }
            }

            if (homePageOnly && results != null)
            {
                return results.Where(x => x.IsCommentEnabled).ToList();
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
