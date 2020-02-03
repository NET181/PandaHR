using PandaHR.Api.DAL.DTOs.Skill;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface ISkillRepository : IAsyncRepository<Skill>
    {
        Task<ICollection<SkillNameDTO>> GetSkillNameDTOsAsync(Expression<Func<Skill, bool>> predicate = null,
                                                                int maxCountToTake = -1);

        Task<Guid> GetSkillTypeIdBySkill(Guid id);
    }
}
