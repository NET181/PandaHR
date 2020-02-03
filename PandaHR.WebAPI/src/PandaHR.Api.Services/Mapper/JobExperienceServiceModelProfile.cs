using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.JobExperience;
using PandaHR.Api.Services.Models.JobExperience;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class JobExperienceServiceModelProfile : AutoMapperProfile
    {
        public JobExperienceServiceModelProfile()
        {
            CreateMap<JobExperienceServiceModel, JobExperienceDTO>();

            CreateMap<JobExperienceDTO, JobExperienceServiceModel>();

            CreateMap<JobExperienceServiceModel, JobExperienceDTO>();
        }
    }
}
