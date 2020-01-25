using System;
using System.Collections.Generic;
using PandaHR.Api.DAL.Models.Entities;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllAsync();
        Task<Country> GetById(Guid countryId);
    }
}
