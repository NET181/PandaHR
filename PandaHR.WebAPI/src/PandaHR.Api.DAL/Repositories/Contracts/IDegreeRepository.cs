using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.DTOs.Degree;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IDegreeRepository : IAsyncRepository<Degree>
    {
        Task<ICollection<DegreeDTO>> GetDegreeDTOsAsync();
    }
}
