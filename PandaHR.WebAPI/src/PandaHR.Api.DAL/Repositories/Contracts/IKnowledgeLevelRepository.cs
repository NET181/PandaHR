using PandaHR.Api.DAL.DTOs.KnowledgeLevel;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IKnowledgeLevelRepository : IAsyncRepository<KnowledgeLevel>
    {
        Task<ICollection<KnowledgeLevelDTO>> GetKnowledgeLevelsBySkillTypeAsync(Guid skillTypeId);
    }
}
