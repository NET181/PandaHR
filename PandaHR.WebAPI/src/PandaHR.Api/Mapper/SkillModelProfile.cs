using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.Skill;
using PandaHR.Api.Services.Models.Skill;

namespace PandaHR.Api.Mapper
{
    public class SkillModelProfile : AutoMapperProfile
    {
        public SkillModelProfile()
        {
            CreateMap<SkillNameServiceModel, SkillNameResponseModel>();

            CreateMap<SkillServiceModel, Skill>();

            CreateMap<SkillServiceModel, SkillResponseModel>()
                .ForMember(x => x.Id, o => o.MapFrom(s => s.Id))
                .ForMember(x => x.Name, o => o.MapFrom(s => s.Name))
                .ForMember(x => x.SubSkills, o => o.MapFrom(s => s.SubSkills));

            CreateMap<SkillCreationModel, SkillServiceModel>();
        }
    }
}
