using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Technology;
using PandaHR.Api.Services.Exporter.Models.ExportModels;
using PandaHR.Api.Services.Models.Technology;

namespace PandaHR.Api.Services.Mapper
{
    public class TechnologyNameServiceProfile : AutoMapperProfile
    {
        public TechnologyNameServiceProfile()
        {
            CreateMap<TechnologyNameDTO, TechnologyNameServiceModel>();
            CreateMap<TechnologyExportDTO, TechnologyExportModel>();
        }
    }
}
