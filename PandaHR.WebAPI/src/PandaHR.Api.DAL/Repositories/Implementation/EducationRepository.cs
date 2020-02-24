using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL.DTOs.Education;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class EducationRepository : EFRepositoryAsync<Education>, IEducationRepository
    {
        private readonly ApplicationDbContext _context;

        public EducationRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }

        public async Task<ICollection<EducationNameDTO>> GetBasicInfoByAutofillByName(string name)
        {
            IQueryable<EducationNameDTO> query = _context.Educations.AsQueryable()
                .Where(c => Microsoft.EntityFrameworkCore.EF.Functions.Like(c.PlaceName, $"%{name}%"))
                .Select(e => new EducationNameDTO()
                {
                    Id = e.Id,
                    PlaceName = e.PlaceName
                });

            List<EducationNameDTO> educations = await query.ToListAsync();

            return educations;
        }
    }
}
