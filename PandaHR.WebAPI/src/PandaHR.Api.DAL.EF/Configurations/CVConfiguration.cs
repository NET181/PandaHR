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

            builder.HasOne(q => q.Technology)
                .WithMany(q => q.CVs)
                .HasForeignKey(q => q.TechnologyId);

            builder.HasOne(u => u.User)
                   .WithOne(cv => cv.CV)
                   .HasForeignKey<User>(u => u.Id);

            builder.HasMany(u => u.Vacancies)
                   .WithOne(cv => cv.CV)
                   .HasForeignKey(u => u.CVId);
        }
    }
}
