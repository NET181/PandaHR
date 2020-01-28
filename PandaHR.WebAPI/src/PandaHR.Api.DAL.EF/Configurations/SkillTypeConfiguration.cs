using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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

            //builder.HasData(
            //    new SkillType { Name = "BackEnd", IsDeleted = false,
            //        Id = new Guid("099e2205-f5bb-4a48-a69c-c2d2a50eb1c9")
            //    },
            //    new SkillType { Name = "FrontEnd", IsDeleted = false,
            //        Id = new Guid("199e2205-f5bb-4a48-a69c-c2d2a50eb1c9")
            //    },
            //    new SkillType { Name = "FullStack", IsDeleted = false,
            //        Id = new Guid("299e2205-f5bb-4a48-a69c-c2d2a50eb1c9")
            //    },
            //    new SkillType { Name = "DataBase", IsDeleted = false,
            //        Id = new Guid("399e2205-f5bb-4a48-a69c-c2d2a50eb1c9")
            //    });
        }
    }
}
