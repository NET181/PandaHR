using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class SkillKnowledgeTypeConfiguration : IEntityTypeConfiguration<SkillKnowledgeType>
    {
        public void Configure(EntityTypeBuilder<SkillKnowledgeType> builder)
        {
            builder.HasKey(k => new { k.SkillTypeId, k.KnowledgeLevelId });

            builder.HasOne(st => st.SkillType)
                   .WithMany(sk => sk.SkillKnowledgeTypes)
                   .HasForeignKey(st => st.SkillTypeId);

            builder.HasOne(k => k.KnowledgeLevel)
                   .WithMany(st => st.SkillKnowledgeTypes)
                   .HasForeignKey(k => k.KnowledgeLevelId);
        }
    }
}
