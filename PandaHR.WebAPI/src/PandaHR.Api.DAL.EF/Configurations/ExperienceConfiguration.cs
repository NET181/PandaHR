using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;


namespace PandaHR.Api.DAL.EF.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.HasMany(e => e.SkillKnowledges)
                  .WithOne(s => s.Experience)
                  .HasForeignKey(s => s.ExperienceId);

            builder.HasMany(e => e.SkillRequirements)
                  .WithOne(s => s.Experience)
                  .HasForeignKey(s => s.ExperienceId);
        }
    }
}
