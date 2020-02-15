using PandaHR.Api.Services.ScoreAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlgorithm
{
    internal class SkillsMatcher
    {
        public SplitedSkillsAlghorythmModel MatchSkills(List<SkillKnowledgeAlghorythmModel> skillKnowledges
            , SplitedSkillsAlghorythmModel splitedSkills)
        {
            splitedSkills = FindCommonSkills(skillKnowledges, splitedSkills);
            splitedSkills = FindAllSubSkills(skillKnowledges, splitedSkills);

            return splitedSkills;
        }
        private SplitedSkillsAlghorythmModel FindCommonSkills(List<SkillKnowledgeAlghorythmModel> knowledges
            , SplitedSkillsAlghorythmModel splitedSkills)
        {
            splitedSkills.HardSkills = FindPairSkill(knowledges, splitedSkills.HardSkills);
            splitedSkills.LangSkills = FindPairSkill(knowledges, splitedSkills.LangSkills);
            splitedSkills.MainSkills = FindPairSkill(knowledges, splitedSkills.MainSkills);
            splitedSkills.SoftSkills = FindPairSkill(knowledges, splitedSkills.SoftSkills);

            return splitedSkills;
        }

        private SplitedSkillsAlghorythmModel FindAllSubSkills(List<SkillKnowledgeAlghorythmModel> knowledges
            , SplitedSkillsAlghorythmModel splitedSkills)
        {
            splitedSkills.HardSkills = FindRootSkills(knowledges, splitedSkills.HardSkills);
            splitedSkills.LangSkills = FindRootSkills(knowledges, splitedSkills.LangSkills);
            splitedSkills.MainSkills = FindRootSkills(knowledges, splitedSkills.MainSkills);
            splitedSkills.SoftSkills = FindRootSkills(knowledges, splitedSkills.SoftSkills);

            return splitedSkills;
        }

        private List<SkillRequestSkillKnowledge> FindPairSkill(List<SkillKnowledgeAlghorythmModel> knowledges
            , List<SkillRequestSkillKnowledge> requested)
        {
            foreach (var reqSkill in requested)
            {
                foreach (var knowSkill in knowledges)
                {
                    if (reqSkill.SkillRequirement.Skill.Id == knowSkill.Skill.Id)
                    {
                        reqSkill.SkillKnowledge = knowSkill;
                        break;
                    }
                }
            }

            return requested;
        }

        private List<SkillRequestSkillKnowledge> FindRootSkills(List<SkillKnowledgeAlghorythmModel> subSkills
            , List<SkillRequestSkillKnowledge> rootSkills)
        {
            foreach (var rootSkill in rootSkills)
            {
                foreach (var subSkill in subSkills)
                {
                    if (IsOneOfSubSkills(subSkill.Skill, rootSkill.SkillRequirement.Skill))
                    {
                        rootSkill.SkillKnowledge = subSkill;
                        break;
                    }
                }
            }

            return rootSkills;
        }

        private bool IsOneOfSubSkills(SkillAlghorythmModel subSkill, SkillAlghorythmModel rootSkill)
        {
            bool result = false;

            if (rootSkill.SubSkills == null)
            {
                return result;
            }

            foreach (var skill in rootSkill.SubSkills)
            {
                if (subSkill.Id == skill.Id)
                {
                    result = true;
                    break;
                }
                if (IsOneOfSubSkills(subSkill, skill))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
