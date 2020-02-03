using PandaHR.Api.Common;
using PandaHR.Api.Models.City;
using PandaHR.Api.Services.Models.City;

namespace PandaHR.Api.Mapper
{
    public class CityModelProfile : AutoMapperProfile
    {
        public CityModelProfile()
        {
            CreateMap<CityNameServiceModel, CityNameResponseModel>();
        }
    }
}
