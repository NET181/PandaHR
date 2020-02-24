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
using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using PandaHR.Api.Services.MatchingAlgorithm.Models;

namespace PandaHR.Api.Services.Implementation
{
    public class VacancyService : IVacancyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ISkillMatchingAlgorithm<Guid> _matchingAlgorithm;


        public VacancyService(IUnitOfWork uow, IMapper mapper, ISkillMatchingAlgorithm<Guid> matchingAlgorithm)
        {
            _uow = uow;
            _mapper = mapper;
            _matchingAlgorithm = matchingAlgorithm;
        }

        public async Task<Vacancy> AddAsync(Vacancy entity)
        {
            var res = await _uow.Vacancies.AddAsync(entity);
            await _uow.SaveChangesAsync();

            return res;
        }

        public async Task RemoveAsync(Guid id)
        {
            var vacancy = await GetByIdAsync(id);
            await RemoveAsync(vacancy);
        }

        public async Task RemoveAsync(Vacancy vacancy)
        {
            _uow.Vacancies.Remove(vacancy);
            await _uow.SaveChangesAsync();
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
                    .ThenInclude(t => t.SkillType)
                .Include(x => x.SkillRequirements)
                    .ThenInclude(e => e.Experience)
                .Include(k => k.SkillRequirements)
                    .ThenInclude(k => k.KnowledgeLevel)
                    .ThenInclude(t => t.SkillKnowledgeTypes)
                .Include(q => q.Qualification));

            return _mapper.Map<Vacancy, VacancyServiceModel>(vacancys);

        }

        public async Task UpdateAsync(Vacancy vacancy)
        {
            _uow.Vacancies.Update(vacancy);
            await _uow.SaveChangesAsync();
        }

        public async Task<VacancyServiceModel> AddAsync(VacancyServiceModel vacancyServiceModel)
        {
            var vacancyDto = _mapper.Map<VacancyServiceModel, VacancyDTO>(vacancyServiceModel);

            var res = _mapper.Map<VacancyDTO, VacancyServiceModel>(
                await _uow.Vacancies.AddAsync(vacancyDto));
            await _uow.SaveChangesAsync();

            return res;
        }

        public async Task<IEnumerable<VacancySummaryDTO>> GetVacancyPreviewAsync(Guid userId, int? page = 1, int? pageSize = 10)
        {
            return await _uow.Vacancies.GetUserVacancySummaryAsync(userId, page, pageSize);
        }

        public async Task<IEnumerable<ISkillSetWithRatingModel<Guid>>> GetVacanciesByCV(Guid cvId, int threshold)
        {
            var vacancies = (await _uow.Vacancies.GetAllAsync(include: s => s
                 .Include(x => x.SkillRequirements)
                     .ThenInclude(s => s.Skill)))
                 .Select(s => new SkillSetModel
                 {
                     Id = s.Id,
                     Skills = s.SkillRequirements.Select(k => k.SkillId)
                 });

            var CV = await _uow.CVs.GetFirstOrDefaultAsync(predicate: s => s
                .Id == cvId,
                include: s => s
                .Include(x => x.SkillKnowledges)
                    .ThenInclude(s => s.Skill));

            var algorithmCV = _mapper.Map<CV, SkillSetModel>(CV);

            return _matchingAlgorithm.GetMatchingModels(algorithmCV, vacancies, threshold, 2);
        }

        public async Task<IEnumerable<VacancySummaryDTO>> GetByCity(Guid cityId, int? page = 1, int? pageSize = 10)
        {
            return await _uow.Vacancies.GetVacanciesFiltered(t => t.VacancyCities.Any(c => c.City.Id == cityId), page, pageSize);
        }

        public async Task<IEnumerable<VacancySummaryDTO>> GetByCompany(Guid companyId, int? page = 1, int? pageSize = 10)
        {
            return await _uow.Vacancies.GetVacanciesFiltered(t => t.CompanyId == companyId, page, pageSize);
        }
    }
}
