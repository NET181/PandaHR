using PandaHR.Api.Common;
using PandaHR.Api.Models.CV;
using PandaHR.Api.Services.Models.CV;

namespace PandaHR.Api.Mapper
{
    public class CVModelProfiler : AutoMapperProfile
    {
        public CVModelProfiler()
        {
            CreateMap<CVCreationRequestModel, CVServiceModel>();
            CreateMap<CVCreationRequestModel, CVCreationServiceModel>();

        }
    }
}
