using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.JobExperience;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Mapper
{
    public class JobExperienceDTOProfile : AutoMapperProfile
    {
        public JobExperienceDTOProfile()
        {
            CreateMap<JobExperienceDTO, JobExperience>();
        }
    }
}
