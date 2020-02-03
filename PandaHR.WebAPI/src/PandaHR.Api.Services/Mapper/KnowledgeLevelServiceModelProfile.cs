using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.KnowledgeLevel;

namespace PandaHR.Api.Services.Mapper
{
    public class KnowledgeLevelServiceModelProfile : AutoMapperProfile
    {
        public KnowledgeLevelServiceModelProfile()
        {
            CreateMap< KnowledgeLevel, KnowledgeLevelServiceModel>();
        }
    }
}
