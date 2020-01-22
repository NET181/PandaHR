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
        }
    }
}
