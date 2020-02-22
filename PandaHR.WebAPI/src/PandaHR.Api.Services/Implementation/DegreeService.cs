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

        public async Task<Degree> AddAsync(Degree entity)
        {
            var result = await _uow.Degrees.AddAsync(entity);
            await _uow.Degrees.SaveAsync();

            return result;
        }

        public async Task RemoveAsync(Guid id)
        {
            var degree = await GetByIdAsync(id);
            await RemoveAsync(degree);
        }

        public async Task RemoveAsync(Degree entity)
        {
            _uow.Degrees.Remove(entity);
            await _uow.Degrees.SaveAsync();
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
            _uow.Degrees.Update(entity);
            await _uow.Degrees.SaveAsync();
        }
    }
}
