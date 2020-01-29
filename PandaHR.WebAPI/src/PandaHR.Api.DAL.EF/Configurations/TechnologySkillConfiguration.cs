using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class TechnologySkillConfiguration : IEntityTypeConfiguration<TechnologySkill>
    {
        public void Configure(EntityTypeBuilder<TechnologySkill> builder)
        {
            builder.HasKey(ts => new { ts.TechnologyId, ts.SkillId });

            builder.HasOne(t => t.Technology)
                .WithMany(t => t.TechnologySkills)
                .HasForeignKey(t => t.TechnologyId);

            builder.HasOne(s => s.Skill)
                .WithMany(s => s.TechnologySkills)
                .HasForeignKey(s => s.SkillId);
        }
    }
}
