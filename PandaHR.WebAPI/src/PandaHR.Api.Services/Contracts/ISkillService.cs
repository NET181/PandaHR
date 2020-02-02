    using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.KnowledgeLevel;
using PandaHR.Api.Services.Models.Skill;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ISkillService : IAsyncService<Skill>
    {
        Task<ICollection<SkillNameServiceModel>> GetSkillNames();
        Task<ICollection<SkillNameServiceModel>> GetSkillNamesByTerm(string term);
        Task<ICollection<KnowledgeLevelServiceModel>> GetKnowledgeLevelsBySkill(Guid skillId);
    }
}
