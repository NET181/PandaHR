using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class SkillKnowledgeConfiguration : IEntityTypeConfiguration<SkillKnowledge>
    {
        public void Configure(EntityTypeBuilder<SkillKnowledge> builder)
        {
            builder.HasKey(sk => new { sk.CVId, sk.SkillId }); 

            builder.HasOne(s => s.Skill)
                   .WithMany(k => k.SkillKnowledges)
                   .HasForeignKey(s => s.SkillId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(k => k.KnowledgeLevel)
                   .WithMany(sk => sk.SkillKnowledges)
                   .HasForeignKey(k => k.KnowledgeLevelId);

            builder.HasOne(cv => cv.CV)
                   .WithMany(k => k.SkillKnowledges)
                   .HasForeignKey(cv => cv.CVId);
        }
    }
}
