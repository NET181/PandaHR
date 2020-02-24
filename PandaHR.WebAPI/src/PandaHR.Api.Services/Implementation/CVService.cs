using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Services.Exporter;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.DTOs.Education;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.DAL.DTOs.User;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;
using PandaHR.Api.DAL.DTOs.JobExperience;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Education;
using PandaHR.Api.Services.Models.User;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.Models.SkillKnowledge;
using PandaHR.Api.Services.Models.JobExperience;
using PandaHR.Api.Services.Exporter.Models.Enums;
using PandaHR.Api.Services.Exporter.Models.ExportTypes;
using PandaHR.Api.Services.Exporter.Models.ExportModels;
using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using PandaHR.Api.Services.MatchingAlgorithm.Models;
using PandaHR.Api.Common.Exceptions;

namespace PandaHR.Api.Services.Implementation
{
    public class CVService : ICVService, IAsyncService<CVServiceModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly ISkillMatchingAlgorithm<Guid> _matchingAlgorithm;

        public CVService(IMapper mapper, IUnitOfWork uow, ISkillMatchingAlgorithm<Guid> matchingAlgorithm)
        {
            _mapper = mapper;
            _uow = uow;
            _matchingAlgorithm = matchingAlgorithm;
        }

        public async Task<IEnumerable<ISkillSetWithRatingModel<Guid>>> GetCVsByVacancy(Guid vacancyId, int threshold)
        {
            var CVs = (await _uow.CVs.GetAllAsync(include: s => s
                 .Include(x => x.SkillKnowledges)
                     .ThenInclude(s => s.Skill)))
                 .Select(s => new SkillSetModel
                 {
                     Id = s.Id,
                     Skills = s.SkillKnowledges.Select(k => k.SkillId)
                 });

            var vacancy = await _uow.Vacancies.GetFirstOrDefaultAsync(predicate: s => s
                .Id == vacancyId,
                include: s => s
                .Include(x => x.SkillRequirements)
                    .ThenInclude(s => s.Skill));

            var algorithmVacancy = _mapper.Map<Vacancy, SkillSetModel>(vacancy);

            return _matchingAlgorithm.GetMatchingModels(algorithmVacancy, CVs, threshold, 2);
        }

        public async Task<CVServiceModel> AddAsync(CVCreationServiceModel cvServiceModel)
        {
            Guid? userId = cvServiceModel.UserId;
            var educationsToAdd =
                _mapper.Map<
                    ICollection<EducationWithDetailsServiceModel>,
                    ICollection<EducationWithDetailsDTO>>
                (cvServiceModel.Educations);


            if (userId == null)
            {
                UserFullInfoDTO userToAdd =
                    _mapper.Map<
                        UserCreationServiceModel,
                        UserFullInfoDTO>
                    (cvServiceModel.User);
                userToAdd.Educations = educationsToAdd;

                var createdUser = await _uow.Users.AddAsync(userToAdd);
                userId = createdUser.Id;
                cvServiceModel.UserId = userId;
            }
            else // check if user has educations
            {
                var addedEducations = await _uow.Users.AddEducationsNoExistAsync(educationsToAdd, (Guid)userId);
                educationsToAdd = _mapper.Map<ICollection<Education>, ICollection<EducationWithDetailsDTO>>(addedEducations);
            }
            
            CVCreationDTO cv = _mapper.Map<CVCreationServiceModel, CVCreationDTO>(cvServiceModel);
            CVDTO createdCV = await _uow.CVs.AddAsync(cv);
            createdCV.Educations = educationsToAdd;
            await _uow.CVs.LinkUserToCV(createdCV.Id, (Guid)userId);

            CVServiceModel result = _mapper.Map<CVDTO, CVServiceModel>(createdCV);
           
            return result;
        }

        public async Task<CustomFile> ExportCVAsync(Guid id, string webRootPath, string fileExtension)
        {
            if (!Enum.TryParse(fileExtension, true, out ExportType exportType))
            {
                throw new FormatException("This export mode is not supported");
            }
            if(!_uow.CVs.CvExists(id))
            {
                throw new EntityNotFoundException("No CV found with this id");
            }

            var templatePath = String.Format("{0}/export/CV_ExportTemplate.{1}", webRootPath, exportType);
            var cvDto = await _uow.CVs.GetCvForExportAsync(id);
            var cvExportModel = _mapper.Map<CVExportDTO, CVExportModel>(cvDto);
            ExportingTool exportingTool = new ExportingTool(cvExportModel.FullName, exportType);

            return exportingTool.ExportCV(templatePath, cvExportModel);
        }

