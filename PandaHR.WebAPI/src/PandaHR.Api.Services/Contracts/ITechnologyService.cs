using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Services.Models.Technology;

namespace PandaHR.Api.Services.Contracts
{
    public interface ITechnologyService
    {
        Task<ICollection<TechnologyNameServiceModel>> GetTechnologyNamesAsync();
    }
}
