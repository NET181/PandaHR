using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL.DTOs.City;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class CityRepository : EFRepositoryAsync<City>, ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<CityNameDTO>> GetCityNameDTOsAsync(Expression<Func<City, bool>> predicate = null,
                                                                          int maxCountToTake = -1)
        {
            IQueryable<City> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (maxCountToTake > 0)
            {
                query = query.Take(maxCountToTake);
            }

            var dtos = await query.Select(s => new CityNameDTO()
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();

            return dtos;
        }
    }
}
