using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class SkillTypeService : ISkillTypeService
    {
        private readonly IUnitOfWork _uow;

        public SkillTypeService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<SkillType>> GetAllAsync()
        {
            var skillTypes = await _uow.SkillTypes
                .GetAllAsync(include: v => v
                    .Include(s => s.SkillKnowledgeTypes));

            return skillTypes;
        }

        public async Task Add(SkillType skillType)
        {
            await _uow.SkillTypes.Add(skillType);
        }

        public async Task Update(SkillType skillType)
        {
            await _uow.SkillTypes.Update(skillType);
        }

        public async Task Remove(SkillType skillType)
        {
            await _uow.SkillTypes.Remove(skillType);
        }

        public async Task<SkillType> GetById(object id)
        {
            return await _uow.SkillTypes.GetById(id);
        }
    }
}
