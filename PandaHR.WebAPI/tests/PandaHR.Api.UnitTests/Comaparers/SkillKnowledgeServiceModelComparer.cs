using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using PandaHR.Api.Services.Models.SkillKnowledge;

namespace PandaHR.Api.UnitTests.Comaparers
{
    class SkillKnowledgeServiceModelComparer : IEqualityComparer<SkillKnowledgeServiceModel>
    {
        public bool Equals([AllowNull] SkillKnowledgeServiceModel x, [AllowNull] SkillKnowledgeServiceModel y)
        {
            return
                x.ExperienceId == y.ExperienceId &&
                x.KnowledgeLevelId == y.KnowledgeLevelId &&
                x.SkillId == y.SkillId;
        }

        public int GetHashCode([DisallowNull] SkillKnowledgeServiceModel obj)
        {
            return base.GetHashCode();
        }
    }
}
