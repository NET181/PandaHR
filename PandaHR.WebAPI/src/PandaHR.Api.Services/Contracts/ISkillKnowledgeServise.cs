using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace PandaHR.Api.Services.Contracts
{
    public interface ISkillKnowledgeServise
    {
        Task<IEnumerable<SkillKnowledge>> GetAllAsync();
        Task<SkillKnowledge> GetById(Guid id);
        Task Add(SkillKnowledge skill);
        Task Update(SkillKnowledge skill);
        Task Remove(SkillKnowledge skill);
    }
}
