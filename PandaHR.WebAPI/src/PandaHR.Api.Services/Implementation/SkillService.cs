using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class SkillService : ISkillService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public SkillService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            var skills = await _uow.Skills.GetAllAsync(
                include: s => s
                    .Include(k => k.SkillKnowledges)
                        .ThenInclude(s => s.KnowledgeLevel)
                    .Include(k => k.SkillType)
                    .Include(k => k.SkillRequirements)
                        .ThenInclude(s => s.Vacancy)
                    .Include(k => k.SubSkills));

            return skills;
        }
    }
}
