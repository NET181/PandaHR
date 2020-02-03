using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.Services.Models.Vacancy;

namespace PandaHR.Api.Services.Contracts
{
    public interface IVacancyService
    {
        Task<IEnumerable<VacancySummaryDTO>> GetVacancyPreviewAsync(Guid userId, int? pageSize, int? page);
        Task AddAsync(VacancyServiceModel vacancyServiceModel);
    }
}
