using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Vacancy
    {
        public ICollection<SkillRequirement> SkillRequirements { get; set; }
    }
}
