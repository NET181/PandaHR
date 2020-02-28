using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Services.Implementation
{
    public class KnowledgeLevelService : IKnowledgeLevelService
    {
        private readonly IUnitOfWork _uow;

        public KnowledgeLevelService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<KnowledgeLevel>> GetAllAsync()
        {
            var knowledgeLevels = await _uow.KnowledgeLevels
                .GetAllAsync(include: v => v
                    .Include(s => s.SkillKnowledgeTypes)
                        .ThenInclude(t => t.SkillType));

            return knowledgeLevels;
        }

        public async Task<KnowledgeLevel> AddAsync(KnowledgeLevel entity)
        {
            var res = await _uow.KnowledgeLevels.AddAsync(entity);
            await _uow.SaveChangesAsync();

            return res;
        }

        public async Task RemoveAsync(Guid id)
        {
            var knowledgeLevel = await GetByIdAsync(id);
            await RemoveAsync(knowledgeLevel);
        }

        public async Task RemoveAsync(KnowledgeLevel entity)
        {
            _uow.KnowledgeLevels.Remove(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task<KnowledgeLevel> GetByIdAsync(Guid id)
        {
            return await _uow.KnowledgeLevels.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(KnowledgeLevel entity)
        {
            _uow.KnowledgeLevels.Update(entity);
            await _uow.SaveChangesAsync();
        }
    }
}
