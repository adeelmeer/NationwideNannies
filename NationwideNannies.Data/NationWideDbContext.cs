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
                jobData.IsActive = true;
                this.NannyJobEmployment.Add(jobData);
                this.SaveChanges();
            }
        }

        public void UpdateJobForm(NannyJobEmployment data)
        {
            if (data != null)
            {
                data.IsActive = true;                  
                this.Entry(data).State = EntityState.Modified;
                this.SaveChanges();
            }
        }

        public void DeleteJobForm(NannyJobEmployment data)
        {
            if (data != null)
            {
                data.IsActive = false;
                this.Entry(data).State = EntityState.Modified;
                this.SaveChanges();
            }
        }

        public void SaveParentForm(ParentRequest data)
        {
            if (data != null)
            {
                data.IsActive = true;    
                this.ParentRequest.Add(data);
                this.SaveChanges();
            }
        }

        public void UpdateParentForm(ParentRequest data)
        {
            if (data != null)
            {
                data.IsActive = true;       
                this.Entry(data).State = EntityState.Modified;
                this.SaveChanges();
            }
        }

        public void DeleteParentForm(ParentRequest data)
        {
            if (data != null)
            {
                data.IsActive = false;
                this.Entry(data).State = EntityState.Modified;
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

                infoData = infoData.Where(i=>i.IsActive);

                if (!string.IsNullOrWhiteSpace(criteria.FullName))
                {
                    infoData = infoData.Where(i => i.FullName.Contains(criteria.FullName));
                }

                if (criteria.Id > 0)
                {
                    infoData = infoData.Where(i => i.Id == criteria.Id);
                }

                if (!string.IsNullOrWhiteSpace(criteria.City))
                {
                    infoData = infoData.Where(i => i.City.Contains(criteria.City));
                }

                if (!string.IsNullOrWhiteSpace(criteria.PostalCode))
                {
                    infoData = infoData.Where(i => i.PostalCode.Contains(criteria.PostalCode));
                }

                if (!string.IsNullOrWhiteSpace(criteria.Phone))
                {
                    infoData = infoData.Where(i => i.Phone.Contains(criteria.Phone));
                }

                if (!string.IsNullOrWhiteSpace(criteria.PhoneAlt))
                {
                    infoData = infoData.Where(i => i.PhoneAlt.Contains(criteria.PhoneAlt));
                }

                if (!string.IsNullOrWhiteSpace(criteria.Email))
                {
                    infoData = infoData.Where(i => i.Email.Contains(criteria.Email));
                }

                if (!string.IsNullOrWhiteSpace(criteria.TypeOfChildCare))
                {
                    infoData = infoData.Where(i => i.TypeOfChildCare.Equals(criteria.TypeOfChildCare));
                }

                if (!string.IsNullOrWhiteSpace(criteria.JobDurationType) && criteria.JobDurationType != "Any")
                {
                    infoData = infoData.Where(i => i.JobDurationType.Equals(criteria.JobDurationType));
                }

                if (!string.IsNullOrWhiteSpace(criteria.EmploymentType))
                {
                    infoData = infoData.Where(i => i.EmploymentType.Equals(criteria.EmploymentType));
                }

                if (!string.IsNullOrWhiteSpace(criteria.LiveInOut))
                {
                    infoData = infoData.Where(i => i.LiveInOut.Equals(criteria.LiveInOut));
                }

                if (criteria.StartDate.HasValue)
                {
                    infoData = infoData.Where(i=> i.StartDate.Value >= criteria.StartDate.Value);
                }

                if (criteria.EndDate.HasValue)
                {
                    infoData = infoData.Where(i => i.EndDate.Value <= criteria.EndDate.Value);
                }

                if (!string.IsNullOrWhiteSpace(criteria.QualifiedNannies))
                {
                    infoData = infoData.Where(i => i.QualifiedNannies.Equals(criteria.QualifiedNannies));
                }

                if (!string.IsNullOrWhiteSpace(criteria.OfstedRequirement))
                {
                    infoData = infoData.Where(i => i.OfstedRequirement.Equals(criteria.OfstedRequirement));
                }

                if (criteria.SalaryPerWeek.HasValue)
                {
                    infoData = infoData.Where(i => i.SalaryPerWeek.Value <= criteria.SalaryPerWeek.Value);
                }

                if (!string.IsNullOrWhiteSpace(criteria.NannyDriveLicensePreference))
                {
                    infoData = infoData.Where(i => i.NannyDriveLicensePreference.Equals(criteria.NannyDriveLicensePreference));
                }

                if (!string.IsNullOrWhiteSpace(criteria.ParentNantinalities))
                {
                    infoData = infoData.Where(i => i.ParentNantinalities.Contains(criteria.ParentNantinalities));
                }

                if (!string.IsNullOrWhiteSpace(criteria.ParentReligions))
                {
                    infoData = infoData.Where(i => i.ParentReligions.Contains(criteria.ParentReligions));
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

                infoData = infoData.Where(i=>i.IsActive);

                if (!string.IsNullOrWhiteSpace(criteria.FullName))
                {
                    infoData = infoData.Where(i => i.FullName.Contains(criteria.FullName));
                }

                if (criteria.Id > 0)
                {
                    infoData = infoData.Where(i=>i.Id == criteria.Id);
                }

                if (!string.IsNullOrWhiteSpace(criteria.City))
                {
                    infoData = infoData.Where(i => i.City.Contains(criteria.City));
                }

                if (!string.IsNullOrWhiteSpace(criteria.PostalCode))
                {
                    infoData = infoData.Where(i => i.PostalCode.Contains(criteria.PostalCode));
                }

                if (!string.IsNullOrWhiteSpace(criteria.Phone))
                {
                    infoData = infoData.Where(i => i.Phone.Contains(criteria.Phone));
                }

                if (!string.IsNullOrWhiteSpace(criteria.PhoneAlt))
                {
                    infoData = infoData.Where(i => i.PhoneAlt.Contains(criteria.PhoneAlt));
                }

                if (!string.IsNullOrWhiteSpace(criteria.Email))
                {
                    infoData = infoData.Where(i => i.Email.Contains(criteria.Email));
                }

                if (criteria.Radius.HasValue && criteria.Radius.Value >0)
                {
                    infoData = infoData.Where(i=> i.Radius <= criteria.Radius);
                }


                if (!string.IsNullOrWhiteSpace(criteria.PreferedPosition))
                {
                    infoData = infoData.Where(i => i.PreferedPosition.Equals(criteria.PreferedPosition));
                }

                //if (!string.IsNullOrWhiteSpace(criteria.JobType))
                //{
                //    infoData = infoData.Where(i => i.JobType.Equals(criteria.JobType));
                //}

                if (!string.IsNullOrWhiteSpace(criteria.JobDurationType) && criteria.JobDurationType != "Any")
                {
                    infoData = infoData.Where(i => i.JobDurationType.Equals(criteria.JobDurationType));
                }

                if (!string.IsNullOrWhiteSpace(criteria.EmploymentType))
                {
                    infoData = infoData.Where(i => i.EmploymentType.Equals(criteria.EmploymentType));
                }

                if (criteria.StartDate.HasValue)
                {
                    infoData = infoData.Where(i => i.StartDate.Value >= criteria.StartDate.Value);
                }

                if (criteria.EndDate.HasValue)
                {
                    infoData = infoData.Where(i => i.EndDate.Value <= criteria.EndDate.Value);
                }

                if (!string.IsNullOrWhiteSpace(criteria.Nationality))
                {
                    infoData = infoData.Where(i => i.Nationality.Contains(criteria.Nationality));
                }

                if (!string.IsNullOrWhiteSpace(criteria.HaveCriminalConvictions))
                {
                    infoData = infoData.Where(i => i.HaveCriminalConvictions.Equals(criteria.HaveCriminalConvictions));
                }

                if (!string.IsNullOrWhiteSpace(criteria.HaveMedicalConditions))
                {
                    infoData = infoData.Where(i => i.HaveMedicalConditions.Equals(criteria.HaveMedicalConditions));
                }

                if (!string.IsNullOrWhiteSpace(criteria.IsOfstedRegistered))
                {
                    infoData = infoData.Where(i => i.IsOfstedRegistered.Equals(criteria.IsOfstedRegistered));
                }

                if (criteria.ExpectedSalary.HasValue)
                {
                    infoData = infoData.Where(i=> i.ExpectedSalary<=criteria.ExpectedSalary);
                }

                if (!string.IsNullOrWhiteSpace(criteria.ChildAgeGroup))
                {
                    infoData = infoData.Where(i => i.ChildAgeGroup.Equals(criteria.ChildAgeGroup));
                }

                if (!string.IsNullOrWhiteSpace(criteria.HaveChildcareQualification))
                {
                    infoData = infoData.Where(i => i.HaveChildcareQualification.Equals(criteria.HaveChildcareQualification));
                }

                if (!string.IsNullOrWhiteSpace(criteria.HaveDrivingLicense))
                {
                    infoData = infoData.Where(i => i.HaveDrivingLicense.Equals(criteria.HaveDrivingLicense));
                }

                if (!string.IsNullOrWhiteSpace(criteria.AdditionalLanguages))
                {
                    infoData = infoData.Where(i => i.AdditionalLanguages.Contains(criteria.AdditionalLanguages));
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
