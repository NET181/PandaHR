using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Degree;
using PandaHR.Api.Services.Models.Degree;

namespace PandaHR.Api.Services.Mapper
{
    public class DegreeServiceModelProfile : AutoMapperProfile
    {
        public DegreeServiceModelProfile()
        {
            CreateMap<DegreeDTO, DegreeServiceModel>();
        }
    }
}
