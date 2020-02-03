using PandaHR.Api.DAL.DTOs.City;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface ICityRepository : IAsyncRepository<City>
    {
        Task<ICollection<CityNameDTO>> GetCityNameDTOsAsync(Expression<Func<City, bool>> predicate = null,
                                                             int maxCountToTake = -1);
    }
}
