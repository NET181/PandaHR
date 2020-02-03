using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL.DTOs.KnowledgeLevel;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class KnowledgeLevelRepository : EFRepositoryAsync<KnowledgeLevel>, IKnowledgeLevelRepository
    {
        private readonly ApplicationDbContext _context;

        public KnowledgeLevelRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }

        public async Task<ICollection<KnowledgeLevelDTO>> GetKnowledgeLevelsBySkillTypeAsync(Guid skillTypeId)
        {
            var dtos = await _context.KnowledgeLevels.Where(kl =>
                kl.SkillKnowledgeTypes.Any(skt => skt.SkillTypeId == skillTypeId))
                    .OrderBy(kl => kl.SkillKnowledgeTypes
                        .FirstOrDefault(skt => skt.SkillTypeId == skillTypeId).Value)
                .Select(c => new KnowledgeLevelDTO()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            return dtos;
        }
    }
}
