using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface IVacancyService
    {
        Task<IEnumerable<Vacancy>> GetAllAsync();
        Task<Vacancy> GetByIdAsync(Guid id);
        Task AddAsync(Vacancy skillRequirement);
        Task UpdateAsync(Vacancy skillRequirement);
        Task RemoveAsync(Guid id);
    }
}
