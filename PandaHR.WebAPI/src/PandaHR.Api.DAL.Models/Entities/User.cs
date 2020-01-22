using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class User
    {
        public User()
        {
            UserCompanies = new HashSet<UserCompany>();
        }

        public ICollection<UserCompany> UserCompanies;
    }
}
