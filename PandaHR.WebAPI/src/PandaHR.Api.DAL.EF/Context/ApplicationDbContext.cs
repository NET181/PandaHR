using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL.EF.Configurations;
using PandaHR.Api.DAL.Models;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.EF.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            //Database.EnsureCreated();
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
        public DbSet<SkillRequirement> SkillRequirements { get; set; }
        public DbSet<SkillType> SkillTypes { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(type.ClrType))
                {
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
                 
                    //modelBuilder.Entity<>(.
                }
            }

            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration<City>(new CityConfiguration())
                .ApplyConfiguration<CompanyCity>(new CompanyCityConfiguration())
                .ApplyConfiguration<Company>(new CompanyConfiguration())
                .ApplyConfiguration<CV>(new CVConfiguration())
                .ApplyConfiguration<Degree>(new DegreeConfiguration())
                .ApplyConfiguration<Education>(new EducationConfiguration())
                .ApplyConfiguration<JobExperience>(new JobExperienceConfiguration())
                .ApplyConfiguration<KnowledgeLevel>(new KnowledgeLevelConfiguration())
                .ApplyConfiguration<Qualification>(new QualificationConfiguration())
                .ApplyConfiguration<Skill>(new SkillConfiguration())
                .ApplyConfiguration<SkillKnowledge>(new SkillKnowledgeConfiguration())
                .ApplyConfiguration<SkillRequirement>(new SkillRequirementConfiguration())
                .ApplyConfiguration<SkillType>(new SkillTypeConfiguration())
                .ApplyConfiguration<Speciality>(new SpecialityConfiguration())
                .ApplyConfiguration<UserCompany>(new UserCompanyConfiguration())
                .ApplyConfiguration<User>(new UserConfiguration())
                .ApplyConfiguration<Vacancy>(new VacancyConfiguration());
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

            foreach (var item in markedAsDeleted)
            {
                if (item.Entity is ISoftDeletable entity)
                {
                    // Set the entity to unchanged (if we mark the whole entity as Modified, every field gets sent to Db as an update)
                    item.State = EntityState.Unchanged;
                    // Only update the IsDeleted flag - only this will get sent to the Db
                    entity.IsDeleted = true;
                }
            }
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

            foreach (var item in markedAsDeleted)
            {
                if (item.Entity is ISoftDeletable entity)
                {
                    // Set the entity to unchanged (if we mark the whole entity as Modified, every field gets sent to Db as an update)
                    item.State = EntityState.Unchanged;
                    // Only update the IsDeleted flag - only this will get sent to the Db
                    entity.IsDeleted = true;
                }
            }

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
