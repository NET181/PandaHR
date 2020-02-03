using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.Experience;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Experience;

namespace PandaHR.Api.Services.Implementation
{
    public class ExperienceService : IExperienceService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ExperienceService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExperienceServiceModel>> GetAllAsync()
        {
            var dto = await _uow.Experiences.GetExperienceDTOsAsync();

            return _mapper.Map<ICollection<ExperienceDTO>, ICollection<ExperienceServiceModel>>(dto);
        }
    }
}
