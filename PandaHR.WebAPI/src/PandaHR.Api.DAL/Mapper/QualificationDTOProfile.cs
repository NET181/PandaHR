using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Qualification;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class QualificationDTOProfile : AutoMapperProfile
    {
        public QualificationDTOProfile()
        {
            CreateMap<Qualification, QualificationDTO>();
        }
    }
}
