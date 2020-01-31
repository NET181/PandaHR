using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.DTOs.Skill
{
    public class SkillFullDTO
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
        public string Name { get; set; }
    }
}
