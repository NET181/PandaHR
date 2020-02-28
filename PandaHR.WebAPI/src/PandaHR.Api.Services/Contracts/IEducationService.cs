using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.Education;

namespace PandaHR.Api.Services.Contracts
{
    public interface IEducationService : IAsyncService<Education>
    {
        Task<ICollection<EducationBasicInfoServiceModel>> GetBasicInfoByAutofillByName(string name);
    }
}
