using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTO.Experience;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class ExperienceDTOProfile : AutoMapperProfile
    {
        public ExperienceDTOProfile()
        {
            CreateMap<Experience, ExperienceDTO>();
        }
    }
}
