using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.City;
using PandaHR.Api.Services.Models.City;

namespace PandaHR.Api.Services.Mapper
{
    public class CityServiceModelProfile : AutoMapperProfile
    {
        public CityServiceModelProfile()
        {
            CreateMap<CityWithNameServiceModel, CityDTO>();

            CreateMap<CityNameDTO, CityNameServiceModel>();
            CreateMap<CityDTO, CityWithNameServiceModel>();
        }
    }
}
