using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.Models.JobExperience;
using PandaHR.Api.Services.Models.SkillKnowledge;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICVService : IAsyncService<CVServiceModel>
    {
        Task<IEnumerable<CVSummaryDTO>> GetUserCVsPreviewAsync(Guid userId, int? pageSize, int? page);
        Task<IEnumerable<CVforSearchDTO>> GetUserCVsAsync(Guid userId, int? pageSize = 10, int? page = 1);
        Task<IEnumerable<VacancySummaryDTO>> GetVacanciesForCV(Guid CVId, int? pageSize = 10, int? page = 1);
        Task AddSkillKnowledgeToCVAsync(SkillKnowledgeServiceModel model, Guid CVId);
        Task DeleteSkillKnowledgeFromCVAsync(Guid skillKnowledgeId);
        Task AddJobExperienceToCVAsync(JobExperienceServiceModel model, Guid CVId);
        Task DeleteJobExperienceFromCVAsync(Guid jobExperienceId);
        Task AddAsync(CVCreationServiceModel cvServiceModel);
        Task UpdateAsync(CVCreationServiceModel model);
    }
}
