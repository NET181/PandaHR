using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Models.JobExperience
{
    public class JobExperienceRequestModel
    {
        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
