using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using PandaHR.Api.Services.Models.Qualification;

namespace PandaHR.Api.UnitTests.Comaparers
{
    class QualificationServiceModelEqualityComparer : IEqualityComparer<QualificationServiceModel>
    {
        public bool Equals([AllowNull] QualificationServiceModel x, [AllowNull] QualificationServiceModel y)
        {
            return x.Id == y.Id
                && x.Name == y.Name
                && x.Value == y.Value;
        }

        public int GetHashCode([DisallowNull] QualificationServiceModel obj)
        {
            return base.GetHashCode();
        }
    }
}
