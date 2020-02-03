using PandaHR.Api.Services.Models.SkillKnowledgeType;
using System.Collections.Generic;

namespace PandaHR.Api.Services.Models.KnowledgeLevel
{
    public class KnowledgeLevelServiceModel
    {
        public KnowledgeLevelServiceModel()
        {
            SkillKnowledgeTypes = new List<SkillKnowledgeTypeServiceModel>();
        }

        public Guid Id { get; set; }
       public string Name { get; set; }
       public List<SkillKnowledgeTypeServiceModel> SkillKnowledgeTypes { get; set; }
    }
}
