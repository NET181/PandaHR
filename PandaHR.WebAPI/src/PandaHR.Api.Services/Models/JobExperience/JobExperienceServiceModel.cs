using System;

namespace PandaHR.Api.Services.Models.JobExperience
{
    public class JobExperienceServiceModel
    {
        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
