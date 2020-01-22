using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class SkillRequirement : BaseEntity
    {
        public float Weight { get; set; }
        public int Experience { get; set; }

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }

        public Guid KnowledgeLevelId { get; set; }
        public KnowledgeLevel KnowledgeLevel { get; set; }

        public Guid VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
