using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IVacancyRepository : IAsyncRepository<Vacancy>
    {
        Task<IEnumerable<VacancySummaryDTO>> GetUserVacancySummaryAsync(Guid userId, int? page = 1, int? pageSize = 10);
        Task<VacancyDTO> AddAsync(VacancyDTO vacancyDto);
        Task<IEnumerable<VacancySummaryDTO>> GetVacanciesFiltered(Expression<Func<Vacancy, bool>> predicate, int? page = 1, int? pageSize = 10);
    }
}
