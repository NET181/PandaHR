using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.Services.Models.Vacancy;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.Services.Contracts
{
    public interface IVacancyService
    {
        Task<IEnumerable<VacancySummaryDTO>> GetVacancyPreviewAsync(Guid userId, int? page = 1, int? pageSize = 10);
        Task<VacancyServiceModel> AddAsync(VacancyServiceModel vacancyServiceModel);
        Task<VacancyServiceModel> GetByIdWithSkillAsync(Guid id);
        Task<IEnumerable<VacancySummaryDTO>> GetByCity(Guid cityId, int? page = 1, int? pageSize = 10);
        Task<IEnumerable<VacancySummaryDTO>> GetByCompany(Guid companyId, int? page = 1, int? pageSize = 10);
        Task<IEnumerable<Vacancy>> GetBySkillSet(IEnumerable<Skill> skills, double threshold);

    }
}
