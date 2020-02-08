using PandaHR.Api.Services.ScoreAlgorithm.Models;
using PandaHR.Api.Services.ScoreAlgorithm.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlgorithm
{
    internal class SkillSplitter
    {
        private readonly SkillTypeValues _skillTypeValues;

        public SkillSplitter(SkillTypeValues skillTypeValues)
        {
            _skillTypeValues = skillTypeValues;
        }

        public SplitedSkillsAlghorythmModel SplitSkills(List<SkillRequestAlghorythmModel> skillRequests, int middleWeight)
        {
            var splitedSkills = new SplitedSkillsAlghorythmModel();

            SplitSkillsByType(skillRequests, splitedSkills);
            FindMainSkills(middleWeight, splitedSkills);

            return splitedSkills;
        }

        private List<SkillRequestAlghorythmModel> SplitSkillsByType(List<SkillRequestAlghorythmModel> skillRequests
            , SplitedSkillsAlghorythmModel splitedSkills)
        {
            skillRequests = skillRequests.OrderByDescending(w => w.Weight).ToList();

            for (int index = 0; index < skillRequests.Count; index++)
            {
                if (skillRequests[index].Skill.SkillType == _skillTypeValues.HardSkillsValue)
                {
                    splitedSkills.HardSkills.Add(new SkillRequestSkillKnowledge()
                    {
                        SkillRequirement = skillRequests[index]
                    });
                }
                else if (skillRequests[index].Skill.SkillType == _skillTypeValues.LanguageSkillsValue)
                {
                    splitedSkills.LangSkills.Add(new SkillRequestSkillKnowledge()
                    {
                        SkillRequirement = skillRequests[index]
                    });
                }
                else if (skillRequests[index].Skill.SkillType == _skillTypeValues.SoftSkillsValue)
                {
                    splitedSkills.SoftSkills.Add(new SkillRequestSkillKnowledge()
                    {
                        SkillRequirement = skillRequests[index]
                    });
                }
                else
                {
                    throw new ArgumentException("Invalid SkillType value");
                }
            }

            return skillRequests;
        }

        private void FindMainSkills(int middleWeight, SplitedSkillsAlghorythmModel splitedSkills)
        {
            if (splitedSkills.HardSkills.Count != 0)
            {
                var buffer = new List<SkillRequestSkillKnowledge>(splitedSkills.HardSkills.ToList());
                bool stoped = false;

                // buffer = splitedSkills.HardSkills.ToList();
                for (int index = 1; index < splitedSkills.HardSkills.Count; index++)
                {
                    splitedSkills.MainSkills.Add(new SkillRequestSkillKnowledge()
                    {
                        SkillRequirement = splitedSkills.HardSkills[index - 1].SkillRequirement
                    });
                    buffer.Remove(splitedSkills.HardSkills[index - 1]);

                    if (splitedSkills.HardSkills[index - 1].SkillRequirement.Weight
                        - splitedSkills.HardSkills[index].SkillRequirement.Weight > middleWeight)
                    {
                        stoped = true;
                        break;
                    }
                }
                if (!stoped)
                {
                    splitedSkills.MainSkills.Add(new SkillRequestSkillKnowledge()
                    {
                        SkillRequirement = splitedSkills.HardSkills[splitedSkills.HardSkills.Count - 1].SkillRequirement
                    });
                    buffer.Remove(buffer.Last());
                }

                splitedSkills.HardSkills = buffer;
            }
        }
    }
}
