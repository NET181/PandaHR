using System;

namespace PandaHR.Api.DAL.Models
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime AddedDate { set; get; }
        DateTime ModifiedDate { set; get; }
    }
}
