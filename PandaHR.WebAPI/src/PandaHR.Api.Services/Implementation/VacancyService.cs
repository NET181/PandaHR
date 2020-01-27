using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task AddAsync(Vacancy Vacancy)
        {
            await _uow.Vacancies.Add(Vacancy);
        }

        public async Task<IEnumerable<Vacancy>> GetAllAsync()
        {
            return await _uow.Vacancies.GetAllAsync();
        }

        public async Task<Vacancy> GetByIdAsync(Guid id)
        {
            return (await _uow.Vacancies.GetWhere(s => s.Id == id)).FirstOrDefault();
        }

        public async Task RemoveAsync(Guid id)
        {
            var vacancy = (await _uow.Vacancies.GetWhere(s => s.Id == id)).FirstOrDefault();
            if (vacancy != null)
            {
                await _uow.Vacancies.Remove(vacancy);
            }
        }

        public async Task UpdateAsync(Vacancy vacancy)
        {
            if (vacancy != null)
            {
                await _uow.Vacancies.Update(vacancy);
            }
        }

        /*public async Task<IEnumerable<Vacancy>> GetAllAsync()
        {
            var vacancies = await _uow.Vacancies
                .GetAllAsync(include: v => v
                    .Include(s => s.Company)
                    .Include(s => s.Qualification)
                    .Include(s => s.Vacancys)
                    .Include(s => s.User));

            return vacancies;
        }*/
    }
}
