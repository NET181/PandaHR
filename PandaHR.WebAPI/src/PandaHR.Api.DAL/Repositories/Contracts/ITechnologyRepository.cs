using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.DTOs.Technology;
using PandaHR.Api.DAL.Models.Entities;
namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface ITechnologyRepository : IAsyncRepository<Technology>
    {
        Task<ICollection<TechnologyNameDTO>> GetTechnologyNameDTOsAsync();
    }
}
