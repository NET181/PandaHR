using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
    }
}
