using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class SkillService : IAsyncService<Skill>, ISkillService
    {
        private readonly IUnitOfWork _uow;

        public SkillService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            var skills = await _uow.Skills.GetAllAsync(predicate: s => s.RootSkill == null,
                include: s => s
                    .Include(k => k.SkillKnowledges)
                        .ThenInclude(s => s.KnowledgeLevel)
                    .Include(k => k.SkillType)
                    .Include(k => k.SkillRequirements)
                        .ThenInclude(s => s.Vacancy)
                    .Include(k => k.SubSkills));

            return skills;
        }

        public async Task<Skill> GetByIdAsync(Guid id)
        {
            return await _uow.Skills.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Skill skill)
        {
            await _uow.Skills.Add(skill);
        }

        public async Task UpdateAsync(Skill skill)
        {
            await _uow.Skills.Update(skill);
        }

        public async Task RemoveAsync(Skill skill)
        {
            await _uow.Skills.Remove(skill);
        }

        public async Task RemoveAsync(Guid id)
        {
            var skill = await GetByIdAsync(id);
            await RemoveAsync(skill);
        }
    }
}
