using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.DTO.Experience;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IExperienceRepository : IAsyncRepository<Experience>
    {
        Task<ICollection<ExperienceDTO>> GetExperienceDTOsAsync();
    }
}
