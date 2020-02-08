using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlgorithm.Models
{
    public class SkillTypeValues
    {
        public SkillTypeValues(int hardSkillsValue, int softSkillsValue, int languageSkillsValue)
        {
            SoftSkillsValue = softSkillsValue;
            HardSkillsValue = hardSkillsValue;
            LanguageSkillsValue = languageSkillsValue;
        }

        public int SoftSkillsValue { get;}
        public int HardSkillsValue { get;}
        public int LanguageSkillsValue { get;}
    }
}
