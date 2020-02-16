using PandaHR.Api.Common;
using PandaHR.Api.Services.ScoreAlghorythm.Models;
using PandaHR.Api.Services.ScoreAlgorithm.Models;

namespace PandaHR.Api.Services.ScoreAlghorythm.Mapper
{
    public class SkillTypeValuesAlgorithmModelMap : AutoMapperProfile
    {
        public SkillTypeValuesAlgorithmModelMap()
        {
            CreateMap<SkillTypeValuesAlgorithmModel, SkillTypeValuesw>()
                ;

            CreateMap<SkillTypeValuesw, SkillTypeValuesAlgorithmModel>();
            
        }
    }
}
