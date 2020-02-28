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

        public async Task<JobExperience> AddAsync(JobExperience entity)
        {
            var res = await _uow.JobExperiences.AddAsync(entity);
            await _uow.SaveChangesAsync();

            return res;
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
            _uow.JobExperiences.Remove(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(JobExperience entity)
        {
            _uow.JobExperiences.Update(entity);
            await _uow.SaveChangesAsync();
        }
    }
}
