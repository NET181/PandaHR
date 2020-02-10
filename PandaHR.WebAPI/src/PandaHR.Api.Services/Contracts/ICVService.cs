using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Exporter.Models;
using PandaHR.Api.Services.Exporter.Models.ExportTypes;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICVService : IAsyncService<CVServiceModel>
    {
        Task<IEnumerable<CVSummaryDTO>> GetUserCVsPreviewAsync(Guid userId, int? pageSize, int? page);
        Task<IEnumerable<CVforSearchDTO>> GetUserCVsAsync(Guid userId, int? pageSize = 10, int? page = 1);
        Task<IEnumerable<VacancySummaryDTO>> GetVacanciesForCV(Guid CVId, int? pageSize = 10, int? page = 1);
        Task<IEnumerable<CV>> GetBySkillSet(IEnumerable<Skill> skills, double threshold);
        Task AddAsync(CVCreationServiceModel cvServiceModel);
        CustomFile ExportToDocx(string templatePath);
    }
}
