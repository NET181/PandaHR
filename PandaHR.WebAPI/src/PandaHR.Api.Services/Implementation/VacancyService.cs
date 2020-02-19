using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Vacancy;
using PandaHR.Api.Services.SkillMatchingAlgorithm.Contracts;

namespace PandaHR.Api.Services.Implementation
{
    public class VacancyService : IVacancyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IMatchingVacanciesForSkillSetAlgorithm _skillSetAlgorithm;


        public VacancyService(IUnitOfWork uow, IMapper mapper, IMatchingVacanciesForSkillSetAlgorithm skillSetAlgorithm)
        {
            _uow = uow;
            _mapper = mapper;
            _skillSetAlgorithm = skillSetAlgorithm;
        }

        public async Task AddAsync(Vacancy entity)
        {
            await _uow.Vacancies.AddAsync(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var vacancy = await GetByIdAsync(id);
            await RemoveAsync(vacancy);
        }

        public async Task RemoveAsync(Vacancy vacancy)
        {
            await _uow.Vacancies.Remove(vacancy);
        }

        public async Task<IEnumerable<Vacancy>> GetAllAsync()
        {
            return await _uow.Vacancies.GetAllAsync();
        }

        public async Task<Vacancy> GetByIdAsync(Guid id)
        {
            return await _uow.Vacancies.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<VacancyServiceModel> GetByIdWithSkillAsync(Guid id)
        {
            var vacancys = await _uow.Vacancies.GetFirstOrDefaultAsync(d => d.Id == id
                , include: i => i
                .Include(x => x.SkillRequirements)
                    .ThenInclude(s => s.Skill)
                    .ThenInclude(t => t.SkillType)
                .Include(x => x.SkillRequirements)
                    .ThenInclude(s => s.Skill)
                    .ThenInclude(s => s.SubSkills)
                .Include(x => x.SkillRequirements)
                    .ThenInclude(e => e.Experience)
                .Include(k => k.SkillRequirements)
                    .ThenInclude(k => k.KnowledgeLevel)
                    .ThenInclude(t => t.SkillKnowledgeTypes)
                .Include(q => q.Qualification));

            return _mapper.Map<Vacancy,VacancyServiceModel>(vacancys);
        }

        public async Task UpdateAsync(Vacancy vacancy)
        {
            await _uow.Vacancies.Update(vacancy);
        }

        public async Task AddAsync(VacancyServiceModel vacancyServiceModel)
        {
            var vacancyDto = _mapper.Map<VacancyServiceModel, VacancyDTO>(vacancyServiceModel);

            await _uow.Vacancies.AddAsync(vacancyDto);
        }

        public async Task<IEnumerable<VacancySummaryDTO>> GetVacancyPreviewAsync(Guid userId, int? pageSize, int? page)
        {
            return await _uow.Vacancies.GetUserVacancySummaryAsync(userId, pageSize, page);
        }

        public async Task<IEnumerable<Vacancy>> GetBySkillSet(IEnumerable<Skill> skills, double threshold)
        {
            var vacancies = await _uow.Vacancies.GetAllAsync( 
                include: i => i
            .Include(x => x.SkillRequirements)
                .ThenInclude(s => s.Skill)
                .ThenInclude(t => t.SkillType)
            .Include(x => x.SkillRequirements)
                .ThenInclude(s => s.Skill)
                .ThenInclude(s => s.SubSkills)
             .Include(x => x.SkillRequirements)
                .ThenInclude(e => e.Experience)
             .Include(k => k.SkillRequirements)
                .ThenInclude(k => k.KnowledgeLevel)
                .ThenInclude(t => t.SkillKnowledgeTypes)
            .Include(q => q.Qualification));

            return await _skillSetAlgorithm.GetMatchingBySkillsObjects(vacancies, skills, threshold);
        }

        public async Task<IEnumerable<VacancySummaryDTO>> GetByCity(Guid cityId, int? pageSize, int? page)
        {
            return await _uow.Vacancies.GetVacanciesFiltered(t => t.VacancyCities.Any(c => c.City.Id == cityId), pageSize, page);
        }

        public async Task<IEnumerable<VacancySummaryDTO>> GetByCompany(Guid companyId, int? pageSize, int? page)
        {
            return await _uow.Vacancies.GetVacanciesFiltered(t => t.CompanyId == companyId, pageSize, page);
        }
    }
}
