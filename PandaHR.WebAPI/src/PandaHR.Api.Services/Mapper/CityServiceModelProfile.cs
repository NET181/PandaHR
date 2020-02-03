using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.City;
using PandaHR.Api.Services.Models.City;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class CityServiceModelProfile : AutoMapperProfile
    {
        public CityServiceModelProfile()
        {
            CreateMap<CityWithNameServiceModel, CityDTO>();
            CreateMap<CityDTO, CityWithNameServiceModel>();
        }
    }
}
