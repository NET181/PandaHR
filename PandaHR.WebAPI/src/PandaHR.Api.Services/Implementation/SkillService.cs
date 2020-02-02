using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.KnowledgeLevel;
using PandaHR.Api.DAL.DTOs.Skill;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.KnowledgeLevel;
using PandaHR.Api.Services.Models.Skill;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class SkillService : IAsyncService<Skill>, ISkillService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SkillService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
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

        public async Task<Skill> GetByIdAsync(Guid id)
        {
            return await _uow.Skills.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Skill skill)
        {
            await _uow.Skills.Add(skill);
        }

        public async Task UpdateAsync(Skill skill)
        {
            await _uow.Skills.Update(skill);
        }

        public async Task RemoveAsync(Skill skill)
        {
            await _uow.Skills.Remove(skill);
        }

        public async Task RemoveAsync(Guid id)
        {
            var skill = await GetByIdAsync(id);
            await RemoveAsync(skill);
        }

        public async Task<ICollection<SkillNameServiceModel>> GetSkillNames()
        {
            var serviceModels = await _uow.Skills.GetSkillNameDTOsAsync();

            return _mapper.Map<ICollection<SkillNameDTO>, ICollection<SkillNameServiceModel>>(serviceModels);
        }

        public async Task<ICollection<SkillNameServiceModel>> GetSkillNamesByTerm(string term)
        {
            var dtos = await _uow.Skills.GetSkillNameDTOsAsync(s=>s.Name.Contains(term));

            return _mapper.Map<ICollection<SkillNameDTO>, ICollection<SkillNameServiceModel>>(dtos);
        }

        public async Task<ICollection<KnowledgeLevelServiceModel>> GetKnowledgeLevelsBySkill(Guid skillId)
        {
            var skillTypeId = await _uow.Skills.GetSkillTypeIdBySkill(skillId);
            var dtos = await _uow.KnowledgeLevels.GetKnowledgeLevelsBySkillTypeAsync(skillTypeId);

            return _mapper.Map<ICollection<KnowledgeLevelDTO>, ICollection<KnowledgeLevelServiceModel>>(dtos);
        }
    }
}
