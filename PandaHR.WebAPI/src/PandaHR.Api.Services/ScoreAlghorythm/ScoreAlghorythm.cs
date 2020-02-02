using PandaHR.Api.Services.ScoreAlghorythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandaHR.Api.Services.ScoreAlghorythm
{
    public class ScoreAlghorythm : IScoreAlghorythm
    {
        private const int PERCENT_DIVIDER = 100;

        public int GetRating(VacancyAlghorythmModel vacancy, CVAlghorythmModel cv, int languageKnowledgeScaleStep
            , int hardKnowledgeScaleStep, int softKnowledgeScaleStep, int qualificationScaleStep)
        {
            int middleWeight = FindMiddleWeight(vacancy.SkillRequests);
            var splitedSkills = SplitSkills(vacancy.SkillRequests, middleWeight);

            return CountRaiting(splitedSkills, cv, vacancy, softKnowledgeScaleStep
                , hardKnowledgeScaleStep, qualificationScaleStep
                , languageKnowledgeScaleStep, middleWeight);
        }

        public List<IdAndRaiting> GetCVsRaiting(VacancyAlghorythmModel vacancy, IEnumerable<CVAlghorythmModel> cVs
            , int languageKnowledgeScaleStep, int hardKnowledgeScaleStep
            , int softKnowledgeScaleStep, int qualificationScaleStep)
        {
            List<IdAndRaiting> cvsByRaiting = new List<IdAndRaiting>();
            int middleWeight = FindMiddleWeight(vacancy.SkillRequests);
            var splitedSkills = SplitSkills(vacancy.SkillRequests, middleWeight);
            int raiting;

            foreach (CVAlghorythmModel cV in cVs)
            {
                raiting = CountRaiting(splitedSkills, cV, vacancy, softKnowledgeScaleStep
                    , hardKnowledgeScaleStep, qualificationScaleStep
                    , languageKnowledgeScaleStep, middleWeight);
                cvsByRaiting.Add(new IdAndRaiting()
                {
                    Id = cV.Id,
                    Raiting = raiting
                });

                splitedSkills.ClearCV();
            }
            cvsByRaiting = cvsByRaiting.OrderByDescending(x => x.Raiting).ToList();

            return cvsByRaiting;
        }

        public List<IdAndRaiting> GetVacancysRaiting(IEnumerable<VacancyAlghorythmModel> vacancys, CVAlghorythmModel cV
            , int languageKnowledgeScaleStep, int hardKnowledgeScaleStep
            , int softKnowledgeScaleStep, int qualificationScaleStep)
        {
            List<IdAndRaiting> vacancysByRaiting = new List<IdAndRaiting>();
            int middleWeight;
            SplitedSkillsAlghorythmModel splitedSkills;
            int raiting;

            foreach (VacancyAlghorythmModel vacancy in vacancys)
            {
                middleWeight = FindMiddleWeight(vacancy.SkillRequests);
                splitedSkills = SplitSkills(vacancy.SkillRequests, middleWeight);

                raiting = CountRaiting(splitedSkills, cV, vacancy, softKnowledgeScaleStep
                    , hardKnowledgeScaleStep, qualificationScaleStep
                    , languageKnowledgeScaleStep, middleWeight);
                vacancysByRaiting.Add(new IdAndRaiting()
                {
                    Raiting = raiting,
                    Id = vacancy.Id
                });

                splitedSkills = new SplitedSkillsAlghorythmModel();
            }
            vacancysByRaiting = vacancysByRaiting.OrderByDescending(x => x.Raiting).ToList();

            return vacancysByRaiting;
        }

        private int CountRaiting(SplitedSkillsAlghorythmModel splitedSkills, CVAlghorythmModel cv, VacancyAlghorythmModel vacancy
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

        private int CountRaitingWithQualification(int raiting, CVAlghorythmModel cv
            , VacancyAlghorythmModel vacancy, int qualificationScaleStep)
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

        private int CountMainSkillScore(List<SkillRequestSkillKnowledge> mainSkills, int scaleStep)
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

        private int CountLanguageSkillScore(SplitedSkillsAlghorythmModel splitedSkills, int middleWeight, int scaleStep)
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

        private int CountOtherSkillScore(List<SkillRequestSkillKnowledge> skills, int scaleStep)
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

        private SplitedSkillsAlghorythmModel FindCommonSkills(List<SkillKnowledgeAlghorythmModel> knowledges, SplitedSkillsAlghorythmModel splitedSkills)
        {
            splitedSkills.HardSkills = FindPairSkill(knowledges, splitedSkills.HardSkills);
            splitedSkills.LangSkills = FindPairSkill(knowledges, splitedSkills.LangSkills);
            splitedSkills.MainSkills = FindPairSkill(knowledges, splitedSkills.MainSkills);
            splitedSkills.SoftSkills = FindPairSkill(knowledges, splitedSkills.SoftSkills);

            return splitedSkills;
        }

        private SplitedSkillsAlghorythmModel FindAllSubSkills(List<SkillKnowledgeAlghorythmModel> knowledges, SplitedSkillsAlghorythmModel splitedSkills)
        {
            splitedSkills.HardSkills = FindRootSkills(knowledges, splitedSkills.HardSkills);
            splitedSkills.LangSkills = FindRootSkills(knowledges, splitedSkills.LangSkills);
            splitedSkills.MainSkills = FindRootSkills(knowledges, splitedSkills.MainSkills);
            splitedSkills.SoftSkills = FindRootSkills(knowledges, splitedSkills.SoftSkills);

            return splitedSkills;
        }

        private List<SkillRequestSkillKnowledge> FindPairSkill(List<SkillKnowledgeAlghorythmModel> knowledges, List<SkillRequestSkillKnowledge> requested)
        {
            foreach (var reqSkill in requested)
            {
                foreach (var knowSkill in knowledges)
                {
                    if (reqSkill.Sr.Skill.Id == knowSkill.Skill.Id)
                    {
                        reqSkill.Sk = knowSkill;
                        break;
                    }
                }
            }

            return requested;
        }

        private List<SkillRequestSkillKnowledge> FindRootSkills(List<SkillKnowledgeAlghorythmModel> subSkills, List<SkillRequestSkillKnowledge> rootSkills)
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

        private bool IsOneOfSubSkills(SkillAlghorythmModel subSkill, SkillAlghorythmModel rootSkill)
        {
            if (rootSkill.SupSkills == null)
            {
                return false;
            }

            bool result = false;

            foreach (var skill in rootSkill.SupSkills)
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

        private SplitedSkillsAlghorythmModel SplitSkills(List<SkillRequestAlghorythmModel> skillRequests, int middleWeight)
        {
            var splitedSkills = new SplitedSkillsAlghorythmModel();

            skillRequests = skillRequests.OrderByDescending(w => w.Weight).ToList();

            for (int index = 0; index < skillRequests.Count; index++)
            {
                switch (skillRequests[index].Skill.SkillType)
                {


                    case 1:// SkillType.hard:
                        splitedSkills.HardSkills.Add(new SkillRequestSkillKnowledge()
                        {
                            Sr = skillRequests[index]
                        });
                        break;
                    case 2:// SkillType.lang:
                        splitedSkills.LangSkills.Add(new SkillRequestSkillKnowledge()
                        {
                            Sr = skillRequests[index]
                        });
                        break;
                    case 3://SkillType.soft:
                        splitedSkills.SoftSkills.Add(new SkillRequestSkillKnowledge()
                        {
                            Sr = skillRequests[index]
                        });
                        break;
                    default:
                        throw new ArgumentException("Invalid SkillType value");
                }
            }

            if (splitedSkills.HardSkills.Count != 0)
            {

                var buf = new List<SkillRequestSkillKnowledge>();
                bool stoped = false;
                buf = splitedSkills.HardSkills.ToList();

                for (int index = 1; index < splitedSkills.HardSkills.Count; index++)
                {
                    splitedSkills.MainSkills.Add(new SkillRequestSkillKnowledge()
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
                    splitedSkills.MainSkills.Add(new SkillRequestSkillKnowledge()
                    {
                        Sr = splitedSkills.HardSkills[splitedSkills.HardSkills.Count - 1].Sr
                    });
                    buf.Remove(buf.Last());
                }

                splitedSkills.HardSkills = buf;
            }
            return splitedSkills;
        }

        private int FindMiddleWeight(List<SkillRequestAlghorythmModel> sr)
        {
            int result = 0;

            sr = sr.OrderByDescending(w => w.Weight).ToList();

            result = (sr.First().Weight - sr.Last().Weight) / sr.Count();

            return result;
        }
    }
}
