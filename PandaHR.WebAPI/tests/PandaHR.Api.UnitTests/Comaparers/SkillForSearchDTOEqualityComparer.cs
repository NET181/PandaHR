using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;

namespace PandaHR.Api.UnitTests.Comaparers
{
    class SkillForSearchDTOEqualityComparer : IEqualityComparer<SkillForSearchDTO>
    {
        public bool Equals([AllowNull] SkillForSearchDTO x, [AllowNull] SkillForSearchDTO y)
        {
            return x.KnowledgeLevelName == y.KnowledgeLevelName
                && x.KnowledgeValueValue == y.KnowledgeValueValue
                && x.SkillName == y.SkillName;
        }

        public int GetHashCode([DisallowNull] SkillForSearchDTO obj)
        {
            return base.GetHashCode();
        }
    }
}
