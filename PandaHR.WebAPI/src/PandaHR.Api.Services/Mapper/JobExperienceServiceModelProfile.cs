using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.JobExperience;
using PandaHR.Api.Services.Exporter.Models.ExportModels;
using PandaHR.Api.Services.Models.JobExperience;

namespace PandaHR.Api.Services.Mapper
{
    public class JobExperienceServiceModelProfile : AutoMapperProfile
    {
        public JobExperienceServiceModelProfile()
        {
            CreateMap<JobExperienceDTO, JobExperienceServiceModel>();
            CreateMap<JobExperienceExportDTO, JobExperienceExportModel>();

            CreateMap<JobExperienceServiceModel, JobExperienceDTO>();
        }
    }
}
