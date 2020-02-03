using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.Education;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface IEducationService : IAsyncService<Education>
    {
        Task<ICollection<EducationBasicInfoServiceModel>> GetBasicInfoByAutofillByName(string name);
    }
}
