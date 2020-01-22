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
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.KnowledgeLevel)
                .WithOne();

            builder.HasOne(s => s.Skill)
                .WithOne();

            builder.HasOne(s => s.Vacancy)
                .WithOne();

        }
    }
}
