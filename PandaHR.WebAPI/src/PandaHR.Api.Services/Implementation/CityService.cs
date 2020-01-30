using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.DAL;

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

        public async Task<City> GetByIdAsync(Guid cityId)
        {
            return await _uow.Cities.
                GetByIdAsync(cityId);
        }

        public async Task AddAsync(City city)
        {
            await _uow.Cities.Add(city);
        }

        public async Task UpdateAsync(City city)
        {
            await _uow.Cities.Update(city);
        }

        public async Task RemoveAsync(Guid id)
        {
            var city = await _uow.Cities.GetByIdAsync(id);
            await _uow.Cities.Remove(city);
        }

        public async Task RemoveAsync(City city)
        {
            await _uow.Cities.Remove(city);
        }
    }
}
