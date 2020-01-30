using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.DAL_DTOs.CVs
{
    public class CVFullInfoDAL_DTO
    {
        public Guid UserId { get; set; }
        public string Summary { get; set; }
        public IEnumerable<SkillAndJobExperienceDAL> Skill { get; set; }
        
    }
}
