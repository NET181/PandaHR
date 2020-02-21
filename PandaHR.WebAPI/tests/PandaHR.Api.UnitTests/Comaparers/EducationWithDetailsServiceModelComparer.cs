using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using PandaHR.Api.Services.Models.Education;

namespace PandaHR.Api.UnitTests.Comaparers
{
    class EducationWithDetailsServiceModelComparer : IEqualityComparer<EducationWithDetailsServiceModel>
    {
        public bool Equals([AllowNull] EducationWithDetailsServiceModel x, [AllowNull] EducationWithDetailsServiceModel y)
        {
            return x.DateEnd == y.DateEnd
                && x.DateStart == y.DateStart
                && x.DegreeId == y.DegreeId
                && x.PlaceName == y.PlaceName
                && x.Speciality == y.Speciality;
        }

        public int GetHashCode([DisallowNull] EducationWithDetailsServiceModel obj)
        {
            return base.GetHashCode();
        }
    }
}
