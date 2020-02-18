using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using PandaHR.Api.DAL.EF.Configurations;
using PandaHR.Api.DAL.Models;
using PandaHR.Api.DAL.Models.Entities;


namespace PandaHR.Api.DAL.EF.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
        }

        #region DbSets

        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyCity> CompanyCities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<JobExperience> JobExperiences { get; set; }
        public DbSet<KnowledgeLevel> KnowledgeLevels { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillKnowledge> SkillKnowledges { get; set; }
        public DbSet<SkillKnowledgeType> SkillKnowledgeTypes { get; set; }
        public DbSet<SkillRequirement> SkillRequirements { get; set; }
        public DbSet<SkillType> SkillTypes { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<VacancyCity> VacancyCities { get; set; }
        public DbSet<VacancyCVFile> VacancyCVFiles { get; set; }
        public DbSet<VacancyCVFlow> VacancyCVFlows { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<TechnologySkill> TechnologySkills { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(type.ClrType))
                {
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
                }
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Country>(new CountryConfiguration())
                .ApplyConfiguration<City>(new CityConfiguration())
                .ApplyConfiguration<CompanyCity>(new CompanyCityConfiguration())
                .ApplyConfiguration<Company>(new CompanyConfiguration())
                .ApplyConfiguration<CV>(new CVConfiguration())
                .ApplyConfiguration<Degree>(new DegreeConfiguration())
                .ApplyConfiguration<Education>(new EducationConfiguration())
                .ApplyConfiguration<JobExperience>(new JobExperienceConfiguration())
                .ApplyConfiguration<Qualification>(new QualificationConfiguration())
                .ApplyConfiguration<Skill>(new SkillConfiguration())
                .ApplyConfiguration<SkillKnowledge>(new SkillKnowledgeConfiguration())
                .ApplyConfiguration<SkillRequirement>(new SkillRequirementConfiguration())
                .ApplyConfiguration<SkillType>(new SkillTypeConfiguration())
                .ApplyConfiguration<Speciality>(new SpecialityConfiguration())
                .ApplyConfiguration<KnowledgeLevel>(new KnowledgeLevelConfiguration())
                .ApplyConfiguration<SkillKnowledgeType>(new SkillKnowledgeTypeConfiguration())
                .ApplyConfiguration<UserCompany>(new UserCompanyConfiguration())
                .ApplyConfiguration<User>(new UserConfiguration())
                .ApplyConfiguration<Vacancy>(new VacancyConfiguration())
                .ApplyConfiguration<VacancyCity>(new VacancyCityConfiguration())
                .ApplyConfiguration<VacancyCVFile>(new VacancyCVFileConfiguration())
                .ApplyConfiguration<VacancyCVFlow>(new VacancyCVFlowConfiguration())
                .ApplyConfiguration<Experience>(new ExperienceConfiguration())                
                .ApplyConfiguration<Technology>(new TechnologyConfiguration())
                .ApplyConfiguration<TechnologySkill>(new TechnologySkillConfiguration());
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            ChangeTracker.DetectChanges();

            var deletedEntities = ChangeTracker.Entries<ISoftDeletable>().Where(E => E.State == EntityState.Deleted).ToList();
            deletedEntities.ForEach(e =>
            {
                e.State = EntityState.Unchanged;
                e.Entity.IsDeleted = true;
                
            });

            var addedEntities = ChangeTracker.Entries<IBaseEntity>().Where(E => E.State == EntityState.Added).ToList();
            addedEntities.ForEach(e =>
            {
                e.Entity.AddedDate = DateTime.UtcNow;
            });

            var modifiedEntities = ChangeTracker.Entries<IBaseEntity>().Where(E => E.State == EntityState.Modified).ToList();
            modifiedEntities.ForEach(e =>
            {
                e.Entity.ModifiedDate = DateTime.UtcNow;
            });
        }
    }
}
