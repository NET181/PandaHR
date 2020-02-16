using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.JobExperience;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class JobExperienceDTOProfile : AutoMapperProfile
    {
        public JobExperienceDTOProfile()
        {
            CreateMap<JobExperienceDTO, JobExperience>();
            CreateMap<JobExperience, JobExperienceDTO>();
        }
    }
}
