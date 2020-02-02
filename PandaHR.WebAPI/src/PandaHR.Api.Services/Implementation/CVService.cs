using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class CVService : ICVService
    {
        private readonly IUnitOfWork _uow;

        public CVService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddAsync(CV entity)
        {
            await _uow.CVs.Add(entity);
        }

        public async Task<IEnumerable<CV>> GetAllAsync()
        {
            var cVs = await _uow.CVs.GetAllAsync(
                include: s => s
                    .Include(k => k.SkillKnowledges)
                        .ThenInclude(s => s.KnowledgeLevel)
                    .Include(k => k.SkillKnowledges)
                        .ThenInclude(s => s.Skill)
                    .Include(k=> k.Qualification));

            return cVs;

         //   return await _uow.CVs.GetAllAsync();
        }

        public async Task<CV> GetByIdAsync(Guid id)
        {
            return await _uow.CVs.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Guid id)
        {
            var jobExperience = await GetByIdAsync(id);
            await RemoveAsync(jobExperience);
        }

        public async Task RemoveAsync(CV entity)
        {
            await _uow.CVs.Remove(entity);
        }

        public async Task UpdateAsync(CV entity)
        {
            await _uow.CVs.Update(entity);
        }
    }
}
