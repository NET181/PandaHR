using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlghorythm.Models
{
    class SplitedSkills
    {
        public List<SrSk> MainSkills { get; set; }
        public List<SrSk> HardSkills { get; set; }
        public List<SrSk> SoftSkills { get; set; }
        public List<SrSk> LangSkills { get; set; }

        public SplitedSkills()
        {
            MainSkills = new List<SrSk>();
            HardSkills = new List<SrSk>();
            SoftSkills = new List<SrSk>();
            LangSkills = new List<SrSk>();
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
