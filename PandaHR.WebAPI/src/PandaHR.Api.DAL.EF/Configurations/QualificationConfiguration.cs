using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class QualificationConfiguration : IEntityTypeConfiguration<Qualification>
    {
        public void Configure(EntityTypeBuilder<Qualification> builder)
        {
            builder.HasMany(cv => cv.CVs)
                   .WithOne(q => q.Qualification)
                   .HasForeignKey(q => q.QualificationId);

            builder.HasMany(v => v.Vacancies)
                   .WithOne(q => q.Qualification)
                   .HasForeignKey(q => q.QualificationId);

            builder.HasData(
                new Qualification { Name = "Trainee", Value = 1, IsDeleted = false,
                    Id = new Guid("6015f293-a102-459b-9fa3-2ce7cc92c386")},

                new Qualification { Name = "Junior", Value = 2, IsDeleted = false,
                    Id = new Guid("6331e0ea-9df6-4e20-9bed-b18382b180bd")},

                new Qualification { Name = "Middle", Value = 3, IsDeleted = false,
                    Id = new Guid("e2e061e1-201e-41f8-8fb8-1106b00f5ae7")},

                new Qualification { Name = "Senior", Value = 4, IsDeleted = false,
                    Id = new Guid("a76428b1-aac5-410b-af4f-811c9b474997")});
        }
    }
}
