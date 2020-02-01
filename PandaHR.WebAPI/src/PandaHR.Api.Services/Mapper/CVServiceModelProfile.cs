using System;
using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.Services.Models.CV;

namespace PandaHR.Api.Services.Mapper
{
    public class CVServiceModelProfile : AutoMapperProfile
    {
        public CVServiceModelProfile()
        {
            CreateMap<CVforSearchDTO, CVServiceModel>();
        }
    }
}
