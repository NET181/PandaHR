using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.DTOs.Qualification;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IQualificationRepository : IAsyncRepository<Qualification>
    {
        Task<ICollection<QualificationDTO>> GetQualificationDTOsAsync();
    }
}
