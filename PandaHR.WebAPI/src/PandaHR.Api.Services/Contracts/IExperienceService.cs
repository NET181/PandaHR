using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Services.Models.Experience;

namespace PandaHR.Api.Services.Contracts
{
    public interface IExperienceService
    {
        Task<IEnumerable<ExperienceServiceModel>> GetAllAsync();
    }
}
