using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasMany(co => co.Cities)
                .WithOne(ci => ci.Country)
                .HasForeignKey(ci => ci.CountryId);

            builder.HasData(
                new Country { Name = "Ukraine", 
                    Id = new Guid("6F9619FF-8B86-D011-B42D-00CF4FC964FF") },
                new Country { Name = "Russia",
                    Id = new Guid("7F9619FF-8B86-D011-B42D-00CF4FC964FF")
                },
                new Country { Name = "Georgia",
                    Id = new Guid("8F9619FF-8B86-D011-B42D-00CF4FC964FF")
                },
                new Country { Name = "Moldova",
                    Id = new Guid("9F9619FF-8B86-D011-B42D-00CF4FC964FF")
                },
                new Country { Name = "Belarus",
                    Id = new Guid("0F9619FF-8B86-D011-B42D-00CF4FC964FF")
                }
            );
        }
    }
}
