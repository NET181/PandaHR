using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Services.Implementation
{
    public class SkillRequirementService : ISkillRequirementService
    {
        private readonly IUnitOfWork _uow;

        public SkillRequirementService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddAsync(SkillRequirement skillRequirement)
        {
            await _uow.SkillRequirements.Add(skillRequirement);
        }

        public async Task RemoveAsync(Guid id)
        {
            var skillRequirement = await GetByIdAsync(id);
            await RemoveAsync(skillRequirement);
        }

        public async Task RemoveAsync(SkillRequirement skillRequirement)
        {
            await _uow.SkillRequirements.Remove(skillRequirement);
        }

        public async Task<IEnumerable<SkillRequirement>> GetAllAsync()
        {
            return await _uow.SkillRequirements.GetAllAsync();
        }

        public async Task<SkillRequirement> GetByIdAsync(Guid id)
        {
            return await _uow.SkillRequirements.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(SkillRequirement skillRequirement)
        {
            await _uow.SkillRequirements.Update(skillRequirement);
        }
    }
}
