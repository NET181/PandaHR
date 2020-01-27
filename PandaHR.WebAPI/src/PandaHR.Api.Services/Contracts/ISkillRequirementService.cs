using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ISkillRequirementService
    {
        Task<IEnumerable<SkillRequirement>> GetAllAsync();
        Task<SkillRequirement> GetByIdAsync(Guid id);
        Task AddAsync(SkillRequirement skillRequirement);
        Task UpdateAsync(SkillRequirement skillRequirement);
        Task RemoveAsync(Guid id);
    }
}
