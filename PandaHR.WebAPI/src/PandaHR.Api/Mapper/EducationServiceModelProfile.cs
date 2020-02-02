using PandaHR.Api.Common;
using PandaHR.Api.Models.Education;
using PandaHR.Api.Services.Models.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Mapper
{
    public class EducationServiceModelProfile : AutoMapperProfile
    {
        public EducationServiceModelProfile()
        {
            CreateMap<EducationBasicInfoServiceModel, EducationBasicInfoResponse>();
        }
    }
}
