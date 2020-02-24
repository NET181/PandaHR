using PandaHR.Api.DAL.DTOs.Skill;
using System.Collections.Generic;

namespace PandaHR.Api.DAL.DTOs.Technology
{
    public class TechnologyExportDTO
    {
        public string Name { get; set; }
        public ICollection<SkillExportDTO> Skills { get; set; }
    }
}
