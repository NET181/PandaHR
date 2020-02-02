using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Services.Models.Technology;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.Services.Contracts
{
    public interface ITechnologyService
    {
        Task<ICollection<TechnologyNameServiceModel>> GetTechnologyNamesAsync();
    }
}
