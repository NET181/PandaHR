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
                new Speciality { Name = "Software Engineering", IsDeleted = false,
                    Id = new Guid("f98a7083-825c-496a-9112-ecd375a17dcb")},

                new Speciality { Name = "System Analysis", IsDeleted = false, 
                    Id = new Guid("3cceb22e-d32f-4a29-9c49-651b258c088d")},

                new Speciality { Name = "Applied Math", IsDeleted = false,
                    Id = new Guid("0d59cea4-85f5-4107-9d0f-8fecbe6a1933")},

                new Speciality { Name = "Applied Physics", IsDeleted = false,
                    Id = new Guid("2b82ca8b-1047-4830-83d5-e1e716b4407f")},

                new Speciality { Name = "Computer Science", IsDeleted = false,
                    Id = new Guid("3a4d31f3-c8ab-4f09-8fde-684af2890d69")});
        }
    }
}
