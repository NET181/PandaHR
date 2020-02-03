using System;

namespace PandaHR.Api.DAL.Models
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime AddedDate { set; get; }
        public DateTime ModifiedDate { set; get; }
    }
}
