using System;

namespace PandaHR.Api.Models.Skill
{
    public class SkillCreationModel
    {
        public string Name { get; set; }
        public Guid SkillTypeId { get; set; }
        public Guid? RootSkillId { get; set; }
    }
}
