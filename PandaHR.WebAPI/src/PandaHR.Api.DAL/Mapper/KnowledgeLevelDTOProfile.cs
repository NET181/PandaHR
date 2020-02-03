using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.KnowledgeLevel;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class KnowledgeLevelDTOProfile : AutoMapperProfile
    {
        public KnowledgeLevelDTOProfile()
        {
            CreateMap<KnowledgeLevel, KnowledgeLevelDTO>();
        }
    }
}
