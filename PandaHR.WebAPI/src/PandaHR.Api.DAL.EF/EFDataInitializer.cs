using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Models.Entities.Enums;

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
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            AddCompanies();
            AddCompanyCities();
            AddTechnologies();
            AddUser();
            AddUserCompany();
            AddCV();
            AddEducations();
            AddJobExperience();
            AddVacancy();
            AddVacancyCityLinks();
            AddSkillTypes();
            AddSkills();
            AddKnowledgeLevel();
            AddSkillKnowledge();
            AddSkillRequirements();
            AddTechnologySkills();
            AddSkillKnowledgeTypes();
            AddFlows();
        }

        private void AddCV()
        {
            var users = _context.Users.ToArray();
            var qualificationId = _context.Qualifications.ToArray();
            var technologyId = _context.Technologies.ToArray();

            var cv = new List<CV>()
            {
                new CV{ Id = new Guid("a6a7e31d-3db1-45b6-8172-3ad5556f65ce"), TechnologyId = technologyId[1].Id,
                    Summary = "Junior .Net Developer", UserId = users[0].Id, QualificationId = qualificationId[3].Id},
                new CV{ Id = new Guid("e92dd3cd-e6ef-4bce-8b78-9047d793a21b"), TechnologyId = technologyId[2].Id,
                    Summary = "Middle JS Developer", UserId = users[1].Id, QualificationId = qualificationId[0].Id},
                new CV{ Id = new Guid("fb06c4a3-c641-4222-84ac-f9e49a6a20dd"), TechnologyId = technologyId[1].Id,
                    Summary = "Trainee PHP Developer", UserId = users[2].Id, QualificationId = qualificationId[1].Id},
                new CV{ Id = new Guid("e2df5eff-3171-472c-9828-367bc5ed92bf"), TechnologyId = technologyId[1].Id,
                    Summary = "Junior .Net Developer", UserId = users[3].Id, QualificationId = qualificationId[3].Id},
                new CV{ Id = new Guid("61736a37-77f8-4c2b-87c1-0278d07f9011"), TechnologyId = technologyId[1].Id,
                    Summary = "Junior PHP Developer", UserId = users[4].Id, QualificationId = qualificationId[3].Id},
                new CV{ Id = new Guid("61736a37-77f8-4c2b-87c1-0278d07f9012"), TechnologyId = technologyId[1].Id,
                    Summary = "Senior .Net Developer", UserId = users[4].Id, QualificationId = qualificationId[2].Id},
                new CV{ Id = new Guid("61736a37-77f8-4c2b-87c1-0278d07f9013"), TechnologyId = technologyId[2].Id,
                    Summary = "Senior JS Developer", UserId = users[4].Id, QualificationId = qualificationId[2].Id},
                new CV{ Id = new Guid("61736a37-77f8-4c2b-87c1-0278d07f9014"), TechnologyId = technologyId[2].Id,
                    Summary = "Middle JS Developer", UserId = users[4].Id, QualificationId = qualificationId[0].Id},
                new CV{ Id = new Guid("61736a37-77f8-4c2b-87c1-0278d07f9015"), TechnologyId = technologyId[1].Id,
                    Summary = "Middle .Net Developer", UserId = users[4].Id, QualificationId = qualificationId[0].Id},
                new CV{ Id = new Guid("61736a37-77f8-4c2b-87c1-0278d07f9016"), TechnologyId = technologyId[1].Id,
                    Summary = "Senior .Net Developer", UserId = users[4].Id, QualificationId = qualificationId[2].Id},
                new CV{ Id = new Guid("61736a37-77f8-4c2b-87c1-0278d07f9017"), TechnologyId = technologyId[2].Id,
                    Summary = "Junior JS Developer", UserId = users[4].Id, QualificationId = qualificationId[3].Id},
            };

            for (int i = 0; i < 11; i++)
            {
                users[i].CV = cv[i];
                users[i].CVId = cv[i].Id;
                _context.Users.Update(users[i]);
            }

            _context.SaveChanges();
        }

        private void AddVacancy()
        {
            var companyId = _context.Companies.FirstOrDefault().Id;
            var userId = _context.Users.FirstOrDefault().Id;
            var qualificationId = _context.Qualifications.ToArray();
            var technologyId = _context.Technologies.FirstOrDefault().Id;

            var vacancies = new Vacancy[]
            {
                new Vacancy
                {
                    Id = new Guid("623af0cf-21c1-4dc6-8f86-09601e9dba86"),
                    TechnologyId = technologyId, CompanyId = companyId,
                    Description = "Best vacancy ever!",
                    UserId = userId, QualificationId = qualificationId[3].Id
                },
                new Vacancy
                {
                    Id = new Guid("a8c58938-2339-4466-b662-023be9e4e9a5"),
                    TechnologyId = technologyId, CompanyId = companyId,
                    Description = "Even better vacancy than the previous!",
                    UserId = userId, QualificationId = qualificationId[3].Id
                },
                new Vacancy
                {
                    Id = new Guid("aeed7aa1-78fa-427c-b2f8-30bbd08df1b5"),
                    TechnologyId = technologyId, CompanyId = companyId,
                    Description = "Vacancy for .Net developer",
                    UserId = userId, QualificationId = qualificationId[3].Id
                }
            };

            _context.Vacancies.AddRange(vacancies);
            _context.SaveChanges();
        }

        private void AddVacancyCityLinks()
        {
            var cities = _context.Cities.AsNoTracking().Select(c => c.Id).ToArray();
            var vacancies = _context.Vacancies.AsNoTracking().Select(t => t.Id).ToArray();

            var vacancyCity = new VacancyCity[]
                {
                    new VacancyCity() { CityId = cities[0], VacancyId = vacancies[0]},
                    new VacancyCity() { CityId = cities[0], VacancyId = vacancies[1]},
                    new VacancyCity() { CityId = cities[1], VacancyId = vacancies[1]},
                    new VacancyCity() { CityId = cities[1], VacancyId = vacancies[2]},
                    new VacancyCity() { CityId = cities[2], VacancyId = vacancies[0]},
                    new VacancyCity() { CityId = cities[2], VacancyId = vacancies[1]},
                    new VacancyCity() { CityId = cities[2], VacancyId = vacancies[2]}
                };

            _context.VacancyCities.AddRange(vacancyCity);
            _context.SaveChanges();
        }

        private void AddJobExperience()
        {
            var cvId = _context.CVs.FirstOrDefault().Id;

            var jobExperiences = new JobExperience[]
            {
                new JobExperience
                {
                    CVId = cvId, CompanyName = "SoftServe", ProjectName = "Sports Store",
                    Description = "Fully working shop", StartDate = new DateTime(15,12,23),
                    FinishDate = new DateTime(17,5,20)
                },
                new JobExperience
                {
                    CVId = cvId, CompanyName = "Oracle", ProjectName = "Windows Xp developing",
                    Description = "Developing OS system", StartDate = new DateTime(14,12,23),
                    FinishDate = new DateTime(15,5,15)
                }
            };

            _context.JobExperiences.AddRange(jobExperiences);
            _context.SaveChanges();
        }

        private void AddSkillKnowledge()
        {

            var skillId = _context.Skills.AsNoTracking().ToArray();
            var knowledgeLevelId = _context.KnowledgeLevels.AsNoTracking().ToArray();
            var cv = _context.CVs.AsNoTracking().ToArray();
            var experience = _context.Experiences.AsNoTracking().ToArray();

            var skillKnowledges = new SkillKnowledge[]
            {
                new SkillKnowledge { SkillId = skillId[0].Id, KnowledgeLevelId = knowledgeLevelId[0].Id, CVId = cv[2].Id, //trainee .ner
                    ExperienceId = experience[0].Id},
                new SkillKnowledge { SkillId = skillId[1].Id, KnowledgeLevelId = knowledgeLevelId[1].Id, CVId = cv[2].Id,
                    ExperienceId = experience[1].Id},
                new SkillKnowledge { SkillId = skillId[4].Id, KnowledgeLevelId = knowledgeLevelId[2].Id, CVId = cv[2].Id,
                  ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[0].Id, KnowledgeLevelId = knowledgeLevelId[7].Id, CVId = cv[0].Id, //jun .net
                   ExperienceId = experience[1].Id},
                new SkillKnowledge { SkillId = skillId[4].Id, KnowledgeLevelId = knowledgeLevelId[9].Id, CVId = cv[0].Id,
                 ExperienceId = experience[1].Id},
                new SkillKnowledge { SkillId = skillId[5].Id, KnowledgeLevelId = knowledgeLevelId[4].Id, CVId = cv[0].Id,
                    ExperienceId = experience[1].Id},
                new SkillKnowledge { SkillId = skillId[3].Id, KnowledgeLevelId = knowledgeLevelId[7].Id, CVId = cv[0].Id,
                    ExperienceId = experience[1].Id},
                new SkillKnowledge { SkillId = skillId[1].Id, KnowledgeLevelId = knowledgeLevelId[3].Id, CVId = cv[0].Id,
                    ExperienceId = experience[0].Id},
                new SkillKnowledge { SkillId = skillId[19].Id, KnowledgeLevelId = knowledgeLevelId[5].Id, CVId = cv[0].Id,
                    ExperienceId = experience[1].Id},
                new SkillKnowledge { SkillId = skillId[0].Id, KnowledgeLevelId = knowledgeLevelId[7].Id, CVId = cv[8].Id, //middle .net
                    ExperienceId = experience[3].Id},
                new SkillKnowledge { SkillId = skillId[4].Id, KnowledgeLevelId = knowledgeLevelId[13].Id, CVId = cv[8].Id,
                   ExperienceId = experience[3].Id},
                new SkillKnowledge { SkillId = skillId[5].Id, KnowledgeLevelId = knowledgeLevelId[12].Id, CVId = cv[8].Id,
                   ExperienceId = experience[3].Id},
                new SkillKnowledge { SkillId = skillId[3].Id, KnowledgeLevelId = knowledgeLevelId[15].Id, CVId = cv[8].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[23].Id, KnowledgeLevelId = knowledgeLevelId[15].Id, CVId = cv[8].Id,
                   ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[1].Id, KnowledgeLevelId = knowledgeLevelId[6].Id, CVId = cv[8].Id,
                    ExperienceId = experience[3].Id},
                new SkillKnowledge { SkillId = skillId[19].Id, KnowledgeLevelId = knowledgeLevelId[11].Id, CVId = cv[8].Id,
                   ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[0].Id, KnowledgeLevelId = knowledgeLevelId[15].Id, CVId = cv[9].Id, //sr .net
                   ExperienceId = experience[4].Id},
                new SkillKnowledge { SkillId = skillId[4].Id, KnowledgeLevelId = knowledgeLevelId[14].Id, CVId = cv[9].Id,
                   ExperienceId = experience[4].Id},
                new SkillKnowledge { SkillId = skillId[5].Id, KnowledgeLevelId = knowledgeLevelId[16].Id, CVId = cv[9].Id,
                   ExperienceId = experience[4].Id},
                new SkillKnowledge { SkillId = skillId[3].Id, KnowledgeLevelId = knowledgeLevelId[15].Id, CVId = cv[9].Id,
                   ExperienceId = experience[4].Id},
                new SkillKnowledge { SkillId = skillId[1].Id, KnowledgeLevelId = knowledgeLevelId[10].Id, CVId = cv[9].Id,
                   ExperienceId = experience[4].Id},
                new SkillKnowledge { SkillId = skillId[19].Id, KnowledgeLevelId = knowledgeLevelId[15].Id, CVId = cv[9].Id,
                   ExperienceId = experience[4].Id},
                new SkillKnowledge { SkillId = skillId[23].Id, KnowledgeLevelId = knowledgeLevelId[15].Id, CVId = cv[9].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[7].Id, KnowledgeLevelId = knowledgeLevelId[15].Id, CVId = cv[9].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[8].Id, KnowledgeLevelId = knowledgeLevelId[15].Id, CVId = cv[9].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[2].Id, KnowledgeLevelId = knowledgeLevelId[8].Id, CVId = cv[9].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[1].Id, KnowledgeLevelId = knowledgeLevelId[15].Id, CVId = cv[6].Id, //sr js
                    ExperienceId = experience[4].Id},
                new SkillKnowledge { SkillId = skillId[8].Id, KnowledgeLevelId = knowledgeLevelId[14].Id, CVId = cv[6].Id,
                    ExperienceId = experience[4].Id},
                new SkillKnowledge { SkillId = skillId[9].Id, KnowledgeLevelId = knowledgeLevelId[16].Id, CVId = cv[6].Id,
                   ExperienceId = experience[4].Id},
                new SkillKnowledge { SkillId = skillId[18].Id, KnowledgeLevelId = knowledgeLevelId[15].Id, CVId = cv[6].Id,
                   ExperienceId = experience[4].Id},
                new SkillKnowledge { SkillId = skillId[19].Id, KnowledgeLevelId = knowledgeLevelId[10].Id, CVId = cv[6].Id,
                   ExperienceId = experience[4].Id},
                new SkillKnowledge { SkillId = skillId[10].Id, KnowledgeLevelId = knowledgeLevelId[15].Id, CVId = cv[6].Id,
                    ExperienceId = experience[4].Id},
                new SkillKnowledge { SkillId = skillId[1].Id, KnowledgeLevelId = knowledgeLevelId[10].Id, CVId = cv[1].Id, //mid js
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[8].Id, KnowledgeLevelId = knowledgeLevelId[9].Id, CVId = cv[1].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[9].Id, KnowledgeLevelId = knowledgeLevelId[10].Id, CVId = cv[1].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[18].Id, KnowledgeLevelId = knowledgeLevelId[9].Id, CVId = cv[1].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[19].Id, KnowledgeLevelId = knowledgeLevelId[10].Id, CVId = cv[1].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[10].Id, KnowledgeLevelId = knowledgeLevelId[8].Id, CVId = cv[1].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[1].Id, KnowledgeLevelId = knowledgeLevelId[8].Id, CVId = cv[7].Id, //mid js2
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[8].Id, KnowledgeLevelId = knowledgeLevelId[11].Id, CVId = cv[7].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[9].Id, KnowledgeLevelId = knowledgeLevelId[12].Id, CVId = cv[7].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[18].Id, KnowledgeLevelId = knowledgeLevelId[10].Id, CVId = cv[7].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[19].Id, KnowledgeLevelId = knowledgeLevelId[7].Id, CVId = cv[7].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[10].Id, KnowledgeLevelId = knowledgeLevelId[5].Id, CVId = cv[7].Id,
                    ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[1].Id, KnowledgeLevelId = knowledgeLevelId[3].Id, CVId = cv[10].Id, //jun js
                   ExperienceId = experience[2].Id},
                new SkillKnowledge { SkillId = skillId[8].Id, KnowledgeLevelId = knowledgeLevelId[4].Id, CVId = cv[10].Id,
                    ExperienceId = experience[0].Id},
                new SkillKnowledge { SkillId = skillId[9].Id, KnowledgeLevelId = knowledgeLevelId[6].Id, CVId = cv[10].Id,
                    ExperienceId = experience[0].Id},
                new SkillKnowledge { SkillId = skillId[18].Id, KnowledgeLevelId = knowledgeLevelId[5].Id, CVId = cv[10].Id,
                    ExperienceId = experience[1].Id},
                new SkillKnowledge { SkillId = skillId[19].Id, KnowledgeLevelId = knowledgeLevelId[3].Id, CVId = cv[10].Id,
                    ExperienceId = experience[0].Id},
                new SkillKnowledge { SkillId = skillId[10].Id, KnowledgeLevelId = knowledgeLevelId[7].Id, CVId = cv[10].Id,
                    ExperienceId = experience[0].Id},
            };

            _context.SkillKnowledges.AddRange(skillKnowledges);
            _context.SaveChanges();

        }

        private void AddUser()
        {
            {
                var cityId = _context.Cities.FirstOrDefault().Id;

                var users = new User[]
                {
                new User { Id = new Guid("b072e561-9258-4502-8b40-c545b121cb0c"), FirstName = "Kolya",
                    SecondName = "Limonosov", CityId = cityId},
                new User { Id = new Guid("b072e511-9238-4502-8b40-c545b121cb0c"), FirstName = "Oleksandr",
                    SecondName = "Ivanov", CityId = cityId},
                new User { Id = new Guid("396f6c38-92e1-43b2-9fd0-39db398144e8"), FirstName = "Igor",
                    SecondName = "Savlepov", CityId = cityId},
                new User { Id = new Guid("8f52436e-274b-4944-94bc-8e8e7497c88c"), FirstName = "Petr",
                    SecondName = "Kolok", CityId = cityId},
                new User { Id = new Guid("d2e34494-2a44-4c0d-a09b-4cc9849e4e97"), FirstName = "Hleb",
                    SecondName = "Kibets", CityId = cityId},
                new User { Id = new Guid("5e0b7eed-1e24-4166-8f00-a563923d1fc5"), FirstName = "Sofia",
                    SecondName = "Karpova", CityId = cityId},
                new User { Id = new Guid("b111e511-9238-4502-8b40-c545b121cb0c"), FirstName = "Inna",
                    SecondName = "Kopieva", CityId = cityId},
                new User { Id = new Guid("b222e511-9238-4502-8b40-c545b121cb0c"), FirstName = "Boris",
                    SecondName = "Britva", CityId = cityId},
                new User { Id = new Guid("b333e511-9238-4502-8b40-c545b121cb0c"), FirstName = "Olha",
                    SecondName = "Glava", CityId = cityId},
                new User { Id = new Guid("b444e511-9238-4502-8b40-c545b121cb0c"), FirstName = "Pavlo",
                    SecondName = "Rapiev", CityId = cityId},
                new User { Id = new Guid("b323e511-9238-4502-8b40-c545b121cb0c"), FirstName = "Rostik",
                    SecondName = "Kurtaev", CityId = cityId},
                new User { Id = new Guid("b353e511-9238-4502-8b40-c545b121cb0c"), FirstName = "Ivan",
                    SecondName = "Smirnov", CityId = cityId}
                };

                _context.Users.AddRange(users);
                _context.SaveChanges();
            }
        }

        private void AddUserCompany()
        {
            var companyId = _context.Companies.FirstOrDefault().Id;
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
                new Company
                {
                    Id = new Guid("53653054-750e-4ed8-a636-db00ee728b15"),
                    Name = "SoftServe", Description = "Very good company"
                },
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
                new CompanyCity{CompanyId = companies[3].Id, CityId = cities[2].Id},
                new CompanyCity{CompanyId = companies[4].Id, CityId = cities[1].Id},
            };

            _context.CompanyCities.AddRange(companyCities);
            _context.SaveChanges();
        }

        private void AddSkills()
        {
            var skillType = _context.SkillTypes.ToArray();

            var SharpParentSkill = new Skill
            {
                Name = "C#",
                IsDeleted = false,
                RootSkillId = null,
                SkillTypeId = skillType[0].Id,
                Id = new Guid("980a6b85-b828-4553-92bb-410531539036")
            };

            var JSParentSkill = new Skill
            {
                Name = "JS",
                IsDeleted = false,
                RootSkillId = null,
                SkillTypeId = skillType[0].Id,
                Id = new Guid("59b63f31-1a0a-4028-9983-c844acf9ca56")
            };

            var PHPParentSkill = new Skill
            {
                Name = "PHP",
                IsDeleted = false,
                RootSkillId = null,
                SkillTypeId = skillType[0].Id,
                Id = new Guid("3756371d-5fdf-4784-bf8e-08c2a21e98f9")
            };

            var SQLParentSkill = new Skill
            {
                Name = "SQL",
                IsDeleted = false,
                RootSkillId = null,
                SkillTypeId = skillType[0].Id,
                Id = new Guid("9f0e7895-f774-4d89-be9c-c4bdb0fe4bf8")
            };

            _context.Skills.Add(SharpParentSkill);
            _context.Skills.Add(JSParentSkill);
            _context.Skills.Add(PHPParentSkill);
            _context.Skills.Add(SQLParentSkill);

            var skills = new Skill[]
            {
                new Skill {Id = new Guid("34c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "Asp.Net Core", IsDeleted = false,
                    RootSkillId = SharpParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("31c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "EF", IsDeleted = false,
                    RootSkillId = SharpParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("32c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "WPF", IsDeleted = false,
                    RootSkillId = SharpParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("35c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "Web Forms", IsDeleted = false,
                    RootSkillId = SharpParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("36c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "React", IsDeleted = false,
                    RootSkillId = JSParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("37c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "Vue", IsDeleted = false,
                    RootSkillId = JSParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("38c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "Angular", IsDeleted = false,
                    RootSkillId = JSParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("39c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "Ember", IsDeleted = false,
                    RootSkillId = JSParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("41c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "Backbone. js", IsDeleted = false,
                    RootSkillId = JSParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("42c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "Laravel", IsDeleted = false,
                    RootSkillId = PHPParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("43c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "CodeIgniter", IsDeleted = false,
                    RootSkillId = PHPParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("44c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "Symfony", IsDeleted = false,
                    RootSkillId = PHPParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("45c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "Zend", IsDeleted = false,
                    RootSkillId = PHPParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("46c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "Yii", IsDeleted = false,
                    RootSkillId = PHPParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("47c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "CakePHP", IsDeleted = false,
                    RootSkillId = PHPParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("48c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "CSS", IsDeleted = false,
                    RootSkillId = null, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("51c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "HTML", IsDeleted = false,
                    RootSkillId = null, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("52c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "MySQL", IsDeleted = false,
                    RootSkillId = SQLParentSkill.Id, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("53c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "WordPress", IsDeleted = false,
                    RootSkillId = null, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("54c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "Bootstrap", IsDeleted = false,
                    RootSkillId = null, SkillTypeId = skillType[0].Id},
                new Skill {Id = new Guid("55c9f63d-17f7-47f9-a928-8273be0a7aac"), Name = "MongoDB", IsDeleted = false,
                    RootSkillId = null, SkillTypeId = skillType[0].Id}
            };

            _context.Skills.AddRange(skills);
            _context.SaveChanges();
        }

        private void AddTechnologies()
        {
            var parentTechnology = new Technology()
            {
                Id = new Guid("a43f4b05-6cb1-4c72-9ebb-1fe5fd1fc62e"),
                Name = "Fullstack",
                IsDeleted = false,
                ParentId = null
            };
            _context.Technologies.Add(parentTechnology);

            var technologies = new Technology[]
            {
                 new Technology()
                 {
                    Id = new Guid("f43f4b05-6cb1-4c72-9ebb-1fe5fd1fc62e"),
                    Name = "Back-end",
                    IsDeleted = false,
                    ParentId = parentTechnology.Id
                 },
                 new Technology()
                 {
                    Id = new Guid("c3c0583c-a662-421a-8013-ba05ded4a279"),
                    Name = "Front-end",
                    IsDeleted = false,
                    ParentId = parentTechnology.Id
                 }
            };

            _context.Technologies.AddRange(technologies);
            _context.SaveChanges();
        }

        private void AddTechnologySkills()
        {
            var skills = _context.Skills.ToArray();

            var technologySkills = new TechnologySkill[]
            {
                 new TechnologySkill()
                 {
                    TechnologyId = new Guid("f43f4b05-6cb1-4c72-9ebb-1fe5fd1fc62e"),
                    SkillId = skills[0].Id,
                    IsDeleted = false
                 },
                 new TechnologySkill()
                 {
                    TechnologyId = new Guid("c3c0583c-a662-421a-8013-ba05ded4a279"),
                    SkillId = skills[1].Id,
                    IsDeleted = false
                 }
            };

            _context.TechnologySkills.AddRange(technologySkills);
            _context.SaveChanges();
        }

        private void AddSkillRequirements()
        {
            var skills = _context.Skills.ToArray();
            var knowledgeLevels = _context.KnowledgeLevels.ToArray();
            var vacancies = _context.Vacancies.ToArray();
            var experience = _context.Experiences.AsNoTracking().ToArray();

            var skillRequirements = new SkillRequirement[]
            {
                new SkillRequirement
                {
                    Weight = 25, ExperienceId = experience[0].Id, IsDeleted = false,
                    SkillId = skills[0].Id, KnowledgeLevelId = knowledgeLevels[0].Id,
                    VacancyId = vacancies[0].Id
                },
                new SkillRequirement
                {
                    Weight = 80, ExperienceId = experience[2].Id, IsDeleted = false,
                    SkillId = skills[1].Id, KnowledgeLevelId = knowledgeLevels[2].Id,
                    VacancyId = vacancies[2].Id
                },
                new SkillRequirement
                {
                    Weight = 70, ExperienceId = experience[3].Id, IsDeleted = false,
                    SkillId = skills[2].Id, KnowledgeLevelId = knowledgeLevels[2].Id,
                    VacancyId = vacancies[0].Id
                },
                new SkillRequirement
                {
                    Weight = 70, ExperienceId = experience[1].Id, IsDeleted = false,
                    SkillId = skills[0].Id, KnowledgeLevelId = knowledgeLevels[5].Id,
                    VacancyId = vacancies[1].Id
                },
                 new SkillRequirement
                {
                    Weight = 30, ExperienceId = experience[1].Id, IsDeleted = false,
                    SkillId = skills[19].Id, KnowledgeLevelId = knowledgeLevels[5].Id,
                    VacancyId = vacancies[1].Id
                },
                new SkillRequirement
                {
                    Weight = 30, ExperienceId = experience[3].Id, IsDeleted = false,
                    SkillId = skills[1].Id, KnowledgeLevelId = knowledgeLevels[6].Id,
                    VacancyId = vacancies[1].Id
                },
                new SkillRequirement
                {
                    Weight = 75, ExperienceId = experience[3].Id, IsDeleted = false,
                    SkillId = skills[4].Id, KnowledgeLevelId = knowledgeLevels[6].Id,
                    VacancyId = vacancies[1].Id
                },
                new SkillRequirement
                {
                    Weight = 50, ExperienceId = experience[3].Id, IsDeleted = false,
                    SkillId = skills[5].Id, KnowledgeLevelId = knowledgeLevels[7].Id,
                    VacancyId = vacancies[1].Id
                },
                new SkillRequirement
                {
                    Weight = 50, ExperienceId = experience[3].Id, IsDeleted = false,
                    SkillId = skills[3].Id, KnowledgeLevelId = knowledgeLevels[7].Id,
                    VacancyId = vacancies[1].Id
                }
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
                new Education
                {
                    PlaceName = "DNU", UserId = users[0].Id,
                    SpecialityId = specialities[0].Id,
                    DegreeId = degrees[0].Id, DateStart = new DateTime(2017,08,1),
                    DateEnd = new DateTime(2021,08,1),IsDeleted = false
                },
                new Education
                {
                    PlaceName = "KNTU", UserId = users[0].Id, SpecialityId = specialities[1].Id,
                    DegreeId = degrees[1].Id, DateStart = new DateTime(2021,08,1),
                    DateEnd = new DateTime(2022,08,1),IsDeleted = false
                },
                new Education
                {
                    PlaceName = "DIIT", UserId = users[1].Id, SpecialityId = specialities[2].Id,
                    DegreeId = degrees[2].Id, DateStart = new DateTime(2019,10,1),
                    DateEnd = new DateTime(2023,08,1),IsDeleted = false
                },
                new Education
                {
                    PlaceName = "KPI", UserId = users[2].Id, SpecialityId = specialities[0].Id,
                    DegreeId = degrees[1].Id, DateStart = new DateTime(2016,10,1),
                    DateEnd = new DateTime(2021,08,1),IsDeleted = false
                },
                new Education
                {
                    PlaceName = "HAI", UserId = users[2].Id, SpecialityId = specialities[1].Id,
                    DegreeId = degrees[1].Id, DateStart = new DateTime(2017,10,1),
                    DateEnd = new DateTime(2022,08,1),IsDeleted = false
                }
            };

            _context.Educations.AddRange(educations);
            _context.SaveChanges();
        }
        private void AddSkillTypes()
        {
            List<SkillType> skillTypes = new List<SkillType>()
            {
                new SkillType {Id = new Guid("b072e511-9258-4502-8b33-c545b121cb0c"),
                    Name = "HardSkill", IsDeleted = false, Value = 1},
                new SkillType {Id = new Guid("b072e511-9258-4502-8b35-c545b121cb0c"),
                    Name = "SoftSkill", IsDeleted = false, Value = 3},
                new SkillType {Id = new Guid("b072e511-9258-4502-8b66-c545b121cb0c"),
                    Name = "LanguageSkill", IsDeleted = false, Value = 2},
            };

            _context.SkillTypes.AddRange(skillTypes);
            _context.SaveChanges();
        }

        private void AddKnowledgeLevel()
        {
            List<KnowledgeLevel> knowledgeLevels = new List<KnowledgeLevel>()
            {
                new KnowledgeLevel {Id = new Guid("2cb573c8-c593-445a-a1ca-d072fba8b47e"),
                    Name = "BeginnerLow", IsDeleted = false},
                new KnowledgeLevel {Name = "Beginner", IsDeleted = false},
                new KnowledgeLevel {Name = "BeginnerStrong", IsDeleted = false},
                new KnowledgeLevel {Name = "ElementaryLow", IsDeleted = false},
                new KnowledgeLevel {Name = "Elementary", IsDeleted = false},
                new KnowledgeLevel {Name = "ElementaryStrong", IsDeleted = false},
                new KnowledgeLevel {Name = "Pre–IntermediateLow", IsDeleted = false},
                new KnowledgeLevel {Name = "Pre–Intermediate", IsDeleted = false},
                new KnowledgeLevel {Name = "Pre–IntermediateStrong", IsDeleted = false},
                new KnowledgeLevel {Name = "IntermediateLow", IsDeleted = false},
                new KnowledgeLevel {Name = "Intermediate", IsDeleted = false},
                new KnowledgeLevel {Name = "IntermediateStrong", IsDeleted = false},
                new KnowledgeLevel {Name = "Upper–IntermediateLow", IsDeleted = false},
                new KnowledgeLevel {Name = "Upper–Intermediate", IsDeleted = false},
                new KnowledgeLevel {Name = "Upper–IntermediateStrong", IsDeleted = false},
                new KnowledgeLevel {Name = "AdvancedLow", IsDeleted = false},
                new KnowledgeLevel {Name = "Advanced", IsDeleted = false},
                new KnowledgeLevel {Name = "AdvancedStrong", IsDeleted = false}
            };

            _context.KnowledgeLevels.AddRange(knowledgeLevels);
            _context.SaveChanges();
        }

        private void AddSkillKnowledgeTypes()
        {
            var skilltypeList = _context.SkillTypes.Take(3).ToArray();
            var knowledgeType = _context.KnowledgeLevels.Take(18).ToArray();

            foreach (var skilltype in skilltypeList)
            {
                skilltype.SkillKnowledgeTypes = knowledgeType.Select((kn, index) => new SkillKnowledgeType()
                {
                    SkillTypeId = skilltype.Id,
                    KnowledgeLevelId = kn.Id,
                    Value = index
                }).ToList();
            }

            _context.SaveChanges();
        }

        private void AddFlows()
        {
            #region CVIDs and VacancyIDs hardcoded to get VacancyCVFlowTest.GetStatusTest passed!
            var cVs = _context.CVs.ToArray();
            var vacancies = _context.Vacancies.ToArray();
            #endregion

            VacancyCVFlow[] flows = new VacancyCVFlow[]
                {
                    new VacancyCVFlow()
                    {
                        Id = new Guid("342f6c46-9bd1-4508-b1f7-6a8eed1ac270"),
                        CVId = cVs[0].Id, VacancyId = vacancies[0].Id,
                        Status = VacancyCVStatus.Draft
                    },
                    new VacancyCVFlow()
                    {
                        Id = new Guid("8c3978e9-bb20-4170-8a7e-20ae97250da3"),
                        CVId = cVs[1].Id, VacancyId = vacancies[0].Id,
                        Status = VacancyCVStatus.CVPreparation,
                        Files = new HashSet<VacancyCVFile>()
                        {
                            new VacancyCVFile() { Name = "DraftCV", Path = @"\\pathtofile"},
                            new VacancyCVFile() { Name = "DraftCV2", Path = @"\\pathtofile2"}
                        }
                    },
                    new VacancyCVFlow()
                    {
                        Id = new Guid("fe9098da-3258-4aac-96dd-88b0b65e2805"),
                        CVId = cVs[2].Id, VacancyId = vacancies[0].Id,
                        Status = VacancyCVStatus.Cancelled
                    },
                    new VacancyCVFlow()
                    {
                        Id = new Guid("2888146e-e198-4fa4-bcc5-c6b488b3d812"),
                        CVId = cVs[3].Id, VacancyId = vacancies[0].Id,
                        Status = VacancyCVStatus.CVReadyForClient
                    },
                    new VacancyCVFlow()
                    {
                        Id = new Guid("ad85fc0a-7f11-4d8f-9b3a-2b655658aaaf"),
                        CVId = cVs[0].Id, VacancyId = vacancies[1].Id,
                        Status = VacancyCVStatus.Draft
                    },
                    new VacancyCVFlow()
                    {
                        Id = new Guid("0fecd44f-a898-4c12-b768-b5c6986429ee"),
                        CVId = cVs[4].Id, VacancyId = vacancies[1].Id,
                        Status = VacancyCVStatus.Draft
                    }
                };

            _context.VacancyCVFlows.AddRange(flows);
            _context.SaveChanges();
        }
    }
}

