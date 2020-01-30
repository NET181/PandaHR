using System;
using System.Collections.Generic;
using System.Text;
using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTO.Experience;
using PandaHR.Api.Services.Models.Experience;

namespace PandaHR.Api.Services.Mapper
{
    public class ExperienceServiceModelProfile : AutoMapperProfile
    {
        public ExperienceServiceModelProfile()
        {
            CreateMap<ExperienceDTO, ExperienceServiceModel>();
        }
    }
}
