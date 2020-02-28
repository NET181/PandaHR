using PandaHR.Api.Common;
using PandaHR.Api.Models.Qualification;
using PandaHR.Api.Services.Models.Qualification;

namespace PandaHR.Api.Mapper
{
    public class QualificationModelProfile : AutoMapperProfile
    {
        public QualificationModelProfile()
        {
            CreateMap<QualificationServiceModel, QualificationResponseModel>();
            CreateMap<QualificationResponseModel, QualificationServiceModel>();
        }
    }
}
