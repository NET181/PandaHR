using System;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.DTOs.SkillKnowledge
{
    public class SkillForSearchDTO
    {
        public string SkillName { get; set; }
        public string KnowledgeLevelName { get; set; }
        public int KnowledgeValueValue { get; set; }
    }
}
