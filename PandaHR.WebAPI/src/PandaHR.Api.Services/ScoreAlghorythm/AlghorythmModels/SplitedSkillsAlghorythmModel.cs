using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlghorythm.Models
{
    public class SplitedSkillsAlghorythmModel
    {
        public List<SkillRequestSkillKnowledge> MainSkills { get; set; }
        public List<SkillRequestSkillKnowledge> HardSkills { get; set; }
        public List<SkillRequestSkillKnowledge> SoftSkills { get; set; }
        public List<SkillRequestSkillKnowledge> LangSkills { get; set; }

        public SplitedSkillsAlghorythmModel()
        {
            MainSkills = new List<SkillRequestSkillKnowledge>();
            HardSkills = new List<SkillRequestSkillKnowledge>();
            SoftSkills = new List<SkillRequestSkillKnowledge>();
            LangSkills = new List<SkillRequestSkillKnowledge>();
        }

        public void ClearCV()
        {
            foreach (var skill in MainSkills)
            {
                skill.Sk = null;
            }
            foreach (var skill in HardSkills)
            {
                skill.Sk = null;
            }
            foreach (var skill in SoftSkills)
            {
                skill.Sk = null;
            }
            foreach (var skill in LangSkills)
            {
                skill.Sk = null;
            }
        }
    }
}
