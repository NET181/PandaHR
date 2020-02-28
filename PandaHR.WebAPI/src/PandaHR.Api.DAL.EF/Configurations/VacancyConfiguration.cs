using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.HasMany(sr => sr.SkillRequirements)
                   .WithOne(v => v.Vacancy)
                   .HasForeignKey(v => v.VacancyId);

            builder.HasOne(u => u.User)
                   .WithMany(cv => cv.Vacancies)
                   .HasForeignKey(u => u.UserId);

            builder.HasOne(q => q.Qualification)
                   .WithMany(v => v.Vacancies)
                   .HasForeignKey(q => q.QualificationId);

            builder.HasOne(c => c.Technology)
                .WithMany(c => c.Vacancies)
                .HasForeignKey(c => c.TechnologyId);

            builder.HasOne(co => co.Company)
                   .WithMany(v => v.Vacancies)
                   .HasForeignKey(co => co.CompanyId);

            builder.HasMany(u => u.CVs)
                   .WithOne(cv => cv.Vacancy)
                   .HasForeignKey(u => u.VacancyId);
        }
    }
}
