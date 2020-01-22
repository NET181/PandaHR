using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.HasMany(s => s.Educations)
                .WithOne(e => e.Speciality)
                .HasForeignKey(e => e.SpecialityId);

            builder.HasData(
                new Speciality { Name = "Software Engineering", IsDeleted = false },
                new Speciality { Name = "System Analysis", IsDeleted = false },
                new Speciality { Name = "Applied Math", IsDeleted = false },
                new Speciality { Name = "Applied Physics", IsDeleted = false },
                new Speciality { Name = "Computer Science", IsDeleted = false });
        }
    }
}
