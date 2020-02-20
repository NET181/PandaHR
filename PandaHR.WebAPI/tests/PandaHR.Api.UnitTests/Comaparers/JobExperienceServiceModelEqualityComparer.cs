using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using PandaHR.Api.Services.Models.JobExperience;

namespace PandaHR.Api.UnitTests.Comaparers
{
    class JobExperienceServiceModelEqualityComparer : IEqualityComparer<JobExperienceServiceModel>
    {
        public bool Equals([AllowNull] JobExperienceServiceModel x, [AllowNull] JobExperienceServiceModel y)
        {
            return x.CompanyName == y.CompanyName
                && x.Description == y.Description
                && x.FinishDate == y.FinishDate
                && x.ProjectName == y.ProjectName
                && x.StartDate == y.StartDate;
        }

        public int GetHashCode([DisallowNull] JobExperienceServiceModel obj)
        {
            return base.GetHashCode();
        }
    }
}
