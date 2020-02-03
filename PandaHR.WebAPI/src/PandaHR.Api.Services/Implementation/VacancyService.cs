using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class VacancyService : IVacancyService
    {
        private readonly IUnitOfWork _uow;

        public VacancyService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddAsync(Vacancy entity)
        {
            await _uow.Vacancies.Add(entity);
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

        public async Task UpdateAsync(Vacancy vacancy)
        {
            await _uow.Vacancies.Update(vacancy);
        }

        public async Task<IEnumerable<VacancySummaryDTO>> GetVacancyPreviewAsync(Guid userId, int? pageSize, int? page)
        {
            return await _uow.Vacancies.GetUserVacancySummaryAsync(userId, pageSize, page);
        }
    }
}
