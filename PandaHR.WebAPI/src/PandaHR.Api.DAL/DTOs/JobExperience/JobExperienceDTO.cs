using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.DTOs.JobExperience
{
    public class JobExperienceDTO
    {
        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
