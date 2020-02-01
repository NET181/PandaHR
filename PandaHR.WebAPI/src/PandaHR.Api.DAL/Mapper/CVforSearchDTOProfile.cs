using System.Collections.Generic;
using PandaHR.Api.Common;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class CVforSearchDTOProfile : AutoMapperProfile
    {
        public CVforSearchDTOProfile(IMapper mapper)
        {
            CreateMap<CV, CVforSearchDTO>().
                ForMember(dest => dest.Skills, 
                opt => opt.MapFrom(
                    src => mapper.Map<ICollection<SkillKnowledge>, ICollection<SkillForSearchDTO>>(src.SkillKnowledges)));
        }
    }
}
