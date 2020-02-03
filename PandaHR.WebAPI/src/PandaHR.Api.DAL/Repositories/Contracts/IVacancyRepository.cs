using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.DAL.Models.Entities;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IVacancyRepository : IAsyncRepository<Vacancy>
    {
        Task AddAsync(VacancyDTO vacancyDto);
    }
}
