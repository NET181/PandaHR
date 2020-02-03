using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.City;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICityService : IAsyncService<City>
    {
        Task<ICollection<CityNameServiceModel>> GetCityNamesByTerm(string term);
    }
}
