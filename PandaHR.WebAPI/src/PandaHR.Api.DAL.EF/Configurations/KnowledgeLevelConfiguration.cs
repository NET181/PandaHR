using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class KnowledgeLevelConfiguration : IEntityTypeConfiguration<KnowledgeLevel>
    {
        public void Configure(EntityTypeBuilder<KnowledgeLevel> builder)
        {
            builder.HasMany(k => k.SkillKnowledges)
                   .WithOne(l => l.KnowledgeLevel)
                   .HasForeignKey(l => l.KnowledgeLevelId);

            builder.HasMany(r => r.SkillRequirements)
                   .WithOne(k => k.KnowledgeLevel)
                   .HasForeignKey(k => k.KnowledgeLevelId);

            builder.HasMany(st => st.SkillKnowledgeTypes)
                   .WithOne(kl => kl.KnowledgeLevel)
                   .HasForeignKey(kl => kl.KnowledgeLevelId);
        }
    }
}
