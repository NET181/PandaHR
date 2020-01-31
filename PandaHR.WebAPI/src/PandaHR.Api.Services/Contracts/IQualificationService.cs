using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Services.Models.Qualification;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.Services.Contracts
{
    public interface IQualificationService : IAsyncService<Qualification>
    {
        Task<IEnumerable<QualificationServiceModel>> GetAllQualificationsAsync();
    }
}
