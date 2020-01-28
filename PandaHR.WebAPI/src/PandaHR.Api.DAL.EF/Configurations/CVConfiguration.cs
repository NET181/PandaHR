using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class CVConfiguration : IEntityTypeConfiguration<CV>
    {
        public void Configure(EntityTypeBuilder<CV> builder)
        {
            builder.HasMany(je => je.JobExperiences)
                   .WithOne(c => c.CV)
                   .HasForeignKey(c => c.CVId);

            builder.HasMany(sk => sk.SkillKnowledges)
                   .WithOne(cv => cv.CV)
                   .HasForeignKey(cv => cv.CVId);

            builder.HasOne(q => q.Qualification)
                   .WithMany(cv => cv.CVs)
                   .HasForeignKey(q => q.QualificationId);

            builder.HasOne(u => u.User)
                   .WithMany(cv => cv.CVs)
                   .HasForeignKey(u => u.UserId);
        }
    }
}
