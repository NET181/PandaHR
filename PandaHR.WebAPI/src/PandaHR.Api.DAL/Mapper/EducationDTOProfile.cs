using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Education;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Mapper
{
    public class EducationDTOProfile : AutoMapperProfile
    {
        public EducationDTOProfile()
        {
            CreateMap<EducationDTO, Education>();

            CreateMap<EducationWithDetailsDTO, Education>();
        }
    }
}
