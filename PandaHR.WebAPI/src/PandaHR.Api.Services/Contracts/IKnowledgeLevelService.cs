using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface IKnowledgeLevelService
    {
        Task<IEnumerable<KnowledgeLevel>> GetAllAsync();

        Task Add(KnowledgeLevel knowledgeLevel);

        Task Update(KnowledgeLevel knowledgeLevel);

        Task Remove(KnowledgeLevel knowledgeLevel);

        Task<KnowledgeLevel> GetById(object id);
    }
}
