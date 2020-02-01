using System;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.DTOs.SkillKnowledge
{
    public class SkillForSearchDTO
    {
        public string SkillName { get; set; }
        public KnowledgeLevel Level { get; set; }
    }
}
