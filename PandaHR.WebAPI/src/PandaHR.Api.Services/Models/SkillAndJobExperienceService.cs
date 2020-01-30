using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ServicesDTOs
{
    public class SkillAndJobExperienceService
    {
        public string SkillName { get; set; }
        public string KnowledgeLevelName { get; set; }
        public int Experience { get; set; }
        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
