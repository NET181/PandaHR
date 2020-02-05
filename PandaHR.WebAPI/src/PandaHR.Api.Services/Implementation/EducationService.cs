using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.Education;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Education;

namespace PandaHR.Api.Services.Implementation
{
    public class EducationService : IAsyncService<Education>, IEducationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public EducationService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task AddAsync(Education entity)
        {
            await _uow.Educations.Add(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var education = await GetByIdAsync(id);
            await RemoveAsync(education);
        }

        public async Task RemoveAsync(Education entity)
        {
            await _uow.Educations.Remove(entity);
        }

        public async Task<IEnumerable<Education>> GetAllAsync()
        {
            return await _uow.Educations.GetAllAsync();
        }

        public async Task<Education> GetByIdAsync(Guid id)
        {
            return await _uow.Educations.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(Education entity)
        {
            await _uow.Educations.Update(entity);
        }

        public async Task<ICollection<EducationBasicInfoServiceModel>> GetBasicInfoByAutofillByName(string name)
        {
            var educations = await _uow.Educations.GetBasicInfoByAutofillByName(name);

            var educationsServiceModel = _mapper.Map<ICollection<EducationBasicInfoDTO>,
                ICollection<EducationBasicInfoServiceModel>>(educations);

            return educationsServiceModel;
        }
    }
}
