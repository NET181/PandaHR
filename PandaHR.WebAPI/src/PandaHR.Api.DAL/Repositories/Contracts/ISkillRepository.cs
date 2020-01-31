using PandaHR.Api.DAL.DTOs.Skill;
using PandaHR.Api.DAL.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface ISkillRepository : IAsyncRepository<Skill>
    {
        Task<ICollection<SkillNameDTO>> GetSkillNameDTOsAsync();
    }
}
