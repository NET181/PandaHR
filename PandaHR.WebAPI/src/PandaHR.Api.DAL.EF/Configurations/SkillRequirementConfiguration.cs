using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
                   .HasForeignKey(s => s.SkillId);

            builder.HasOne(v => v.Vacancy)
                   .WithMany(r => r.SkillRequirements)
                   .HasForeignKey(v => v.VacancyId);
        }
    }
}
