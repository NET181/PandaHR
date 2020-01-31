using PandaHR.Api.Services.ScoreAlghorythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlghorythm
{
    class ScoreAlghorythm
    {
        private const int PERCENT_DIVIDER = 100;

        public int GetRating(Vacancy vacancy, CV cv, int languageKnowledgeScaleStep
            , int hardKnowledgeScaleStep, int softKnowledgeScaleStep, int qualificationScaleStep)
        {
            int middleWeight = FindMiddleWeight(vacancy.SkillRequests);
            var splitedSkills = SplitSkills(vacancy.SkillRequests, middleWeight);

            return CountRaiting(splitedSkills, cv, vacancy, softKnowledgeScaleStep
                , hardKnowledgeScaleStep, qualificationScaleStep
                , languageKnowledgeScaleStep, middleWeight);
        }

        public List<KeyValuePair<int, CV>> GetCVsRaiting(Vacancy vacancy, List<CV> cVs
            , int languageKnowledgeScaleStep, int hardKnowledgeScaleStep
            , int softKnowledgeScaleStep, int qualificationScaleStep)
        {
            List<KeyValuePair<int, CV>> cvsByRaiting = new List<KeyValuePair<int, CV>>();
            int middleWeight = FindMiddleWeight(vacancy.SkillRequests);
            var splitedSkills = SplitSkills(vacancy.SkillRequests, middleWeight);
            int raiting;

            foreach (CV cV in cVs)
            {
                raiting = CountRaiting(splitedSkills, cV, vacancy, softKnowledgeScaleStep
                    , hardKnowledgeScaleStep, qualificationScaleStep
                    , languageKnowledgeScaleStep, middleWeight);
                cvsByRaiting.Add(new KeyValuePair<int, CV>(raiting, cV));

                splitedSkills.ClearCV();
            }
            cvsByRaiting = cvsByRaiting.OrderByDescending(x => x.Key).ToList();

            return cvsByRaiting;
        }

        public List<KeyValuePair<int, Vacancy>> GetVacancysRaiting(List<Vacancy> vacancys, CV cV
            , int languageKnowledgeScaleStep, int hardKnowledgeScaleStep
            , int softKnowledgeScaleStep, int qualificationScaleStep)
        {
            List<KeyValuePair<int, Vacancy>> vacancysByRaiting = new List<KeyValuePair<int, Vacancy>>();
            int middleWeight;
            SplitedSkills splitedSkills;
            int raiting;

            foreach (Vacancy vacancy in vacancys)
            {
                middleWeight = FindMiddleWeight(vacancy.SkillRequests);
                splitedSkills = SplitSkills(vacancy.SkillRequests, middleWeight);

                raiting = CountRaiting(splitedSkills, cV, vacancy, softKnowledgeScaleStep
                    , hardKnowledgeScaleStep, qualificationScaleStep
                    , languageKnowledgeScaleStep, middleWeight);
                vacancysByRaiting.Add(new KeyValuePair<int, Vacancy>(raiting, vacancy));

                splitedSkills = new SplitedSkills();
            }
            vacancysByRaiting = vacancysByRaiting.OrderByDescending(x => x.Key).ToList();

            return vacancysByRaiting;
        }

        private int CountRaiting(SplitedSkills splitedSkills, CV cv, Vacancy vacancy
            , int softKnowledgeScaleStep, int hardKnowledgeScaleStep, int qualificationScaleStep
            , int languageKnowledgeScaleStep, int middleWeight)
        {
            int raiting = 1;

            splitedSkills = FindCommonSkills(cv.SkillKnowledges, splitedSkills);
            splitedSkills = FindAllSubSkills(cv.SkillKnowledges, splitedSkills);

            raiting += CountOtherSkillScore(splitedSkills.SoftSkills, softKnowledgeScaleStep);
            raiting += CountMainSkillScore(splitedSkills.MainSkills, hardKnowledgeScaleStep);
            raiting += CountOtherSkillScore(splitedSkills.HardSkills, hardKnowledgeScaleStep);
            raiting += CountLanguageSkillScore(splitedSkills, middleWeight, languageKnowledgeScaleStep);
            raiting = CountRaitingWithQualification(raiting, cv, vacancy, qualificationScaleStep);

            return raiting;
        }

        private int CountRaitingWithQualification(int raiting, CV cv
            , Vacancy vacancy, int qualificationScaleStep)
        {


            if (cv.Qualification < vacancy.Qualification)
            {
                raiting = raiting - raiting * (vacancy.Qualification - cv.Qualification)
                    * qualificationScaleStep / PERCENT_DIVIDER;
            }
            else if (cv.Qualification > vacancy.Qualification)
            {
                raiting = raiting - raiting * (cv.Qualification - vacancy.Qualification)
                    * qualificationScaleStep / PERCENT_DIVIDER;
            }

            return raiting;
        }

        private int CountMainSkillScore(List<SrSk> mainSkills, int scaleStep)
        {
            if (mainSkills.Count == 0)
            {
                return 0;
            }

            int raiting = 1;

            foreach (var skill in mainSkills)
            {
                if (skill.Sk != null)
                {
                    if (skill.Sk.KnowledgeLevel >= skill.Sr.KnowledgeLevel)
                    {
                        raiting += skill.Sr.Weight + skill.Sr.Weight
                            * (skill.Sk.KnowledgeLevel - skill.Sr.KnowledgeLevel)
                            * scaleStep / PERCENT_DIVIDER;
                    }
                    else if (skill.Sk.KnowledgeLevel < skill.Sr.KnowledgeLevel)
                    {
                        raiting += skill.Sr.Weight - skill.Sr.Weight
                            * (skill.Sr.KnowledgeLevel - skill.Sk.KnowledgeLevel)
                            * scaleStep * scaleStep / PERCENT_DIVIDER;
                    }
                }
                else
                {
                    raiting -= skill.Sr.Weight;
                }
            }

            return raiting;
        }

        private int CountLanguageSkillScore(SplitedSkills splitedSkills, int middleWeight, int scaleStep)
        {
            if (splitedSkills.LangSkills.Count == 0)
            {
                return 0;
            }

            int raiting = 1;

            foreach (var skill in splitedSkills.LangSkills)
            {
                if (skill.Sr.Weight > splitedSkills.MainSkills.Last().Sr.Weight - middleWeight) // lang is main?
                {
                    if (skill.Sk != null)
                    {
                        if (skill.Sk.KnowledgeLevel >= skill.Sr.KnowledgeLevel)
                        {
                            raiting += skill.Sr.Weight + skill.Sr.Weight
                                * (skill.Sk.KnowledgeLevel - skill.Sr.KnowledgeLevel)
                                * scaleStep / PERCENT_DIVIDER;
                        }
                        else if (skill.Sk.KnowledgeLevel < skill.Sr.KnowledgeLevel)
                        {
                            raiting += skill.Sr.Weight - skill.Sr.Weight
                                * (skill.Sr.KnowledgeLevel - skill.Sk.KnowledgeLevel)
                                * scaleStep * scaleStep / PERCENT_DIVIDER;
                        }
                    }
                    else
                    {
                        raiting -= skill.Sr.Weight;// * 3 / 2;
                    }
                }
                else
                {
                    if (skill.Sk != null)
                    {
                        if (skill.Sk.KnowledgeLevel >= skill.Sr.KnowledgeLevel)
                        {
                            raiting += skill.Sr.Weight + skill.Sr.Weight
                                * (skill.Sk.KnowledgeLevel - skill.Sr.KnowledgeLevel)
                                * scaleStep / PERCENT_DIVIDER >> 1;
                        }
                        else if (skill.Sk.KnowledgeLevel < skill.Sr.KnowledgeLevel)
                        {
                            raiting += skill.Sr.Weight - skill.Sr.Weight
                                * (skill.Sr.KnowledgeLevel - skill.Sk.KnowledgeLevel)
                                * scaleStep * scaleStep / PERCENT_DIVIDER >> 1;
                        }
                    }
                    else
                    {
                        raiting -= skill.Sr.Weight >> 1;
                    }
                }
            }
            raiting /= splitedSkills.LangSkills.Count;

            return raiting;
        }

        private int CountOtherSkillScore(List<SrSk> skills, int scaleStep)
        {
            if (skills.Count == 0)
            {
                return 0;
            }

            int raiting = 1;

            foreach (var skill in skills)
            {
                if (skill.Sk != null)
                {
                    if (skill.Sk.KnowledgeLevel >= skill.Sr.KnowledgeLevel)
                    {
                        raiting += skill.Sr.Weight + skill.Sr.Weight
                            * (skill.Sk.KnowledgeLevel - skill.Sr.KnowledgeLevel)
                            * scaleStep / PERCENT_DIVIDER >> 1;

                    }
                    else if (skill.Sk.KnowledgeLevel < skill.Sr.KnowledgeLevel)
                    {
                        raiting += skill.Sr.Weight - skill.Sr.Weight
                            * (skill.Sr.KnowledgeLevel - skill.Sk.KnowledgeLevel)
                            * scaleStep * scaleStep / PERCENT_DIVIDER >> 1;
                    }
                }
                else
                {
                    raiting -= skill.Sr.Weight >> 1;
                }
            }

            return raiting;

        }

        private SplitedSkills FindCommonSkills(List<SkillKnowledge> knowledges, SplitedSkills splitedSkills)
        {
            splitedSkills.HardSkills = FindPairSkill(knowledges, splitedSkills.HardSkills);
            splitedSkills.LangSkills = FindPairSkill(knowledges, splitedSkills.LangSkills);
            splitedSkills.MainSkills = FindPairSkill(knowledges, splitedSkills.MainSkills);
            splitedSkills.SoftSkills = FindPairSkill(knowledges, splitedSkills.SoftSkills);

            return splitedSkills;
        }

        private SplitedSkills FindAllSubSkills(List<SkillKnowledge> knowledges, SplitedSkills splitedSkills)
        {
            splitedSkills.HardSkills = FindRootSkills(knowledges, splitedSkills.HardSkills);
            splitedSkills.LangSkills = FindRootSkills(knowledges, splitedSkills.LangSkills);
            splitedSkills.MainSkills = FindRootSkills(knowledges, splitedSkills.MainSkills);
            splitedSkills.SoftSkills = FindRootSkills(knowledges, splitedSkills.SoftSkills);

            return splitedSkills;
        }

        private List<SrSk> FindPairSkill(List<SkillKnowledge> knowledges, List<SrSk> requested)
        {
            foreach (var reqSkill in requested)
            {
                foreach (var knowSkill in knowledges)
                {
                    if (reqSkill.Sr.Skill == knowSkill.Skill)
                    {
                        reqSkill.Sk = knowSkill;
                        break;
                    }
                }
            }

            return requested;
        }

        private List<SrSk> FindRootSkills(List<SkillKnowledge> subSkills, List<SrSk> rootSkills)
        {
            foreach (var rootSkill in rootSkills)
            {
                foreach (var subSkill in subSkills)
                {
                    if (IsOneOfSubSkills(subSkill.Skill, rootSkill.Sr.Skill))
                    {
                        rootSkill.Sk = subSkill;
                        break;
                    }
                }
            }

            return rootSkills;
        }

        private bool IsOneOfSubSkills(Skill subSkill, Skill rootSkill)
        {
            if (rootSkill.SupSkills == null)
            {
                return false;
            }

            bool result = false;

            foreach (var skill in rootSkill.SupSkills)
            {
                if (subSkill == skill)
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

        private SplitedSkills SplitSkills(List<SkillRequest> skillRequests, int middleWeight)
        {
            var splitedSkills = new SplitedSkills();

            skillRequests = skillRequests.OrderByDescending(w => w.Weight).ToList();

            for (int index = 0; index < skillRequests.Count; index++)
            {
                switch (skillRequests[index].Skill.SkillType)
                {
                    case 1://SkillType.soft:
                        splitedSkills.SoftSkills.Add(new SrSk()
                        {
                            Sr = skillRequests[index]
                        });
                        break;
                    case 2:// SkillType.hard:
                        splitedSkills.HardSkills.Add(new SrSk()
                        {
                            Sr = skillRequests[index]
                        });
                        break;
                    case 3:// SkillType.lang:
                        splitedSkills.LangSkills.Add(new SrSk()
                        {
                            Sr = skillRequests[index]
                        });
                        break;
                    default:
                        throw new ArgumentException("Invalid SkillType value");
                }
            }

            var buf = new List<SrSk>();
            bool stoped = false;
            buf = splitedSkills.HardSkills.ToList();

            for (int index = 1; index < splitedSkills.HardSkills.Count; index++)
            {
                splitedSkills.MainSkills.Add(new SrSk()
                {
                    Sr = splitedSkills.HardSkills[index - 1].Sr
                });
                buf.Remove(splitedSkills.HardSkills[index - 1]);

                if (splitedSkills.HardSkills[index - 1].Sr.Weight
                    - splitedSkills.HardSkills[index].Sr.Weight > middleWeight)
                {
                    stoped = true;
                    break;
                }
            }
            if (!stoped)
            {
                splitedSkills.MainSkills.Add(new SrSk()
                { Sr = splitedSkills.HardSkills[splitedSkills.HardSkills.Count - 1].Sr });
                buf.Remove(buf.Last());
            }

            splitedSkills.HardSkills = buf;

            return splitedSkills;
        }

        private int FindMiddleWeight(List<SkillRequest> sr)
        {
            int result = 0;

            sr = sr.OrderByDescending(w => w.Weight).ToList();

            result = (sr.First().Weight - sr.Last().Weight) / sr.Count();

            return result;
        }
    }
}
