using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Technology;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class TechnologyNameDTOProfile : AutoMapperProfile
    {
        public TechnologyNameDTOProfile()
        {
            CreateMap<Technology, TechnologyNameDTO>();
        }
    }
}
