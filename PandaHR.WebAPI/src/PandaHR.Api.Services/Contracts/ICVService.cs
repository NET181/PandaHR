using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.Models.SkillKnowledge;
using PandaHR.Api.Services.Models.JobExperience;
using PandaHR.Api.Services.Exporter.Models.ExportTypes;
using PandaHR.Api.Services.MatchingAlgorithm.Contracts;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICVService : IAsyncService<CVServiceModel>
    {
        Task<CVSummaryDTO> GetUserCVPreviewAsync(Guid userId);
        Task<CVforSearchDTO> GetUserCVAsync(Guid userId);
        Task<IEnumerable<VacancySummaryDTO>> GetVacanciesForCV(Guid CVId, int? page = 1, int? pageSize = 10);
        Task<IEnumerable<ISkillSetWithRatingModel<Guid>>> GetCVsByVacancy(Guid vacancyId, int threshold);
        Task<CustomFile> ExportCVAsync(Guid id, string webRootPath, string fileExtension);
        Task AddSkillKnowledgeToCVAsync(SkillKnowledgeServiceModel model, Guid CVId);
        Task DeleteSkillKnowledgeFromCVAsync(Guid skillKnowledgeId);
        Task AddJobExperienceToCVAsync(JobExperienceServiceModel model, Guid CVId);
        Task DeleteJobExperienceFromCVAsync(Guid jobExperienceId);
        Task<CVServiceModel> AddAsync(CVCreationServiceModel cvServiceModel);
        Task UpdateAsync(CVCreationServiceModel model);
    }
}
