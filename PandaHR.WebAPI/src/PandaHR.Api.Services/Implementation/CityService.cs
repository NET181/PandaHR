using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class CityService : ICityService
    {
        private IUnitOfWork _uow;

        public CityService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _uow.Cities.GetAllAsync();
        }
    }
}
