using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Linq;

namespace PandaHR.Api.DAL.EF
{
    public class EFDataInitializer : IDataInitializer
    {
        private readonly ApplicationDbContext _context;

        public EFDataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            //_context.Database.EnsureDeleted();
            //_context.Database.EnsureCreated();

            //AddCountries();
            //AddCities();
            //AddDegrees();
            //AddSpecialities();
            //AddSkillTypes();
        }

        private void AddCountries()
        {
            _context.Countries.Add(new Country { Name = "Ukraine" });
            _context.SaveChanges();
        }

        private void AddCities()
        {
            Guid countryId = _context.Countries.First().Id;

            var cities = new City[]
            {
                new City { Name = "Dnepr", CountryId = countryId },
                new City { Name = "Lutsk", CountryId = countryId },
                new City { Name = "Zhytomyr", CountryId = countryId },
                new City { Name = "Lviv", CountryId = countryId },
                new City { Name = "Zaporizhzhya", CountryId = countryId },
                new City { Name = "Cherkasy", CountryId = countryId }
            };

            _context.Cities.AddRange(cities);
            _context.SaveChanges();
        }

        private void AddDegrees()
        {
            var degrees = new Degree[]
            {
                new Degree { Name = "Bachelor" },
                new Degree { Name = "Magister" },
                new Degree { Name = "Doctor" }
            };

            _context.Degrees.AddRange(degrees);
            _context.SaveChanges();
        }

        private void AddSpecialities()
        {
            var specialities = new Speciality[]
            {
                new Speciality { Name = "Software engineering" },
                new Speciality { Name = "Applied mathematics" },
                new Speciality { Name = "System analytics" },
                new Speciality { Name = "Computer sciences" },
                new Speciality { Name = "Computer engineering" }
            };

            _context.Specialities.AddRange(specialities);
            _context.SaveChanges();
        }

        private void AddSkillTypes()
        {
            var skillTypes = new SkillType[]
            {
                new SkillType { Name = "Hard" },
                new SkillType { Name = "Soft" },
                new SkillType { Name = "Language" }
            };

            _context.SkillTypes.AddRange(skillTypes);
            _context.SaveChanges();
        }

    }
}
