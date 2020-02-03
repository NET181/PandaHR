using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.CV;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class CVService : ICVService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CVService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task AddAsync(CVCreationServiceModel cvServiceModel)
        {
            CVDTO cv = _mapper.Map<CVCreationServiceModel, CVDTO>(cvServiceModel);

            await _uow.CVs.AddAsync(cv);
        }

        public async Task<IEnumerable<CV>> GetAllAsync()
        {
            return await _uow.CVs.GetAllAsync();
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

        public async Task UpdateAsync(CV entity)
        {
            await _uow.CVs.Update(entity);
        }
    }
}
