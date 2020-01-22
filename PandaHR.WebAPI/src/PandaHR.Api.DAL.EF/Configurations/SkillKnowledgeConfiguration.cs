using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class SkillKnowledgeConfiguration : IEntityTypeConfiguration<SkillKnowledge>
    {
        public void Configure(EntityTypeBuilder<SkillKnowledge> builder)
        {
            builder.HasOne(s => s.Skill)
                   .WithMany(k => k.SkillKnowledges)
                   .HasForeignKey(s => s.KnowledgeLevelId);

            builder.HasOne(k => k.KnowledgeLevel)
                   .WithMany(sk => sk.SkillKnowledges)
                   .HasForeignKey(k => k.KnowledgeLevelId);

            builder.HasOne(cv => cv.CV)
                   .WithMany(k => k.SkillKnowledges)
                   .HasForeignKey(cv => cv.CVId);
        }
    }
}
