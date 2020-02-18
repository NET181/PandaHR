using AutoMapper;
using PandaHR.Api.Models.JobExperience;
using PandaHR.Api.Services.Models.JobExperience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Mapper
{
    public class JobExperienceModelProfile: Profile
    {
        public JobExperienceModelProfile()
        {
            CreateMap<JobExperienceRequestModel, JobExperienceServiceModel>();
        }
    }
}
