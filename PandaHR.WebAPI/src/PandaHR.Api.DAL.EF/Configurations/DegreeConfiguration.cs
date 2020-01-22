using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class DegreeConfiguration : IEntityTypeConfiguration<Degree>
    {
        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            builder.HasMany(d => d.Educations)
                .WithOne(e => e.Degree)
                .HasForeignKey(e => e.DegreeId);
        }
    }
}
