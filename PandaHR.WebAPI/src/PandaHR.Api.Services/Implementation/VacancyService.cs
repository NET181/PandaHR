using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Vacancy>> GetAllAsync()
        {
            var vacancies = await _uow.Vacancies
                .GetAllAsync(include: v => v
                    .Include(s => s.Company)
                    .Include(s => s.Qualification)
                    .Include(s => s.SkillRequirements)
                    .Include(s => s.User));

            return vacancies;
        }
    }
}
