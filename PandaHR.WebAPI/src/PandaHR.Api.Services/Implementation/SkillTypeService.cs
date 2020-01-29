using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class SkillTypeService : ISkillTypeService
    {
        private readonly IUnitOfWork _uow;

        public SkillTypeService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<SkillType>> GetAllAsync()
        {
            var skillTypes = await _uow.SkillTypes
                .GetAllAsync(include: v => v
                    .Include(s => s.SkillKnowledgeTypes));

            return skillTypes;
        }

        public async Task AddAsync(SkillType entity)
        {
            await _uow.SkillTypes.Add(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var skillType = await GetByIdAsync(id);
            await RemoveAsync(skillType);
        }

        public async Task RemoveAsync(SkillType entity)
        {
            await _uow.SkillTypes.Remove(entity);
        }

        public async Task<SkillType> GetByIdAsync(Guid id)
        {
            return await _uow.SkillTypes.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(SkillType entity)
        {
            await _uow.SkillTypes.Update(entity);
        }
    }
}
