using System;
using System.Linq;
using System.Threading.Tasks;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Services.Implementation
{
    public class JobExperienceService : IJobExperienceService
    {
        private readonly IUnitOfWork _uow;
        public JobExperienceService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void Add(JobExperience jobExperience)
        {
            _uow.JobExperiences.Add(jobExperience);
        }

        public async Task<JobExperience> GetById(Guid id)
        {
            return await _uow.JobExperiences.GetById(id);
        }

        public void Remove(JobExperience jobExperience)
        {
            _uow.JobExperiences.Remove(jobExperience);
        }

        public void Update(JobExperience jobExperience)
        {
            throw new NotImplementedException();
        }
    }
}
