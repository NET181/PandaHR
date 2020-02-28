using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using PandaHR.Api.DAL.DTOs.City;
using System.Linq.Expressions;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class VacancyRepository : EFRepositoryAsync<Vacancy>, IVacancyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VacancyRepository(ApplicationDbContext context, IMapper mapper) :
            base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VacancySummaryDTO>> GetUserVacancySummaryAsync(Guid userId, int? pageSize = 10, int? page = 1)
        {
            IEnumerable<Vacancy> query = await _context.Vacancies.Where(cv => cv.UserId == userId)
                .Include(c => c.Qualification)
                .Include(c => c.Technology)
                .Include(c=>c.Company)
                .ToListAsync();

            if (pageSize != null && page != null)
            {
                query = query.Skip((int)pageSize * ((int)page - 1)).Take((int)pageSize);
            }

            return _mapper.Map<IEnumerable<Vacancy>, IEnumerable<VacancySummaryDTO>>(query);
        }

        public async Task<VacancyDTO> AddAsync(VacancyDTO vacancyDto)
        {
            var vacancy = _mapper.Map<VacancyDTO, Vacancy>(vacancyDto);
                        
            await _context.Vacancies.AddAsync(vacancy);
            await _context.SaveChangesAsync();

            return vacancyDto;
        }

        public async Task<Vacancy> GetByIdWithSkillRequestAsync(Guid Id)
        {
            return await _context.Set<Vacancy>().FindAsync(Id);
        }

        public async Task<IEnumerable<VacancySummaryDTO>> GetVacanciesFiltered(Expression<Func<Vacancy, bool>> predicate, int? page = 1, int? pageSize = 10)
        {
            IQueryable<VacancySummaryDTO> query = _context.Vacancies.AsQueryable()
                .Include(c => c.Qualification)
                .Include(c => c.Technology)
                .Include(c => c.Company)
                .Include(c => c.VacancyCities)
                    .ThenInclude(ct => ct.City)
                .Where(predicate)
                .Select(u => new VacancySummaryDTO()
                 {
                     Id = u.Id,
                     CompanyName = u.Company.Name,
                     Description = u.Description,
                     QualificationName = u.Qualification.Name,
                     TechnologyName = u.Technology.Name,
                     CityNames = (from s in u.VacancyCities
                                  select new CityNameDTO()
                                  {
                                     Id = s.CityId,
                                     Name = s.City.Name
                                  })
                 });

            if (pageSize != null && page != null)
            {
                query = query.Skip((int)pageSize * ((int)page - 1)).Take((int)pageSize);
            }

            return await query.ToListAsync();  
        }

        public async Task UpdateAsync(VacancyDTO dto)
        {
            var entity = _mapper.Map<VacancyDTO, Vacancy>(dto);
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var vacancy = await _context.Vacancies.FindAsync(id);
            _context.Vacancies.Remove(vacancy);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Vacancy>> GetAllDTOsAsync()
        {
            ICollection<Vacancy> vacancies = await _context.Vacancies.ToListAsync();

            return vacancies;
        }
    }
}

        

