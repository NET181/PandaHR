using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //TODO - run methods
            //AddUser();
            //AddVacancy();
            
        }

        private void AddCV()
        {
            var userId = _context.Users.FirstOrDefault().Id;
            var qualificationId = _context.Qualifications.FirstOrDefault().Id;

            var cv = new List<CV>()
            {
                new CV{ Summary = "Im very good", UserId = userId, QualificationId = qualificationId},
                new CV{ Summary = "Im better than good", UserId = userId, QualificationId = qualificationId},
                new CV{ Summary = "Im better than better", UserId = userId, QualificationId = qualificationId},
                new CV{ Summary = "Im the best", UserId = userId, QualificationId = qualificationId},
                new CV{ Summary = "Im so clever boy", UserId = userId, QualificationId = qualificationId},

            };

            _context.CVs.AddRange(cv);
            _context.SaveChanges();
        }

        private void AddVacancy()
        {
            var cityId = _context.Cities.FirstOrDefault().Id;
            var companyId = _context.Companies.FirstOrDefault().Id;
            var userId = _context.Users.FirstOrDefault().Id;
            var qualificationId = _context.Qualifications.FirstOrDefault().Id;

            var vacancies = new Vacancy[]
            {
                new Vacancy{ CityId = cityId, CompanyId = companyId, Description = "Best vacancy ever!",
                    UserId = userId, QualificationId = qualificationId},
                new Vacancy{ CityId = cityId, CompanyId = companyId, Description = "Even better vacancy than the previous!",
                    UserId = userId, QualificationId = qualificationId},
                new Vacancy{ CityId = cityId, CompanyId = companyId, Description = "Vacancy for C# developer",
                    UserId = userId, QualificationId = qualificationId}
            };

            _context.Vacancies.AddRange(vacancies);
            _context.SaveChanges();
        }

        private void AddJobExperience()
        {
            var cvId = _context.CVs.FirstOrDefault().Id;

            var jobExperiences = new JobExperience[]
            {
                new JobExperience { CVId = cvId, CompanyName = "SoftServe", ProjectName = "Sports Store",
                Description = "Fully working shop", StartDate = new DateTime(15,12,23),
                FinishDate = new DateTime(17,5,20) },
                new JobExperience { CVId = cvId, CompanyName = "Oracle", ProjectName = "Windows Xp developing",
                Description = "Developing OS system", StartDate = new DateTime(14,12,23),
                FinishDate = new DateTime(15,5,15) }
            };

            _context.JobExperiences.AddRange(jobExperiences);
            _context.SaveChanges();
        }

        private void AddSkillKnowledge()
        {
            var skillId = _context.Skills.FirstOrDefault().Id;
            var knowledgeLevelId = _context.KnowledgeLevels.ToArray();
            var cvId = _context.CVs.FirstOrDefault().Id;

            var skillKnowledges = new SkillKnowledge[]
            {
                new SkillKnowledge { SkillId = skillId, KnowledgeLevelId = knowledgeLevelId[0].Id, CVId = cvId,
                ExperienceMonths = 15},
                new SkillKnowledge { SkillId = skillId, KnowledgeLevelId = knowledgeLevelId[1].Id, CVId = cvId,
                ExperienceMonths = 0},
                new SkillKnowledge { SkillId = skillId, KnowledgeLevelId = knowledgeLevelId[2].Id, CVId = cvId,
                ExperienceMonths = 3}
            };

            _context.SkillKnowledges.AddRange(skillKnowledges);
            _context.SaveChanges();
        }

        private void AddUser()
        {
            var cityId = _context.Skills.FirstOrDefault().Id;

            var users = new User[]
            {
                new User { FirstName = "Kolya", SecondName = "Limonosov", CityId = cityId},
                new User { FirstName = "Igor", SecondName = "Savlepov", CityId = cityId},
                new User { FirstName = "Petr", SecondName = "Kolok", CityId = cityId},
                new User { FirstName = "Hleb", SecondName = "Kibets", CityId = cityId},
                new User { FirstName = "Sofia", SecondName = "Karpova", CityId = cityId}
            };

            _context.Users.AddRange(users);
            _context.SaveChanges();
        }

        private void AddUserCompany()
        {
            var companyId = _context.Skills.FirstOrDefault().Id;
            var users = _context.Users.ToArray();

            foreach (var user in users)
            {
                var userCompany = new UserCompany { UserId = user.Id, CompanyId = companyId };
                _context.UserCompanies.Add(userCompany);
            }

            _context.SaveChanges();
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
