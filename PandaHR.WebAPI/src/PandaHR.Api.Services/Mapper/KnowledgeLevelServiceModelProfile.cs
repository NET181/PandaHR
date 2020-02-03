using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.KnowledgeLevel;

namespace PandaHR.Api.Services.Mapper
{
    public class KnowledgeLevelServiceModelProfile : AutoMapperProfile
    {
        public KnowledgeLevelServiceModelProfile()
        {
            CreateMap<KnowledgeLevelDTO, KnowledgeLevelServiceModel>();
        }
    }
}
