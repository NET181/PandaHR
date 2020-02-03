using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.Vacancy;
using System;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface IVacancyService : IAsyncService<Vacancy>
    {
        Task<VacancyServiceModel> GetByIdWithSkillAsync(Guid id);
    }
}
