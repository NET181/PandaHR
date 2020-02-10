using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class VacancyCVFlowConfiguration : IEntityTypeConfiguration<VacancyCVFlow>
    {
        public void Configure(EntityTypeBuilder<VacancyCVFlow> builder)
        {
            builder.HasKey(cc => new { cc.CVId, cc.VacancyId});

            builder.HasOne(cc => cc.CV)
                    .WithMany(c => c.Vacancies)
                    .HasForeignKey(cc => cc.CVId);

            builder.HasOne(cc => cc.Vacancy)
                    .WithMany(c => c.CVs)
                    .HasForeignKey(cc => cc.VacancyId);

            builder.HasMany(u => u.Files)
                    .WithOne(v => v.VacancyCVFlow)
                    .HasForeignKey(v => v.VacancyCVFlowId);
        }
    }
}
