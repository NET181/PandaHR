using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Skill : ISoftDeletable
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
