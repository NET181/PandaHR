using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.City;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class CityDTOProfile : AutoMapperProfile
    {
        public CityDTOProfile()
        {
            CreateMap<City, CityNameDTO>();

            CreateMap<CityNameDTO, City>();
        }
    }
}
