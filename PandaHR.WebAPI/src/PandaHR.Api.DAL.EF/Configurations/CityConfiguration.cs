using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasOne(ci => ci.Country)
                .WithMany(co => co.Cities)
                .HasForeignKey(ci => ci.CountryId);

            builder.HasData(
                new City { 
                    Name = "Dnipro", 
                    CountryId = new Guid("6F9619FF-8B86-D011-B42D-00CF4FC964FF"),
                    Id = new Guid("619619FF-8B86-D011-B42D-00CF4FC964FF")
                },
                new City { 
                    Name = "Vinnytsia",
                    CountryId = new Guid("6F9619FF-8B86-D011-B42D-00CF4FC964FF"),
                    Id = new Guid("629619FF-8B86-D011-B42D-00CF4FC964FF")
                },
                new City { 
                    Name = "Kyiv",
                    CountryId = new Guid("6F9619FF-8B86-D011-B42D-00CF4FC964FF"),
                    Id = new Guid("639619FF-8B86-D011-B42D-00CF4FC964FF")
                }
            );
        }
    }
}
