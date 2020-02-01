using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class CVRepository : EFRepositoryAsync<CV>, ICVRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CVRepository(ApplicationDbContext context, IMapper mapper) :
            base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CV> GetById(Guid id)
        {
            var CV = await _context.CVs.Where(j => j.Id == id).FirstAsync();
            return CV;
        }

        public async Task<IList<CVforSearchDTO>> GetUserCVsAsync(Guid userId, int? pageSize = 10, int? page = 1)
        {
            IQueryable<CV> query = _context.CVs.Where(cv => cv.UserId == userId)
                .Include(c => c.SkillKnowledges)
                .Include(c => c.Qualification)
                .Include(c => c.Technology);
            if (pageSize != null && page != null)
            {
                query = query.Skip((int)pageSize * (int)page).Take((int)pageSize);
            }

            return _mapper.Map<IList<CV>, IList<CVforSearchDTO>>(await query.ToListAsync());
        }
    }
}
