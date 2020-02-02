using PandaHR.Api.Common;
using PandaHR.Api.Models.Degree;
using PandaHR.Api.Services.Models.Degree;

namespace PandaHR.Api.Mapper
{
    public class DegreeModelProfile : AutoMapperProfile
    {
        public DegreeModelProfile()
        {
            CreateMap<DegreeServiceModel, DegreeResponceModel>();
        }   
    }
}
