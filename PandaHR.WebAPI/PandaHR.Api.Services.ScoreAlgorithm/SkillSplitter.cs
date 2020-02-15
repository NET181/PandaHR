using PandaHR.Api.Services.ScoreAlgorithm.Models;
using PandaHR.Api.Services.ScoreAlgorithm.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("PandaHR.Api.UnitTests")]
namespace PandaHR.Api.Services.ScoreAlgorithm
{
    internal class SkillSplitter
    {
        private readonly SkillTypeValuesw _skillTypeValues;

        public SkillSplitter(SkillTypeValuesw skillTypeValues)
        {
            _skillTypeValues = skillTypeValues;
        }

        public SplitedSkillsAlghorythmModel SplitSkills(List<SkillRequestAlghorythmModel> skillRequests, int middleWeight)
        {
            var splitedSkills = SplitSkillsByType(skillRequests);
            FindMainSkills(middleWeight, splitedSkills);

            return splitedSkills;
        }

        private SplitedSkillsAlghorythmModel SplitSkillsByType(List<SkillRequestAlghorythmModel> skillRequests)
        {
            var splitedSkills = new SplitedSkillsAlghorythmModel();
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

            return splitedSkills;
        }

        private void FindMainSkills(int middleWeight, SplitedSkillsAlghorythmModel splitedSkills)
        {
            if (splitedSkills.HardSkills.Count != 0)
            {
                var buffer = new List<SkillRequestSkillKnowledge>(splitedSkills.HardSkills.ToList());
                bool stoped = false;

                for (int index = 0; index < splitedSkills.HardSkills.Count; index++)
                {
                    splitedSkills.MainSkills.Add(new SkillRequestSkillKnowledge()
                    {
                        SkillRequirement = splitedSkills.HardSkills[index].SkillRequirement
                    });
                    buffer.Remove(splitedSkills.HardSkills[index]);

                    if (splitedSkills.HardSkills[index].SkillRequirement.Weight
                        - splitedSkills.HardSkills[index + 1].SkillRequirement.Weight > middleWeight)
                    {
                        stoped = true; // -1 x3 ... +1 
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