        public async Task<IEnumerable<CVServiceModel>> GetAllAsync()
        {
            var CVs = new List<CV>
                (await _uow.CVs.GetAllAsync(include: s => s
                .Include(x => x.SkillKnowledges)
                    .ThenInclude(s => s.Skill)
                    .ThenInclude(s => s.SubSkills)
                .Include(x => x.SkillKnowledges)
                    .ThenInclude(s => s.Skill)
                    .ThenInclude(s => s.SkillType)
                .Include(q => q.Qualification)
                .Include(x => x.SkillKnowledges)
                    .ThenInclude(k => k.KnowledgeLevel)
                    .ThenInclude(t => t.SkillKnowledgeTypes)
                .Include(e => e.SkillKnowledges)
                .ThenInclude(e => e.Experience)));

            return new List<CVServiceModel>(_mapper.Map<IEnumerable<CV>, IEnumerable<CVServiceModel>>(CVs));
        }

        public async Task<CVSummaryDTO> GetUserCVPreviewAsync(Guid userId)
        {
            return await _uow.CVs.GetUserCVSummaryAsync(userId);
        }

        public async Task<CVforSearchDTO> GetUserCVAsync(Guid userId)
        {
            return (await _uow.CVs.GetCVsAsync(cv => cv.UserId == userId)).FirstOrDefault();
        }

        public async Task RemoveAsync(Guid id)
        {
            var CV = await GetByIdAsync(id);
            await RemoveAsync(CV);
        }

        public async Task RemoveAsync(CVServiceModel entity)
        {
            var toDel = _mapper.Map<CVServiceModel, CV>(entity);
            _uow.CVs.Remove(toDel);
            await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(CVCreationServiceModel model)
        {
            var cvDTO = _mapper.Map<CVCreationServiceModel, CVCreationDTO>(model);

            await _uow.CVs.UpdateAsync(cvDTO); // saves CV inside this call
        }

        public async Task<IEnumerable<VacancySummaryDTO>> GetVacanciesForCV(Guid CVId, int? page = 1, int? pageSize = 10)
        {
            CVforSearchDTO cv = (await _uow.CVs.GetCVsAsync(cv => cv.Id == CVId, pageSize, page)).FirstOrDefault();
            var result = (await _uow.Vacancies.GetAllAsync()).Where(v => MatchVacancyCV.Matches(v, cv) > 0);

            return _mapper.Map<IEnumerable<Vacancy>, IEnumerable<VacancySummaryDTO>>(result);
        }

        public async Task<CV> AddAsync(CV entity)
        {
            var res = await _uow.CVs.AddAsync(entity);
            await _uow.SaveChangesAsync();

            return res;
        }

        public async Task<CVServiceModel> AddAsync(CVServiceModel entity)
        {
            var res = await AddAsync(_mapper.Map<CVServiceModel, CV>(entity));

            return _mapper.Map<CV, CVServiceModel>(res);
        }

        public async Task<CVServiceModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<CV, CVServiceModel>(await _uow.CVs.GetByIdAsync(id));
        }

        public async Task UpdateAsync(CVServiceModel entity)
        {
            await UpdateAsync(_mapper.Map<CVServiceModel, CVCreationServiceModel>(entity));
        }

        public async Task AddSkillKnowledgeToCVAsync(SkillKnowledgeServiceModel model, Guid CVId)
        {
            var skillKnowledgeDALModel = _mapper.Map<SkillKnowledgeServiceModel, SkillKnowledgeDTO>(model);
            await _uow.CVs.AddSkillKnowledgeIntoCVAsync(skillKnowledgeDALModel, CVId);
        }

        public async Task DeleteSkillKnowledgeFromCVAsync(Guid skillKnowledgeId)
        {
            await _uow.CVs.DeleteSkillKnowledgeFromCVAsync(skillKnowledgeId);
        }

        public async Task AddJobExperienceToCVAsync(JobExperienceServiceModel model, Guid CVId)
        {
            var jobExperienceDALModel = _mapper.Map<JobExperienceServiceModel, JobExperienceDTO>(model);
            await _uow.CVs.AddJobExperienceIntoCVAsync(jobExperienceDALModel, CVId);
        }

        public async Task DeleteJobExperienceFromCVAsync(Guid jobExperienceId)
        {
            await _uow.CVs.DeleteJobExperienceFromCVAsync(jobExperienceId);
        }
    }
}
