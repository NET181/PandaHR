using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Services.Exporter;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.Services.Exporter.Models;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.SkillMatchingAlgorithm;
using PandaHR.Api.Services.SkillMatchingAlgorithm.Contracts;
using PandaHR.Api.Services.Models.Skill;

namespace PandaHR.Api.Services.Implementation
{
    public class CVService : ICVService, IAsyncService<CVServiceModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IMatchingCVsForSkillSetAlgorithm _skillSetAlgorithm;

        public CVService(IMapper mapper, IUnitOfWork uow, IMatchingCVsForSkillSetAlgorithm skillSetAlgorithm)
        {
            _mapper = mapper;
            _uow = uow;
            _skillSetAlgorithm = skillSetAlgorithm;
        }

        public async Task<IEnumerable<CV>> GetBySkillSet(IEnumerable<Skill> skills, double threshold)
        {
            var cvs = await _uow.CVs.GetAllAsync(include: s => s
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
                .ThenInclude(e => e.Experience));

            return await _skillSetAlgorithm.GetMatchingBySkillsObjects(cvs, skills, threshold);
        }

        public async Task AddAsync(CVCreationServiceModel cvServiceModel)
        {
            CVDTO cv = _mapper.Map<CVCreationServiceModel, CVDTO>(cvServiceModel);

            await _uow.CVs.AddAsync(cv);
        }

        public CustomFile ExportToDocx(string templatePath)
        {
            return ExportingTool.ToDocx(templatePath);
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

        public async Task<CV> GetByIdAsync(Guid id)
        {
            return await _uow.CVs.GetByIdAsync(id);
        }

        public async Task<IEnumerable<CVSummaryDTO>> GetUserCVsPreviewAsync(Guid userId, int? pageSize = 10, int? page = 1)
        {
            return await _uow.CVs.GetUserCVSummaryAsync(userId, pageSize, page);
        }

        public async Task<IEnumerable<CVforSearchDTO>> GetUserCVsAsync(Guid userId, int? pageSize = 10, int? page = 1)
        {
            return await _uow.CVs.GetCVsAsync(cv => cv.UserId == userId, pageSize, page);
        }

        public async Task RemoveAsync(Guid id)
        {
            var CV = await GetByIdAsync(id);
            await RemoveAsync(CV);
        }

        public async Task RemoveAsync(CV entity)
        {
            await _uow.CVs.Remove(entity);
        }

        public Task RemoveAsync(CVServiceModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(CV entity)
        {
            await _uow.CVs.Update(entity);
        }

        public async Task<IEnumerable<VacancySummaryDTO>> GetVacanciesForCV(Guid CVId, int? pageSize = 10, int? page = 1)
        {
            CVforSearchDTO cv = (await _uow.CVs.GetCVsAsync(cv => cv.Id == CVId, pageSize, page)).FirstOrDefault();
            var result = (await _uow.Vacancies.GetAllAsync()).Where(v => MatchVacancyCV.Matches(v, cv) > 0);

            return _mapper.Map<IEnumerable<Vacancy>, IEnumerable<VacancySummaryDTO>>(result);
        }

        public async Task AddAsync(CV entity)
        {
            await _uow.CVs.Add(entity);
        }

        Task<CVServiceModel> IAsyncService<CVServiceModel>.GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(CVServiceModel entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CVServiceModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
