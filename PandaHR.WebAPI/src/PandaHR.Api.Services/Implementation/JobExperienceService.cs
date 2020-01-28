using System;
using System.Collections.Generic;
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

        public Task AddAsync(JobExperience entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<JobExperience>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<JobExperience> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(JobExperience entity)
        {
            throw new NotImplementedException();
        }

        public void Update(JobExperience jobExperience)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(JobExperience entity)
        {
            throw new NotImplementedException();
        }
    }
}
