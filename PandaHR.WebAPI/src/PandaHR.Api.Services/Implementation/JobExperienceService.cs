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

        public async Task AddAsync(JobExperience entity)
        {
            await _uow.JobExperiences.AddAsync(entity);
        }

        public async Task<IEnumerable<JobExperience>> GetAllAsync()
        {
            return await _uow.JobExperiences.GetAllAsync();
        }

        public async Task<JobExperience> GetByIdAsync(Guid id)
        {
            return await _uow.JobExperiences.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Guid id)
        {
            var jobExperience = await GetByIdAsync(id);
            await RemoveAsync(jobExperience);
        }

        public async Task RemoveAsync(JobExperience entity)
        {
            await _uow.JobExperiences.Remove(entity);
        }

        public async Task UpdateAsync(JobExperience entity)
        {
            await _uow.JobExperiences.Update(entity);
        }
    }
}
