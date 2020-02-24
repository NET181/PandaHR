using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IVacancyRepository : IAsyncRepository<Vacancy>
    {
        Task<IEnumerable<VacancySummaryDTO>> GetUserVacancySummaryAsync(Guid userId, int? pageSize = 10, int? page = 1);
        Task AddAsync(VacancyDTO vacancyDto);
        Task UpdateAsync(VacancyDTO dto);
        Task RemoveAsync(Guid id);
        Task<ICollection<Vacancy>> GetAllDTOsAsync();
    }
}
