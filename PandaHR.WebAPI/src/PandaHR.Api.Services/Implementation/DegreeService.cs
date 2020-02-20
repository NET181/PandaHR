using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.Degree;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Degree;

namespace PandaHR.Api.Services.Implementation
{
    public class DegreeService : IAsyncService<Degree>, IDegreeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DegreeService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ICollection<DegreeServiceModel>> GetDegreesAsync()
        {
            var serviceModels = await _uow.Degrees.GetDegreeDTOsAsync();

            return _mapper.Map<ICollection<DegreeDTO>, ICollection<DegreeServiceModel>>(serviceModels);
        }

        public async Task AddAsync(Degree entity)
        {
            await _uow.Degrees.AddAsync(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var degree = await GetByIdAsync(id);
            await RemoveAsync(degree);
        }

        public async Task RemoveAsync(Degree entity)
        {
            await _uow.Degrees.Remove(entity);
        }

        public async Task<IEnumerable<Degree>> GetAllAsync()
        {
            return await _uow.Degrees.GetAllAsync();
        }

        public async Task<Degree> GetByIdAsync(Guid id)
        {
            return await _uow.Degrees.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(Degree entity)
        {
            await _uow.Degrees.Update(entity);
        }
    }
}
