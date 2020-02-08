using System.Collections.Generic;

namespace PandaHR.Api.Services.ScoreAlgorithm.Models
{
    public class SplitedSkillsAlghorythmModel
    {
        public SplitedSkillsAlghorythmModel()
        {
            MainSkills = new List<SkillRequestSkillKnowledge>();
            HardSkills = new List<SkillRequestSkillKnowledge>();
            SoftSkills = new List<SkillRequestSkillKnowledge>();
            LangSkills = new List<SkillRequestSkillKnowledge>();
        }

        public List<SkillRequestSkillKnowledge> MainSkills { get; set; }
        public List<SkillRequestSkillKnowledge> HardSkills { get; set; }
        public List<SkillRequestSkillKnowledge> SoftSkills { get; set; }
        public List<SkillRequestSkillKnowledge> LangSkills { get; set; }

        public void ClearCV()
        {
            foreach (var skill in MainSkills)
            {
                skill.SkillKnowledge = null;
            }
            foreach (var skill in HardSkills)
            {
                skill.SkillKnowledge = null;
            }
            foreach (var skill in SoftSkills)
            {
                skill.SkillKnowledge = null;
            }
            foreach (var skill in LangSkills)
            {
                skill.SkillKnowledge = null;
            }
        }
    }
}
