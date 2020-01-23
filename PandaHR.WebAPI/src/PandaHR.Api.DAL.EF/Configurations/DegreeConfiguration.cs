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

            builder.HasData(
                new Degree { Name = "Specialist", IsDeleted = false,
                    Id = new Guid("07a37911-a33e-4248-b8e3-02495f3030d4")},

                new Degree { Name = "Barchelor", IsDeleted = false,
                    Id = new Guid("30d96e97-149f-4d6e-a398-2433b1a12cff")},

                new Degree { Name = "Master", IsDeleted = false,
                    Id = new Guid("8ff346e5-b5ae-4afa-bbc6-cb08d5e8cbd3")},

                new Degree { Name = "Postgraduate", IsDeleted = false,
                    Id = new Guid("369c13f0-dbb1-4907-92b7-6d2afb0b5f95")});
        }
    }
}
