using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
