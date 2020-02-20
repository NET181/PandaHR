using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using PandaHR.Api.Services.Models.CV;

namespace PandaHR.Api.UnitTests.Comaparers
{
    class CVServiceModelEqualityComparer : IEqualityComparer<CVServiceModel>
    {
        public bool Equals([AllowNull] CVServiceModel x, [AllowNull] CVServiceModel y)
        {
            bool skEq = x.SkillKnowledges.SequenceEqual(y.SkillKnowledges, new SkillKnowledgeServiceModelComparer());
            bool edEq = x.Educations.SequenceEqual(y.Educations, new EducationWithDetailsServiceModelComparer());
            bool jeEq = x.JobExperiences.SequenceEqual(y.JobExperiences, new JobExperienceServiceModelEqualityComparer());
            bool sEqu = x.Skills.SequenceEqual(y.Skills, new SkillForSearchDTOEqualityComparer());
            bool quEq = new QualificationServiceModelEqualityComparer().Equals(x.Qualification, y.Qualification);
            bool usEq = new UserCreationServiceModelEqualityComparer().Equals(x.User, y.User);

            return x.IsActive == y.IsActive
                && x.QualificationId == y.QualificationId
                && x.Summary == y.Summary
                && x.TechnologyId == y.TechnologyId
                && skEq && edEq && jeEq && sEqu && quEq && usEq;
    }

        public int GetHashCode([DisallowNull] CVServiceModel obj)
        {
            obj.Id = new Guid();
            return base.GetHashCode();
        }
    }
}
