using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
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
        }

        private void AddCompanies()
        {
            var companies = new Company[]
            {
                new Company{ Name = "SoftServe", Description = "Very good company"},
                new Company{ Name = "Apriorit", Description = "Not bad company"},
                new Company{ Name = "SiteCore", Description = "Big company"},
                new Company{ Name = "NeoLit", Description = "Company from Dnipro"},
                new Company{ Name = "Uniqa", Description = "Unussual company"}
            };

            _context.Companies.AddRange(companies);
            _context.SaveChanges();
        }

        private void AddCompanyCities()
        {
            var companies = _context.Companies.ToArray();
            var cities = _context.Cities.ToArray();

            var companyCities = new CompanyCity[]
            {
                new CompanyCity{CompanyId = companies[0].Id, CityId = cities[0].Id},
                new CompanyCity{CompanyId = companies[1].Id, CityId = cities[1].Id},
                new CompanyCity{CompanyId = companies[2].Id, CityId = cities[2].Id},
                new CompanyCity{CompanyId = companies[3].Id, CityId = cities[3].Id},
                new CompanyCity{CompanyId = companies[4].Id, CityId = cities[4].Id},
            };

            _context.CompanyCities.AddRange(companyCities);
            _context.SaveChanges();
        }

        private void AddSkills()
        {
            var skillType = _context.SkillTypes.ToArray();

            var parentSkill = new Skill
            {
                Name = "C#",
                IsDeleted = false,
                RootSkillId = null,
                SkillTypeId = skillType[0].Id
            };

            _context.Skills.Add(parentSkill);

            var skills = new Skill[]
            {
                new Skill {Name = "Asp.Net Core", IsDeleted = false, RootSkillId = parentSkill.Id,
                    SkillTypeId = skillType[0].Id},
                new Skill {Name = "Windows Forms", IsDeleted = false, RootSkillId = parentSkill.Id,
                    SkillTypeId = skillType[0].Id},
                new Skill {Name = "WPF", IsDeleted = false, RootSkillId = parentSkill.Id,
                    SkillTypeId = skillType[0].Id},
                new Skill {Name = "Web Forms", IsDeleted = false, RootSkillId = parentSkill.Id,
                    SkillTypeId = skillType[0].Id}
            };

            _context.Skills.AddRange(skills);
            _context.SaveChanges();
        }

        private void AddSkillRequirements()
        {
            var skills = _context.Skills.ToArray();
            var knowledgeLevels = _context.KnowledgeLevels.ToArray();
            var vacancies = _context.Vacancies.ToArray();

            var skillRequirements = new SkillRequirement[]
            {
                new SkillRequirement{Weight = 25, ExperienceMonths = 12, IsDeleted = false,
                SkillId = skills[0].Id, KnowledgeLevelId = knowledgeLevels[0].Id, VacancyId = vacancies[0].Id},

                new SkillRequirement{Weight = 59, ExperienceMonths = 18, IsDeleted = false,
                SkillId = skills[0].Id, KnowledgeLevelId = knowledgeLevels[1].Id, VacancyId = vacancies[1].Id},

                new SkillRequirement{Weight = 80, ExperienceMonths = 24, IsDeleted = false,
                SkillId = skills[1].Id, KnowledgeLevelId = knowledgeLevels[2].Id, VacancyId = vacancies[2].Id},

                new SkillRequirement{Weight = 70, ExperienceMonths = 15, IsDeleted = false,
                SkillId = skills[2].Id, KnowledgeLevelId = knowledgeLevels[2].Id, VacancyId = vacancies[3].Id}
            };

            _context.SkillRequirements.AddRange(skillRequirements);
            _context.SaveChanges();
        }

        private void AddEducations()
        {
            var users = _context.Users.ToArray();
            var specialities = _context.Specialities.ToArray();
            var degrees = _context.Degrees.ToArray();

            var educations = new Education[]
            {
                new Education{ PlaceName = "DNU", UserId = users[0].Id, SpecialityId = specialities[0].Id,
                    DegreeId = degrees[0].Id, DateStart = new DateTime(2017,08,1),
                    DateEnd = new DateTime(2021,08,1),IsDeleted = false},

                new Education{ PlaceName = "KNTU", UserId = users[0].Id, SpecialityId = specialities[1].Id,
                    DegreeId = degrees[1].Id, DateStart = new DateTime(2021,08,1),
                    DateEnd = new DateTime(2022,08,1),IsDeleted = false},

                new Education{ PlaceName = "DIIT", UserId = users[1].Id, SpecialityId = specialities[2].Id,
                    DegreeId = degrees[2].Id, DateStart = new DateTime(2019,10,1),
                    DateEnd = new DateTime(2023,08,1),IsDeleted = false},

                new Education{ PlaceName = "KPI", UserId = users[2].Id, SpecialityId = specialities[0].Id,
                    DegreeId = degrees[1].Id, DateStart = new DateTime(2016,10,1),
                    DateEnd = new DateTime(2021,08,1),IsDeleted = false},

                new Education{ PlaceName = "HAI", UserId = users[2].Id, SpecialityId = specialities[1].Id,
                    DegreeId = degrees[1].Id, DateStart = new DateTime(2017,10,1),
                    DateEnd = new DateTime(2022,08,1),IsDeleted = false}
            };

            _context.Educations.AddRange(educations);
            _context.SaveChanges();
        }


    }
}
