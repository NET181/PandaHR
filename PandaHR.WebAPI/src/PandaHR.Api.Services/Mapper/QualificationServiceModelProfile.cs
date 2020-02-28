using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Qualification;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.Qualification;

namespace PandaHR.Api.Services.Mapper
{
    public class QualificationServiceModelProfile : AutoMapperProfile
    {
        public QualificationServiceModelProfile()
        {
            CreateMap<QualificationDTO, QualificationServiceModel>();
            CreateMap<QualificationServiceModel, QualificationDTO>();
            CreateMap<Qualification, QualificationServiceModel>();
        }
    }
}
