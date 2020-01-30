using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ISkillTypeService
    {
        Task<IEnumerable<SkillType>> GetAllAsync();

        Task Add(SkillType knowledgeLevel);

        Task Update(SkillType knowledgeLevel);

        Task Remove(SkillType knowledgeLevel);

        Task<SkillType> GetById(Guid id);
    }
}
