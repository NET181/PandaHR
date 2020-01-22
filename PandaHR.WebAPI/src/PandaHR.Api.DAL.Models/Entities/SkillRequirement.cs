using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class SkillRequirement
    {
        public Vacancy Vacancy { get; set; }
        public Guid VacancyId { get; set; }
    }
}
