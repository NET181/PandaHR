using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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
                  .GetAllAsync(include: c => c
                      .Include(s => s.Cities));  
        }

        public async Task<Country> GetById(Guid countryId)
        {
            return await _uow.Countries.
                GetByIdAsync(countryId,
                include: c => c.Include(s => s.Cities));
        }


    }
}
