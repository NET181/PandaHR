using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task Add(KnowledgeLevel knowledgeLevel)
        {
            await _uow.KnowledgeLevels.Add(knowledgeLevel);
        }

        public async Task Update(KnowledgeLevel knowledgeLevel)
        {
            await _uow.KnowledgeLevels.Update(knowledgeLevel);
        }

        public async Task Remove(KnowledgeLevel knowledgeLevel)
        {
            await _uow.KnowledgeLevels.Remove(knowledgeLevel);
        }

        public async Task<KnowledgeLevel> GetById(Guid id)
        {
            return await _uow.KnowledgeLevels.GetByIdAsync(id);
        }
    }
}
