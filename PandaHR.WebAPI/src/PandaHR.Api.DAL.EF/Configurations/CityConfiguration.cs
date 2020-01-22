using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        private readonly ApplicationDbContext _context;
        public CityConfiguration(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasOne(ci => ci.Country)
                .WithMany(co => co.Cities)
                .HasForeignKey(ci => ci.CountryId);

            string countryName = "Ukraine";
            var countryId = _context.Countries.Where(c => c.Name == countryName).FirstOrDefault().Id;

            builder.HasData(
                new City { Name = "Dnipro", CountryId = countryId},
                new City { Name = "Vinnytsia", CountryId = countryId},
                new City { Name = "Kyiv", CountryId = countryId},
                new City { Name = "Zaporizhya", CountryId = countryId},
                new City { Name = "Kharkiv", CountryId = countryId}
            );
        }
    }
}
