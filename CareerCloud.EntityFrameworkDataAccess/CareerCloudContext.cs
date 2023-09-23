using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            var connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // define keys


            //define relationships
            modelBuilder.Entity<ApplicantEducationPoco>()
            .HasOne(ae => ae.ApplicantProfile)
            .WithMany(ap => ap.ApplicantEducations)
            .HasForeignKey(s => s.Applicant);

            modelBuilder.Entity<ApplicantEducationPoco>()
            .Ignore(ap => ap.TimeStamp);

            modelBuilder.Entity<ApplicantJobApplicationPoco>()
             .HasOne(ae => ae.ApplicantProfile)
             .WithMany(ap => ap.ApplicantJobApplications)
             .HasForeignKey(s => s.Applicant);

            modelBuilder.Entity<ApplicantJobApplicationPoco>()
          .HasOne(ae => ae.CompanyJob)
          .WithOne(ap => ap.ApplicantJobApplication)
          .HasForeignKey<ApplicantJobApplicationPoco>(s => s.Job);

            modelBuilder.Entity<ApplicantJobApplicationPoco>()
            .Ignore(ap => ap.TimeStamp);

            modelBuilder.Entity<ApplicantProfilePoco>()
            .HasOne(sc => sc.SystemCountryCode)
            .WithMany(ap => ap.ApplicantProfiles)
            .HasForeignKey(s => s.Country);

            modelBuilder.Entity<ApplicantProfilePoco>()
            .HasOne(sl => sl.SecurityLogin)
            .WithMany(ap => ap.ApplicantProfiles)
            .HasForeignKey(c => c.Login);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .Ignore(ap => ap.TimeStamp);
             

            modelBuilder.Entity<SecurityLoginPoco>()
            .Ignore(c => c.TimeStamp);

            modelBuilder.Entity<CompanyProfilePoco>()
            .Ignore(ap => ap.TimeStamp);


            modelBuilder.Entity<CompanyDescriptionPoco>()
            .HasOne(cp => cp.CompanyProfile)
            .WithMany(ap => ap.CompanyDescriptions)
            .HasForeignKey(cp => cp.Company);

            modelBuilder.Entity<CompanyDescriptionPoco>()
             .HasOne(cp => cp.SystemLanguageCode)
             .WithOne(ap => ap.CompanyDescription)
             .HasForeignKey<CompanyDescriptionPoco>(cp => cp.LanguageId);

            modelBuilder.Entity<CompanyDescriptionPoco>()
            .Ignore(cd => cd.TimeStamp);

            modelBuilder.Entity<CompanyJobPoco>()
            .HasOne(cp => cp.CompanyProfile)
            .WithMany(ap => ap.CompanyJobs)
            .HasForeignKey(cp => cp.Company);

            modelBuilder.Entity<CompanyJobPoco>()
            .Ignore(cd => cd.TimeStamp);


            modelBuilder.Entity<CompanyJobDescriptionPoco>()
            .HasOne(cj => cj.CompanyJob)
            .WithMany(cjd => cjd.CompanyJobDescriptions)
            .HasForeignKey(cj => cj.Job);

            modelBuilder.Entity<CompanyJobDescriptionPoco>()
            .Ignore(cd => cd.TimeStamp);


            modelBuilder.Entity<CompanyLocationPoco>()
          .HasOne(cf => cf.CompanyProfile)
          .WithMany(cl => cl.CompanyLocations)
          .HasForeignKey(cj => cj.Company);

            modelBuilder.Entity<CompanyLocationPoco>()
            .HasOne(cf => cf.SystemCountryCode)
            .WithMany(cl => cl.CompanyLocations)
            .HasForeignKey(cj => cj.CountryCode);

            modelBuilder.Entity<CompanyLocationPoco>()
            .Ignore(c => c.TimeStamp);


            modelBuilder.Entity<CompanyJobEducationPoco>()
          .HasOne(cf => cf.CompanyJob)
          .WithMany(cl => cl.CompanyJobEducations)
          .HasForeignKey(cj => cj.Job);

            modelBuilder.Entity<CompanyJobEducationPoco>()
            .Ignore(c => c.TimeStamp);


            modelBuilder.Entity<CompanyJobSkillPoco>()
             .HasOne(cf => cf.CompanyJob)
             .WithMany(cl => cl.CompanyJobSkills)
             .HasForeignKey(cj => cj.Job);

            modelBuilder.Entity<CompanyJobSkillPoco>()
            .Ignore(c => c.TimeStamp);

            modelBuilder.Entity<SecurityLoginsLogPoco>()
             .HasOne(cf => cf.SecurityLogin)
             .WithMany(cl => cl.SecurityLoginsLogs)
             .HasForeignKey(cj => cj.Login);


            modelBuilder.Entity<SecurityLoginsRolePoco>()
              .HasOne(sl => sl.SecurityLogin)
              .WithMany(ap => ap.SecurityLoginsRoles)
              .HasForeignKey(c => c.Login);

            modelBuilder.Entity<SecurityLoginsRolePoco>()
            .Ignore(c => c.TimeStamp);

            modelBuilder.Entity<ApplicantSkillPoco>()
        .HasOne(sl => sl.ApplicantProfile)
        .WithMany(ap => ap.ApplicantSkills)
        .HasForeignKey(c => c.Applicant);

         modelBuilder.Entity<ApplicantSkillPoco>()
         .Ignore(c => c.TimeStamp);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
            .HasOne(sl => sl.ApplicantProfile)
            .WithMany(ap => ap.ApplicantWorkHistorys)
            .HasForeignKey(c => c.Applicant);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
            .HasOne(sl => sl.SystemCountryCode)
            .WithMany(ap => ap.ApplicantWorkHistorys)
            .HasForeignKey(c => c.CountryCode);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
            .Ignore(c => c.TimeStamp);


            modelBuilder.Entity<ApplicantResumePoco>()
            .HasOne(sl => sl.ApplicantProfile)
            .WithMany(ap => ap.ApplicantResumes)
            .HasForeignKey(c => c.Applicant);


            modelBuilder.Entity<SecurityLoginsRolePoco>()
            .HasOne(sl => sl.SecurityRole)
            .WithMany(ap => ap.SecurityLoginsRoles)
            .HasForeignKey(c => c.Login);

            modelBuilder.Entity<SecurityLoginsRolePoco>()
            .Ignore(c => c.TimeStamp);

        }
    }
}
