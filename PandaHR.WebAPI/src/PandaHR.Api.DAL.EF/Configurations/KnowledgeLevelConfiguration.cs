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

            builder.HasOne(t => t.SkillType)
                   .WithMany(k => k.KnowledgeLevels)
                   .HasForeignKey(t => t.SkillTypeId);

            builder.HasData(
                new Qualification { Name = "Beginer", Value = 1 },
                new Qualification { Name = "Lower Intermidiate", Value = 2 },
                new Qualification { Name = "Intermidiate", Value = 3 },
                new Qualification { Name = "Upper Intermidiate", Value = 4 }
            );
        }
    }
}
