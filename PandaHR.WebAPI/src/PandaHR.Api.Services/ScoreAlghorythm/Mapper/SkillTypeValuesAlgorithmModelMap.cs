using PandaHR.Api.Common;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Services.ScoreAlghorythm.Models;
using PandaHR.Api.Services.ScoreAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
