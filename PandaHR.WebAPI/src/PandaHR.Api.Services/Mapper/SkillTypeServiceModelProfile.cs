using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models;

namespace PandaHR.Api.Services.Mapper
{
    class SkillTypeServiceModelProfile : AutoMapperProfile
    {
        public SkillTypeServiceModelProfile()
        {
            CreateMap<SkillType, SkillTypeServiceModel>();
        }
    }
}
