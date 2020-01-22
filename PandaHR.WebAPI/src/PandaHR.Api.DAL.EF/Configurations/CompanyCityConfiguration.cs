using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class CompanyCityConfiguration : IEntityTypeConfiguration<CompanyCity>
    {
        public void Configure(EntityTypeBuilder<CompanyCity> builder)
        {
            builder.HasKey(cc => new { cc.CompanyId, cc.CityId });

            builder.HasOne(cc => cc.City)
                .WithMany(c => c.CompanyCities)
                .HasForeignKey(cc => cc.CityId);

            builder.HasOne(cc => cc.Company)
                .WithMany(c => c.CompanyCities)
                .HasForeignKey(cc => cc.CompanyId);
        }
    }
}
