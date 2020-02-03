using PandaHR.Api.Services.Models.SkillKnowledgeType;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Models.KnowledgeLevel
{
    public class KnowledgeLevelServiceModel
    {
        public KnowledgeLevelServiceModel()
        {
            SkillKnowledgeTypes = new List<SkillKnowledgeTypeServiceModel>();
        }
       public List<SkillKnowledgeTypeServiceModel> SkillKnowledgeTypes { get; set; }
    }
}
