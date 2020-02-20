using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Services.Implementation
{
    public class CountryService : ICountryService
    {
        private IUnitOfWork _uow;

        public CountryService(IUnitOfWork unitOfWork) 
        {
            _uow = unitOfWork;
        }
        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _uow.Countries
                  .GetAllAsync(include: c => c.Include(s => s.Cities));
        }

        public async Task<Country> GetByIdAsync(Guid countryId)
        {
            return await _uow.Countries.GetByIdAsync(countryId);
        }

        public async Task AddAsync(Country country)
        {
            await _uow.Countries.AddAsync(country);
        }

        public async Task UpdateAsync(Country coutnry)
        {
            await _uow.Countries.Update(coutnry);
        }

        public async Task RemoveAsync(Guid id)
        {
            var country = await _uow.Countries.GetByIdAsync(id);
            await _uow.Countries.Remove(country);
        }

        public async Task RemoveAsync(Country country)
        {
            await _uow.Countries.Remove(country);
        }
    }
}
