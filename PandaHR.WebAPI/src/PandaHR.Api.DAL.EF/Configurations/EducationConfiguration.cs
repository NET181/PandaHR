using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasOne(e => e.User)
                .WithMany(u => u.Educations)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.Degree)
                .WithMany(d => d.Educations)
                .HasForeignKey(e => e.DegreeId);

            builder.HasOne(e => e.Speciality)
                .WithMany(s => s.Educations)
                .HasForeignKey(e => e.SpecialityId);
        }
    }
}
