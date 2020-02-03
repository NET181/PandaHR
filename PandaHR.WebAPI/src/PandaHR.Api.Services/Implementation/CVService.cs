using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.Models.SkillKnowledge;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class CVService : ICVService ,IAsyncService<CVServiceModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CVService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task AddAsync(CVServiceModel cvServiceModel)
        {
            CVDTO cv = _mapper.Map<CVServiceModel, CVDTO>(cvServiceModel);

            await _uow.CVs.AddAsync(cv);
        }

        public async Task<IEnumerable<CVServiceModel>> GetAllAsync()
        {
            var CVs = new List<CV>
                (await _uow.CVs.GetAllAsync(include: s => s
                .Include(x => x.SkillKnowledges)
                    .ThenInclude(s => s.Skill)
                    .ThenInclude(s => s.SubSkills)
                .Include(x => x.SkillKnowledges)
                    .ThenInclude(s => s.Skill)
                    .ThenInclude(s => s.SkillType)
                .Include(q => q.Qualification)
                .Include(x => x.SkillKnowledges)
                    .ThenInclude(k => k.KnowledgeLevel)
                    .ThenInclude(t => t.SkillKnowledgeTypes)
                .Include(e => e.SkillKnowledges)
                .ThenInclude(e => e.Experience)));

            return new List<CVServiceModel>(_mapper.Map<IEnumerable<CV>, IEnumerable<CVServiceModel>>(CVs)); 
        }

        public async Task<CV> GetByIdAsync(Guid id)
        {
            return await _uow.CVs.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Guid id)
        {
            var jobExperience = await GetByIdAsync(id);
            await RemoveAsync(jobExperience);
        }

        public async Task RemoveAsync(CV entity)
        {
            await _uow.CVs.Remove(entity);
        }

        public Task RemoveAsync(CVServiceModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(CV entity)
        {
            await _uow.CVs.Update(entity);
        }

        public Task UpdateAsync(CVServiceModel entity)
        {
            throw new NotImplementedException();
        }

        Task<CVServiceModel> IAsyncService<CVServiceModel>.GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
