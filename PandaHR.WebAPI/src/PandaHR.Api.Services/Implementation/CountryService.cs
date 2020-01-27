using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

        public async Task<Country> GetById(Guid countryId, Func<IQueryable<Country>, IIncludableQueryable<Country, object>> include = null)
        {
            return await _uow.Countries.
                GetByIdAsync(countryId, c => c.Include(s => s.Cities));
        }

        public async Task Add(Country country)
        {
            await _uow.Countries.Add(country);
        }

        public async Task<bool> Update(Country coutnry)
        {
            await _uow.Countries.Update(coutnry);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            var country = await _uow.Countries.GetByIdAsync(id);
            await _uow.Countries.Remove(country);
            return true;
        }
    }
}
