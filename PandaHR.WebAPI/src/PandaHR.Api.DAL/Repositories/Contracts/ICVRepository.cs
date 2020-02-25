using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;
using PandaHR.Api.DAL.DTOs.JobExperience;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface ICVRepository : IAsyncRepository<CV>
    {
        Task<CVSummaryDTO> GetUserCVSummaryAsync(Guid userId);
        Task<IEnumerable<CVforSearchDTO>> GetCVsAsync(Expression<Func<CV, bool>> predicate, int? page = 1, int? pageSize = 10);
        Task AddSkillKnowledgeIntoCVAsync(SkillKnowledgeDTO model, Guid CVId);
        Task DeleteSkillKnowledgeFromCVAsync(Guid skillId, Guid CVId);
        Task AddJobExperienceIntoCVAsync(JobExperienceDTO model, Guid CVId);
        Task<CVDTO> AddAsync(CVCreationDTO cv);
        Task UpdateAsync(CVCreationDTO cv);
        Task LinkUserToCV(CV cv, User user);
        Task LinkUserToCV(Guid cvId, Guid userId);
        Task<CVExportDTO> GetCvForExportAsync(Guid cvId); 
        bool CvExists(Guid cvId);
        Task DeleteJobExperienceFromCVAsync(Guid JobExperienceId, Guid CVId);
    }
}