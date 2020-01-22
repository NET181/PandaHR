using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}
