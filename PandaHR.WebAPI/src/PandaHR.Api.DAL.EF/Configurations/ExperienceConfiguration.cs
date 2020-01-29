using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.HasMany(e => e.SkillKnowledges)
                  .WithOne(s => s.Experience)
                  .HasForeignKey(s => s.ExperienceId);

            builder.HasMany(e => e.SkillRequirements)
                  .WithOne(s => s.Experience)
                  .HasForeignKey(s => s.ExperienceId);

            builder.HasData(
                new Experience
                {
                    Name = "0-6",
                    Value = 1,
                    IsDeleted = false,
                    Id = new Guid("561d468e-a93b-4e6b-a576-52b3d7bbf32a")
                },
                new Experience
                {
                    Name = "6-12",
                    Value = 2,
                    IsDeleted = false,
                    Id = new Guid("0e6ab8cc-66e2-4fa4-95fc-25aa0f2eff90")
                },
                new Experience
                {
                    Name = "1+ year",
                    Value = 3,
                    IsDeleted = false,
                    Id = new Guid("8b4bc763-1e35-4b07-adc9-e9a7f01dad06")
                },
                new Experience
                {
                    Name = "2+ year",
                    Value = 4,
                    IsDeleted = false,
                    Id = new Guid("fbdf0376-ccd8-44f0-85b0-0609d4f25b0e")
                });
        }
    }
}
