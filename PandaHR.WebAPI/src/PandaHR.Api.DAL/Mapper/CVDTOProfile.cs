using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class CVDTOProfile : AutoMapperProfile
    {
        public CVDTOProfile()
        {
            CreateMap<CVDTO, CV>();
            CreateMap<CV, CVSummaryDTO>()
                .ForMember(dest => dest.QualificationName, opt => opt.MapFrom(src => src.Qualification.Name))
                .ForMember(dest => dest.TechnologyName, opt => opt.MapFrom(src => src.Technology.Name))
                .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary));
        }
    }
}
