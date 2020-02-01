using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;

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

            builder.HasMany(t => t.SkillKnowledgeTypes)
                   .WithOne(k => k.KnowledgeLevel)
                   .HasForeignKey(t => t.KnowledgeLevelId);

            //builder.HasData(
            //    new KnowledgeLevel
            //    {
            //        Name = "Beginer",
            //        Id = new Guid("9b9be3ca-2c11-4afe-9c5f-225bbf192e81")
            //    },
            //    new KnowledgeLevel
            //    {
            //        Name = "Lower Intermidiate",
            //        Id = new Guid("32832ec4-968b-4619-b8cb-af4e65c52a37")
            //    },
            //    new KnowledgeLevel
            //    {
            //        Name = "Intermidiate",
            //        Id = new Guid("9b9be3ca-2c11-4afe-9c5f-225bbf192e31")
            //    },
            //    new KnowledgeLevel
            //    {
            //        Name = "Upper Intermidiate",
            //        Id = new Guid("9b9be3ca-9c11-4afe-9c5f-225bbf192e81")
            //    });
        }
    }
}
