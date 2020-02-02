using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Services.Models.Degree;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.Services.Contracts
{
    public interface IDegreeService : IAsyncService<Degree>
    {
        Task<ICollection<DegreeServiceModel>> GetDegreesAsync();
    }
}
