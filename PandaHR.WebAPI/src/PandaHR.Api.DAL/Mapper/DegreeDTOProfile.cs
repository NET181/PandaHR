using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Degree;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class DegreeDTOProfile : AutoMapperProfile
    {
        public DegreeDTOProfile()
        {
            CreateMap<Degree, DegreeDTO>();
        }
    }
}
