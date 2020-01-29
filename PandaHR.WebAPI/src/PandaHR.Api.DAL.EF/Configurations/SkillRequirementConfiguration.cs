using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class SkillRequirementConfiguration : IEntityTypeConfiguration<SkillRequirement>
    {
        public void Configure(EntityTypeBuilder<SkillRequirement> builder)
        {
            builder.HasKey(sr => new { sr.SkillId, sr.VacancyId });

            builder.HasOne(k => k.KnowledgeLevel)
                   .WithMany(r => r.SkillRequirements)
                   .HasForeignKey(k => k.KnowledgeLevelId);

            builder.HasOne(s => s.Skill)
                   .WithMany(r => r.SkillRequirements)
                   .HasForeignKey(s => s.SkillId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Experience)
                   .WithMany(sk => sk.SkillRequirements)
                   .HasForeignKey(e => e.ExperienceId);

            builder.HasOne(v => v.Vacancy)
                   .WithMany(r => r.SkillRequirements)
                   .HasForeignKey(v => v.VacancyId);
        }
    }
}
