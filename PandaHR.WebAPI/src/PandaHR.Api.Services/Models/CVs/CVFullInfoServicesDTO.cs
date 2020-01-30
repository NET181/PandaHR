using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ServicesDTOs.CVs
{
    public class CVFullInfoServicesDTO
    {
        public string Summary { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<SkillAndJobExperienceService> Skill { get; set; }
    }
}
