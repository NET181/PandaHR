using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
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

        public async Task<City> GetById(Guid cityId, Func<IQueryable<City>, IIncludableQueryable<City, object>> include = null)
        {
            return await _uow.Cities.
                GetByIdAsync(cityId);
        }

        public async Task Add(City city)
        {
            await _uow.Cities.Add(city);
        }

        public async Task<bool> Update(City city)
        {
            await _uow.Cities.Update(city);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            var city = await _uow.Cities.GetByIdAsync(id);
            await _uow.Cities.Remove(city);
            return true;
        }
    }
}
