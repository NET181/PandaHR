using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using PandaHR.Api.Services.Models.User;

namespace PandaHR.Api.UnitTests.Comaparers
{
    class UserCreationServiceModelEqualityComparer : IEqualityComparer<UserCreationServiceModel>
    {
        public bool Equals([AllowNull] UserCreationServiceModel x, [AllowNull] UserCreationServiceModel y)
        {
            return x.Email == y.Email
                && x.FirstName == y.FirstName
                && x.Phone == y.Phone
                && x.SecondName == y.SecondName;
        }

        public int GetHashCode([DisallowNull] UserCreationServiceModel obj)
        {
            return base.GetHashCode();
        }
    }
}
