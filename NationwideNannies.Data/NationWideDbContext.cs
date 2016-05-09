using NationwideNannies.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationwideNannies.Data
{
    public class NationWideDbContext : DbContext
    {
        protected const string DbContextParameter = "name=NationwideDbContext";

        public NationWideDbContext()
            : base(DbContextParameter)
        {
          //  this.aut
        }

        public virtual IDbSet<NannyJobEmployment> NannyJobEmployment { get; set; }
        public virtual IDbSet<ParentRequest> ParentRequest { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NannyJobEmployment>().ToTable("NannyJobEmployment");
            modelBuilder.Entity<NannyJobEmployment>().HasKey(t => t.Id);

            modelBuilder.Entity<ParentRequest>().ToTable("ParentRequest");
            modelBuilder.Entity<ParentRequest>().HasKey(t => t.Id);
        }

        public void SaveJobForm(NannyJobEmployment jobData)
        {
            if (jobData != null)
            {
                this.NannyJobEmployment.Add(jobData);
                this.SaveChanges();
            }
        }

        public void SaveParentForm(ParentRequest data)
        {
            if (data != null)
            {
                this.ParentRequest.Add(data);
                this.SaveChanges();
            }
        }

        public List<ParentRequest> ClientSearch(ParentRequest criteria)
        {
            List<ParentRequest> searchResults = null;
            IQueryable<ParentRequest> infoData = null;

            try
            {
                infoData = this.ParentRequest;

                if (!string.IsNullOrWhiteSpace(criteria.FullName))
                {
                    infoData = infoData.Where(i => i.FullName.Contains(criteria.FullName));
                }

                searchResults = infoData.ToList();
            }
            catch (Exception ex)
            {
                Logging.Log4NetLogger.ExceptionTrace(ex, "[NationWideDbContext]ClientSearch()");
                searchResults = new List<ParentRequest>();
            }

            return searchResults;
        }

        public List<NannyJobEmployment> CandidateSearch(NannyJobEmployment criteria)
        {
            List<NannyJobEmployment> searchResults = null;
            IQueryable<NannyJobEmployment> infoData = null;

            try
            {
                infoData = this.NannyJobEmployment;

                if (!string.IsNullOrWhiteSpace(criteria.FullName))
                {
                    infoData = infoData.Where(i => i.FullName.Contains(criteria.FullName));
                }
                if (criteria.Id > 0)
                {
                    infoData = infoData.Where(i=>i.Id == criteria.Id);
                }

                searchResults = infoData.ToList();
            }
            catch (Exception ex)
            {
                Logging.Log4NetLogger.ExceptionTrace(ex, "[NationWideDbContext]ClientSearch()");
                searchResults = new List<NannyJobEmployment>();
            }

            return searchResults;
        }
    }
}
