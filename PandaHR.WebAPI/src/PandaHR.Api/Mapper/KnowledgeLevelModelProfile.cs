using PandaHR.Api.Common;
using PandaHR.Api.Models.KnowledgeLevel;
using PandaHR.Api.Services.Models.KnowledgeLevel;

namespace PandaHR.Api.Mapper
{
    public class KnowledgeLevelModelProfile : AutoMapperProfile
    {
        public KnowledgeLevelModelProfile()
        {
            CreateMap<KnowledgeLevelServiceModel, KnowledgeLevelResponseModel>();
        }
    }
}
