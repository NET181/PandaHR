using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL.DTOs.Technology;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class TechnologyRepository : EFRepositoryAsync<Technology>, ITechnologyRepository
    {
        private readonly ApplicationDbContext _context;

        public TechnologyRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }

        public async Task<ICollection<TechnologyNameDTO>> GetTechnologyNameDTOsAsync()
        {
            var dtos = await _context.Technologies.Select(t => new TechnologyNameDTO()
            {
                Id = t.Id,
                Name = t.Name
            }).ToListAsync();

            return dtos;
        }


    }
}
