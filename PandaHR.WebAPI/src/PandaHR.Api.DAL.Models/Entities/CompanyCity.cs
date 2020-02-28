using System;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class CompanyCity : ISoftDeletable
    {
        public bool IsDeleted { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}
