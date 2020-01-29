using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasMany(t => t.CVs)
                .WithOne(t => t.Technology)
                .HasForeignKey(t => t.TechnologyId);

            builder.HasMany(t => t.Vacancies)
                .WithOne(t => t.Technology)
                .HasForeignKey(t => t.TechnologyId);

            builder.HasOne(t => t.Parent)
                .WithMany(t => t.SubTechnologies)
                .HasForeignKey(t => t.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Technology()
                {
                    Id = new Guid("f43f4b05-6cb1-4c72-9ebb-1fe5fd1fc62e"),
                    Name = "Back-end"
                },
                new Technology()
                {
                    Id = new Guid("c3c0583c-a662-421a-8013-ba05ded4a279"),
                    Name = "Front-end"
                }
                );
        }
    }
}
