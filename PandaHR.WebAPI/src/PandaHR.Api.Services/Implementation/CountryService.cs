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

        public async Task<Country> AddAsync(Country country)
        {
            var result = await _uow.Countries.AddAsync(country);
            await _uow.Countries.SaveAsync();

            return result;
        }

        public async Task UpdateAsync(Country coutnry)
        {
            _uow.Countries.Update(coutnry);
            await _uow.Countries.SaveAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var country = await _uow.Countries.GetByIdAsync(id);
            await RemoveAsync(country);
        }

        public async Task RemoveAsync(Country country)
        {
            _uow.Countries.Remove(country);
            await _uow.Countries.SaveAsync();
        }
    }
}
