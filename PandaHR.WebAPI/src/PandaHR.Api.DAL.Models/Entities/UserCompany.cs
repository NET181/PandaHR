using System;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class UserCompany : ISoftDeletable
    {
        public bool IsDeleted { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
      
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
