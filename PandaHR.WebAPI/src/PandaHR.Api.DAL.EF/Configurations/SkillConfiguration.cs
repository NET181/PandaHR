using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasOne(s => s.RootSkill)
                   .WithMany(su => su.SubSkills)
                   .HasForeignKey(s => s.RootSkillId);

            builder.HasMany(k => k.SkillKnowledges)
                   .WithOne(s => s.Skill)   
                   .HasForeignKey(s => s.SkillId);

            builder.HasOne(t => t.SkillType)
                   .WithMany(s => s.Skills)
                   .HasForeignKey(t => t.SkillTypeId);

            builder.HasMany(r => r.SkillRequirements)
                   .WithOne(s => s.Skill)
                   .HasForeignKey(s => s.SkillId);
        }
    }
}
