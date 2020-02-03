using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Education;
using PandaHR.Api.Services.Models.Education;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class EducationServiceModelProfile : AutoMapperProfile
    {
        public EducationServiceModelProfile()
        {
            CreateMap<EducationWithDetailsServiceModel, EducationWithDetailsDTO>();

            CreateMap<EducationDTO, EducationWithDetailsServiceModel>();

            CreateMap<EducationBasicInfoDTO, EducationBasicInfoServiceModel>();

            CreateMap<EducationWithDetailsServiceModel, EducationWithDetailsDTO>();
            CreateMap<EducationWithDetailsDTO, EducationWithDetailsServiceModel>();
        }
    }
}
