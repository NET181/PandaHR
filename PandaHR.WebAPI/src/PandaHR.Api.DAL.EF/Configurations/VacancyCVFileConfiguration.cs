using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class VacancyCVFileConfiguration : IEntityTypeConfiguration<VacancyCVFile>
    {
        public void Configure(EntityTypeBuilder<VacancyCVFile> builder)
        {
            builder.HasOne(p => p.VacancyCVFlow)
                    .WithMany(f => f.Files)
                    .HasForeignKey(p => p.VacancyCVFlowId);
        }
    }
}
