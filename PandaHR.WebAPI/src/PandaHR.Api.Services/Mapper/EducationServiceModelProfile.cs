using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Education;
using PandaHR.Api.Services.Exporter.Models.ExportModels;
using PandaHR.Api.Services.Models.Education;

namespace PandaHR.Api.Services.Mapper
{
    public class EducationServiceModelProfile : AutoMapperProfile
    {
        public EducationServiceModelProfile()
        {
            CreateMap<EducationDTO, EducationWithDetailsServiceModel>();
            CreateMap<EducationBasicInfoDTO, EducationBasicInfoServiceModel>();
            CreateMap<EducationWithDetailsDTO, EducationWithDetailsServiceModel>();
            CreateMap<EducationExportDTO, EducationExportModel>();

            CreateMap<EducationWithDetailsServiceModel, EducationWithDetailsDTO>();
        }
    }
}
