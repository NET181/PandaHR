using System;
using System.Collections.Generic;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;

namespace PandaHR.Api.DAL.DTOs.CV
{
    public class CVforSearchDTO
    {
        public Guid Id { get; set; }
        public string Summary { get; set; }
        public bool IsActive { get; set; }
        public Guid UserId { get; set; }
        public Qualification Qualification { get; set; }
        public Technology Technology { get; set; }

        public ICollection<SkillForSearchDTO> Skills { get; set; }
    }
}
