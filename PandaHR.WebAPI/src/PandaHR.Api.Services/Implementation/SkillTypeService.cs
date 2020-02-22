using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

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

        public async Task<SkillType> AddAsync(SkillType entity)
        {
            var res = await _uow.SkillTypes.AddAsync(entity);
            await _uow.SkillTypes.SaveAsync();

            return res;
        }

        public async Task RemoveAsync(Guid id)
        {
            var skillType = await GetByIdAsync(id);
            await RemoveAsync(skillType);
        }

        public async Task RemoveAsync(SkillType entity)
        {
            _uow.SkillTypes.Remove(entity);
            await _uow.SkillTypes.SaveAsync();
        }

        public async Task<SkillType> GetByIdAsync(Guid id)
        {
            return await _uow.SkillTypes.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(SkillType entity)
        {
            _uow.SkillTypes.Update(entity);
            await _uow.SkillTypes.SaveAsync();
        }
    }
}
