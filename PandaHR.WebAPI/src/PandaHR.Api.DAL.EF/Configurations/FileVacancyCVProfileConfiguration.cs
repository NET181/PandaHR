using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class FileVacancyCVProfileConfiguration : IEntityTypeConfiguration<FileVacancyCVProfile>
    {
        public void Configure(EntityTypeBuilder<FileVacancyCVProfile> builder)
        {
            builder.HasOne(p => p.VacancyCVStatus)
                    .WithOne(f => f.File)
                    .HasForeignKey<VacancyCVStatus>(p => p.FileId);
        }
    }
}
