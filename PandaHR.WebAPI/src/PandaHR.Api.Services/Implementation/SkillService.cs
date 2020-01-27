using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var skills = await _uow.Skills.GetAllAsync(predicate: s => s.RootSkill == null,
                include: s => s
                    .Include(k => k.SkillKnowledges)
                        .ThenInclude(s => s.KnowledgeLevel)
                    .Include(k => k.SkillType)
                    .Include(k => k.SkillRequirements)
                        .ThenInclude(s => s.Vacancy)
                    .Include(k => k.SubSkills));

            return skills;
        }

        public async Task<Skill> GetById(Guid id)
        {
            var skill = await _uow.Skills.GetByIdAsync(id, include: s => s
             .Include(k => k.SkillKnowledges)
                        .ThenInclude(s => s.KnowledgeLevel)
                    .Include(k => k.SkillType)
                    .Include(k => k.SkillRequirements)
                        .ThenInclude(s => s.Vacancy)
                    .Include(k => k.SubSkills));

            return skill;
        }

        public async Task Add(Skill skill)
        {
            await _uow.Skills.Add(skill);
        }

        public async Task Update(Skill skill)
        {
            await _uow.Skills.Update(skill);
        }

        public async Task Remove(Skill skill)
        {
            await _uow.Skills.Remove(skill);
        }
    }
}
