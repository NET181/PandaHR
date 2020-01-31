using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL.DTOs.Skill;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class SkillRepository : EFRepositoryAsync<Skill>, ISkillRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }

        public async Task<ICollection<SkillNameDTO>> GetSkillNameDTOsAsync()
        {
            var dtos = await _context.Skills.Select(s => new SkillNameDTO()
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();

            return dtos;
        }
    }
}
