using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class CompanyCity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}
