using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.Services.Models.CV;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class CVServiceModelProfile : AutoMapperProfile
    {
        public CVServiceModelProfile()
        {
            CreateMap<CVCreationServiceModel, CVDTO>();
        }
    }
}
