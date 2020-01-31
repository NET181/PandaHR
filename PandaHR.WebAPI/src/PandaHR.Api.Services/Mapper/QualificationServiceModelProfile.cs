using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTO.Qualification;
using PandaHR.Api.Services.Models.Qualification;

namespace PandaHR.Api.Services.Mapper
{
    public class QualificationServiceModelProfile : AutoMapperProfile
    {
        public QualificationServiceModelProfile()
        {
            CreateMap<QualificationDTO, QualificationServiceModel>();
        }
    }
}
