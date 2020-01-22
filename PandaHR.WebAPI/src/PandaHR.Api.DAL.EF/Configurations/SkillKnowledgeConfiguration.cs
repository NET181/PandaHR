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
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.KnowledgeLevel)
                .WithOne();

            builder.HasOne(s => s.Skill)
                .WithOne();
        }
    }
}
