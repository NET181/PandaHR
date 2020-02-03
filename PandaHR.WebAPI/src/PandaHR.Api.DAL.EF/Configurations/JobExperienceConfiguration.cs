using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class JobExperienceConfiguration : IEntityTypeConfiguration<JobExperience>
    {
        public void Configure(EntityTypeBuilder<JobExperience> builder)
        {
            builder.HasOne(c => c.CV)
                   .WithMany(je => je.JobExperiences)
                   .HasForeignKey(c => c.CVId);
        }
    }
}
