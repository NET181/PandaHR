using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.KnowledgeLevel;
using PandaHR.Api.DAL.DTOs.Skill;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.KnowledgeLevel;
using PandaHR.Api.Services.Models.Skill;

namespace PandaHR.Api.Services.Implementation
{
    public class SkillService : IAsyncService<SkillServiceModel>, ISkillService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SkillService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkillServiceModel>> GetAllAsync()
        {
            var skills = await _uow.Skills.GetAllAsync(predicate: s => s.RootSkill == null,
                include: s => s
                    .Include(k => k.SkillKnowledges)
                        .ThenInclude(s => s.KnowledgeLevel)
                    .Include(k => k.SkillType)
                    .Include(k => k.SkillRequirements)
                        .ThenInclude(s => s.Vacancy)
                    .Include(k => k.SubSkills));

            return _mapper.Map<IEnumerable<Skill>, IEnumerable<SkillServiceModel>>(skills);
        }

        public async Task<SkillServiceModel> GetByIdAsync(Guid id)
        {
            var skill = await _uow.Skills.GetFirstOrDefaultAsync(d => d.Id == id);

            return _mapper.Map<Skill, SkillServiceModel>(skill);
        }

        public async Task<SkillServiceModel> AddAsync(SkillServiceModel skill)
        {
            var res = await AddAsync(_mapper.Map<SkillServiceModel, Skill>(skill));

            return _mapper.Map<Skill, SkillServiceModel>(res);
        }

        public async Task<Skill> AddAsync(Skill skill)
        {
            var res = await _uow.Skills.AddAsync(skill);
            await _uow.Skills.SaveAsync();

            return res;
        }

        public async Task UpdateAsync(SkillServiceModel skill)
        {
            _uow.Skills.Update(_mapper.Map<SkillServiceModel, Skill>(skill));
            await _uow.Skills.SaveAsync();
        }

        public async Task RemoveAsync(SkillServiceModel skill)
        {
            _uow.Skills.Remove(_mapper.Map<SkillServiceModel, Skill>(skill));
            await _uow.Skills.SaveAsync();
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
            int countToTake = 5;
            var dtos = await _uow.Skills.GetSkillNameDTOsAsync(s=>s.Name.Contains(term), countToTake);

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
