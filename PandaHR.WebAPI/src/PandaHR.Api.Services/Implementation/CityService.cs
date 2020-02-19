using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.Services.Models.City;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.DTOs.City;

namespace PandaHR.Api.Services.Implementation
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _uow.Cities.GetAllAsync();
        }

        public async Task<City> GetByIdAsync(Guid cityId)
        {
            return await _uow.Cities.
                GetByIdAsync(cityId);
        }

        public async Task AddAsync(City city)
        {
            await _uow.Cities.AddAsync(city);
        }

        public async Task UpdateAsync(City city)
        {
            await _uow.Cities.Update(city);
        }

        public async Task RemoveAsync(Guid id)
        {
            var city = await _uow.Cities.GetByIdAsync(id);
            await _uow.Cities.Remove(city);
        }

        public async Task RemoveAsync(City city)
        {
            await _uow.Cities.Remove(city);
        }

        public async Task<ICollection<CityNameServiceModel>> GetCityNamesByTerm(string term)
        {
            int countToTake = 5;
            var dtos = await _uow.Cities.GetCityNameDTOsAsync(c => c.Name.Contains(term), countToTake);

            return _mapper.Map<ICollection<CityNameDTO>, ICollection<CityNameServiceModel>>(dtos);
        }
    }
}
