using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.JobExperience;
using PandaHR.Api.Services.Models.JobExperience;

namespace PandaHR.Api.Services.Mapper
{
    public class JobExperienceServiceModelProfile : AutoMapperProfile
    {
        public JobExperienceServiceModelProfile()
        {
            CreateMap<JobExperienceServiceModel, JobExperienceDTO>();
            CreateMap<JobExperienceDTO, JobExperienceServiceModel>();
        }
    }
}
