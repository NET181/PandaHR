using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL.DTOs.Skill;
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
    public class SkillRepository : EFRepositoryAsync<Skill>, ISkillRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }

        public async Task<ICollection<SkillNameDTO>> GetSkillNameDTOsAsync(Expression<Func<Skill, bool>> predicate = null,
                                                                            int maxCountToTake = -1)
        {
            IQueryable<Skill> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if(maxCountToTake > 0)
            {
                query = query.Take(maxCountToTake);
            }

            var dtos = await query.Select(s => new SkillNameDTO()
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();

            return dtos;
        }

        public async Task<Guid> GetSkillTypeIdBySkill(Guid id)
        {
            var dto = await GetFirstOrDefaultAsync(s => s.Id == id, include: s => s.Include(s => s.SkillType));

            return dto.SkillType.Id;
        }
    }
}
