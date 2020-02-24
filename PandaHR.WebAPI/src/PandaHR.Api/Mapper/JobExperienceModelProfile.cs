using AutoMapper;
using PandaHR.Api.Models.JobExperience;
using PandaHR.Api.Services.Models.JobExperience;

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
