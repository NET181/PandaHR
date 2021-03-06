﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class SkillTypeConfiguration : IEntityTypeConfiguration<SkillType>
    {
        public void Configure(EntityTypeBuilder<SkillType> builder)
        {
            builder.HasMany(s => s.Skills)
                   .WithOne(t => t.SkillType)
                   .HasForeignKey(s => s.SkillTypeId);

            builder.HasMany(k => k.SkillKnowledgeTypes)
                   .WithOne(t => t.SkillType)
                   .HasForeignKey(t => t.SkillTypeId);
        }
    }
}
