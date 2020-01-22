using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Educations)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            builder.HasMany(u => u.CVs)
                .WithOne(cv => cv.User)
                .HasForeignKey(cv => cv.UserId);

            builder.HasMany(u => u.Vacancies)
                .WithOne(v => v.User)
                .HasForeignKey(v => v.UserId);

            builder.HasMany(u => u.UserCompanies)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}
