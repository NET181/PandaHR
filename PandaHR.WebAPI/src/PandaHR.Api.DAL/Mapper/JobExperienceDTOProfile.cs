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
            CreateMap<JobExperience, JobExperienceExportDTO>()
                .ForMember(dest => dest.Period, opt =>
                    opt.MapFrom(src => $"{src.StartDate.ToShortDateString()} - {src.FinishDate.ToShortDateString()}"))
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.ProjectName));
        }
    }
}
