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

            builder.HasMany(t => t.SkillKnowledgeTypes)
                   .WithOne(k => k.KnowledgeLevel)
                   .HasForeignKey(t => t.KnowledgeLevelId);

            //builder.HasData(
            //    new KnowledgeLevel
            //    {
            //        Name = "Beginer", Value = 1,
            //        Id = new Guid("9b9be3ca-2c11-4afe-9c5f-225bbf192e81"),
            //        SkillTypeId = new Guid("099e2205-f5bb-4a48-a69c-c2d2a50eb1c9")
            //    },
            //    new KnowledgeLevel
            //    { 
            //        Name = "Lower Intermidiate", Value = 2,
            //        Id = new Guid("32832ec4-968b-4619-b8cb-af4e65c52a37"),
            //        SkillTypeId = new Guid("199e2205-f5bb-4a48-a69c-c2d2a50eb1c9")
            //    },
            //    new KnowledgeLevel
            //    { 
            //        Name = "Intermidiate", Value = 3,
            //        Id = new Guid("9b9be3ca-2c11-4afe-9c5f-225bbf192e31"),
            //        SkillTypeId = new Guid("099e2205-f5bb-4a48-a69c-c2d2a50eb1c9")
            //    },
            //    new KnowledgeLevel
            //    { 
            //        Name = "Upper Intermidiate", Value = 4,
            //        Id = new Guid("9b9be3ca-9c11-4afe-9c5f-225bbf192e81"),
            //        SkillTypeId = new Guid("099e2205-f5bb-4a48-a69c-c2d2a50eb1c9")
            //    });
        }
    }
}
