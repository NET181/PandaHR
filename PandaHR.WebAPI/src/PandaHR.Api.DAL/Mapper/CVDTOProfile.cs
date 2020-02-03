using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Mapper
{
    public class CVDTOProfile : AutoMapperProfile
    {
        public CVDTOProfile()
        {
            CreateMap<CVDTO, CV>();
        }
    }
}
