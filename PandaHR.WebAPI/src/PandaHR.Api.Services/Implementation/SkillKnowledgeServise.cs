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
    public class SkillKnowledgeServise : ISkillKnowledgeServise
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public SkillKnowledgeServise(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IEnumerable<SkillKnowledge>> GetAllAsync()
        {
            var skillsKnowledges = await _uow.SkillKnowledges.GetAllAsync(
                include: s => s
                    .Include(k => k.Skill)
                    .Include(k => k.KnowledgeLevel)
                    .Include(k => k.CV));

            return skillsKnowledges;
        }

        public async Task<SkillKnowledge> GetById(Guid id)
        {
            var skillsKnowledge = await _uow.SkillKnowledges.GetByIdAsync(id, include: s => s
                    .Include(k => k.Skill)
                    .Include(k => k.KnowledgeLevel)
                    .Include(k => k.CV));

            return skillsKnowledge;
        }

        public async Task Add(SkillKnowledge skillKnowledge)
        {
            await _uow.SkillKnowledges.Add(skillKnowledge);
        }

        public async Task Update(SkillKnowledge skillKnowledge)
        {
            await _uow.SkillKnowledges.Update(skillKnowledge);
        }

        public async Task Remove(SkillKnowledge skillKnowledge)
        {
            await _uow.SkillKnowledges.Remove(skillKnowledge);
        }
    }
}
