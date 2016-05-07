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

        public void SaveParentForm(ParentRequest jobData)
        {
            if (jobData != null)
            {
                this.ParentRequest.Add(jobData);
                this.SaveChanges();
            }
        }

    }
}
