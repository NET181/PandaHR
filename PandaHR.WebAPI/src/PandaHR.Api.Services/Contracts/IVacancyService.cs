using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface IVacancyService : IAsyncService<Vacancy>
    {
        Task<Vacancy> GetByIdWithSkillAsync(Guid id);
    }
}
