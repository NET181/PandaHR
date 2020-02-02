using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.DTOs.Degree;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class DegreeRepository : EFRepositoryAsync<Degree>, IDegreeRepository
    {
        private readonly ApplicationDbContext _context;

        public DegreeRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }

        public async Task<ICollection<DegreeDTO>> GetDegreeDTOsAsync()
        {
            var dtos = await _context.Degrees.Select(d => new DegreeDTO()
            {
                Id = d.Id,
                Name = d.Name
            }).ToListAsync();

            return dtos;
        }
    }
}
