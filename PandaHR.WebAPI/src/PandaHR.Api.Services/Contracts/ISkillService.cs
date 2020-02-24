using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.KnowledgeLevel;
using PandaHR.Api.Services.Models.Skill;

namespace PandaHR.Api.Services.Contracts
{
    public interface ISkillService : IAsyncService<SkillServiceModel>
    {
        Task<ICollection<SkillNameServiceModel>> GetSkillNames();
        Task<ICollection<SkillNameServiceModel>> GetSkillNamesByTerm(string term);
        Task<ICollection<KnowledgeLevelServiceModel>> GetKnowledgeLevelsBySkill(Guid skillId);
    }
}
