using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasOne(s => s.RootSkill)
                   .WithMany(su => su.SubSkills)
                   .HasForeignKey(s => s.RootSkillId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(k => k.SkillKnowledges)
                   .WithOne(s => s.Skill)
                   .HasForeignKey(s => s.SkillId);

            builder.HasOne(t => t.SkillType)
                   .WithMany(s => s.Skills)
                   .HasForeignKey(t => t.SkillTypeId);

            builder.HasMany(t => t.TechnologySkills)
                .WithOne(t => t.Skill)
                .HasForeignKey(t => t.SkillId);

            builder.HasMany(r => r.SkillRequirements)
                   .WithOne(s => s.Skill)
                   .HasForeignKey(s => s.SkillId);
        }
    }
}
