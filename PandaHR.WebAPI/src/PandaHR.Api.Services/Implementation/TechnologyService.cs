using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.Technology;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Technology;

namespace PandaHR.Api.Services.Implementation
{
    public class TechnologyService : ITechnologyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public TechnologyService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ICollection<TechnologyNameServiceModel>> GetTechnologyNamesAsync()
        {
            var serviceModels = await _uow.Technologies.GetTechnologyNameDTOsAsync();

            return _mapper.Map<ICollection<TechnologyNameDTO>, ICollection<TechnologyNameServiceModel>>(serviceModels);
        }
    }
}
