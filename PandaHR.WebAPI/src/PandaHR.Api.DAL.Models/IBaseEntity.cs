using System;

namespace PandaHR.Api.DAL.Models
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
    }
}
