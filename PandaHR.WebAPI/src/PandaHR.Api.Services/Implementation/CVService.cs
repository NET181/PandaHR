using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Services.Implementation
{
    public class CVService : ICVService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CVService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task AddAsync(CV entity)
        {
            await _uow.CVs.Add(entity);
        }

        public async Task<IEnumerable<CV>> GetAllAsync()
        {
            return await _uow.CVs.GetAllAsync();
        }

        public async Task<CV> GetByIdAsync(Guid id)
        {
            return await _uow.CVs.GetByIdAsync(id);
        }

        public async Task<IList<CVforSearchDTO>> GetUserCVsPreviewAsync(Guid userId, int? pageSize = 10, int? page = 1)
        {
            return await _uow.CVs.GetUserCVsAsync(userId, pageSize, page);
        }

        public async Task RemoveAsync(Guid id)
        {
            var CV = await GetByIdAsync(id);
            await RemoveAsync(CV);
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
