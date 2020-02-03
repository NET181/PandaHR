using PandaHR.Api.Common;
using PandaHR.Api.Models.Technology;
using PandaHR.Api.Services.Models.Technology;

namespace PandaHR.Api.Mapper
{
    public class TechnologyNameModelProfile : AutoMapperProfile
    {
        public TechnologyNameModelProfile()
        {
            CreateMap<TechnologyNameServiceModel, TechnologyNameResponseModel>();
        }
    }
}
