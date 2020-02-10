using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class VacancyCVStatusConfiguration : IEntityTypeConfiguration<VacancyCVStatus>
    {
        public void Configure(EntityTypeBuilder<VacancyCVStatus> builder)
        {
            builder.HasKey(cc => new { cc.ProfileId, cc.VacancyId});

            builder.HasOne(cc => cc.Profile)
                    .WithMany(c => c.Vacancies)
                    .HasForeignKey(cc => cc.ProfileId);

            builder.HasOne(cc => cc.Vacancy)
                    .WithMany(c => c.Profiles)
                    .HasForeignKey(cc => cc.VacancyId);

            builder.HasOne(u => u.File)
                    .WithOne(v => v.VacancyCVStatus)
                    .HasForeignKey<FileVacancyCVProfile>(f => f.VacancyCVStatusId);
        }
    }
}
