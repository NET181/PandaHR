using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class JobExperience : BaseEntity , ISoftDeletable
    {
        public bool IsDeleted { get; set; }
        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public Guid CVId { get; set; }
        public CV CV { get; set; }
    }
}
