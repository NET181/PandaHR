using System;
using System.Collections.Generic;
using PandaHR.Api.DAL.Models;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;

namespace PandaHR.Api.DAL.DTOs.CV
{
    public class CVforSearchDTO
    {
        public Guid Id { get; set; }
        public string Summary { get; set; }
        public bool IsActive { get; set; }
        public Guid? UserId { get; set; }
        public string QualificationName { get; set; }
        public int QualificationValue { get; set; }
        public string TechnologyName { get; set; }

        public ICollection<SkillForSearchDTO> SkillKnowledges { get; set; }
    }
}
