using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models;
using PandaHR.Api.Services.Models.CV;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.DTOs.Vacancy;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICVService
    {
        Task<IEnumerable<CVSummaryDTO>> GetUserCVsPreviewAsync(Guid userId, int? pageSize, int? page);
        Task<IEnumerable<CVforSearchDTO>> GetUserCVsAsync(Guid userId, int? pageSize = 10, int? page = 1);
        Task<IEnumerable<VacancySummaryDTO>> GetVacanciesForCV(Guid CVId, int? pageSize = 10, int? page = 1);
        Task AddAsync(CVCreationServiceModel cvServiceModel);
    }
}
