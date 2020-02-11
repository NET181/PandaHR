using System;
using System.Collections.Generic;
using System.Linq;
using PandaHR.Api.Services.ScoreAlghorythm.Models;

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

            return CountRating(splitedSkills, cv, vacancy, softKnowledgeScaleStep
                , hardKnowledgeScaleStep, qualificationScaleStep
                , languageKnowledgeScaleStep, middleWeight);
        }

        public List<IdAndRating> GetCVsRating(VacancyAlghorythmModel vacancy, IEnumerable<CVAlghorythmModel> cVs
            , int languageKnowledgeScaleStep, int hardKnowledgeScaleStep
            , int softKnowledgeScaleStep, int qualificationScaleStep)
        {
            List<IdAndRating> cvsByRaiting = new List<IdAndRating>();
            int middleWeight = FindMiddleWeight(vacancy.SkillRequests);
            var splitedSkills = SplitSkills(vacancy.SkillRequests, middleWeight);
            int rating;

            foreach (CVAlghorythmModel cV in cVs)
            {
                rating = CountRating(splitedSkills, cV, vacancy, softKnowledgeScaleStep
                    , hardKnowledgeScaleStep, qualificationScaleStep
                    , languageKnowledgeScaleStep, middleWeight);
                cvsByRaiting.Add(new IdAndRating()
                {
                    Id = cV.Id,
                    Rating = rating
                });

                splitedSkills.ClearCV();
            }
            cvsByRaiting = cvsByRaiting.OrderByDescending(x => x.Rating).ToList();

            return cvsByRaiting;
        }

        public List<IdAndRating> GetVacancysRaiting(IEnumerable<VacancyAlghorythmModel> vacancys, CVAlghorythmModel cV
            , int languageKnowledgeScaleStep, int hardKnowledgeScaleStep
            , int softKnowledgeScaleStep, int qualificationScaleStep)
        {
            List<IdAndRating> vacancysByRating = new List<IdAndRating>();
            int middleWeight;
            SplitedSkillsAlghorythmModel splitedSkills;
            int raiting;

            foreach (VacancyAlghorythmModel vacancy in vacancys)
            {
                middleWeight = FindMiddleWeight(vacancy.SkillRequests);
                splitedSkills = SplitSkills(vacancy.SkillRequests, middleWeight);

                raiting = CountRating(splitedSkills, cV, vacancy, softKnowledgeScaleStep
                    , hardKnowledgeScaleStep, qualificationScaleStep
                    , languageKnowledgeScaleStep, middleWeight);
                vacancysByRating.Add(new IdAndRating()
                {
                    Rating = raiting,
                    Id = vacancy.Id
                });

                splitedSkills = new SplitedSkillsAlghorythmModel();
            }
            vacancysByRating = vacancysByRating.OrderByDescending(x => x.Rating).ToList();

            return vacancysByRating;
        }

        private int CountRating(SplitedSkillsAlghorythmModel splitedSkills, CVAlghorythmModel cv, VacancyAlghorythmModel vacancy
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
            raiting = CountRatingWithQualification(raiting, cv, vacancy, qualificationScaleStep);

            return raiting;
        }

        private int CountRatingWithQualification(int raiting, CVAlghorythmModel cv
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
                if (skill.SkillKnowledge != null)
                {
                    if (skill.SkillKnowledge.KnowledgeLevel >= skill.SkillRequirement.KnowledgeLevel)
                    {
                        raiting += skill.SkillRequirement.Weight + skill.SkillRequirement.Weight
                            * (skill.SkillKnowledge.KnowledgeLevel - skill.SkillRequirement.KnowledgeLevel)
                            * scaleStep / PERCENT_DIVIDER;
                    }
                    else if (skill.SkillKnowledge.KnowledgeLevel < skill.SkillRequirement.KnowledgeLevel)
                    {
                        raiting += skill.SkillRequirement.Weight - skill.SkillRequirement.Weight
                            * (skill.SkillRequirement.KnowledgeLevel - skill.SkillKnowledge.KnowledgeLevel)
                            * scaleStep * scaleStep / PERCENT_DIVIDER;
                    }
                }
                else
                {
                    raiting -= skill.SkillRequirement.Weight;
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
                if (skill.SkillRequirement.Weight > splitedSkills.MainSkills.Last().SkillRequirement.Weight - middleWeight) // lang is main?
                {
                    if (skill.SkillKnowledge != null)
                    {
                        if (skill.SkillKnowledge.KnowledgeLevel >= skill.SkillRequirement.KnowledgeLevel)
                        {
                            raiting += skill.SkillRequirement.Weight + skill.SkillRequirement.Weight
                                * (skill.SkillKnowledge.KnowledgeLevel - skill.SkillRequirement.KnowledgeLevel)
                                * scaleStep / PERCENT_DIVIDER;
                        }
                        else if (skill.SkillKnowledge.KnowledgeLevel < skill.SkillRequirement.KnowledgeLevel)
                        {
                            raiting += skill.SkillRequirement.Weight - skill.SkillRequirement.Weight
                                * (skill.SkillRequirement.KnowledgeLevel - skill.SkillKnowledge.KnowledgeLevel)
                                * scaleStep * scaleStep / PERCENT_DIVIDER;
                        }
                    }
                    else
                    {
                        raiting -= skill.SkillRequirement.Weight;// * 3 / 2;
                    }
                }

                else
                {
                    if (skill.SkillKnowledge != null)
                    {
                        if (skill.SkillKnowledge.KnowledgeLevel >= skill.SkillRequirement.KnowledgeLevel)
                        {
                            raiting += skill.SkillRequirement.Weight + skill.SkillRequirement.Weight
                                * (skill.SkillKnowledge.KnowledgeLevel - skill.SkillRequirement.KnowledgeLevel)
                                * scaleStep / PERCENT_DIVIDER >> 1;
                        }
                        else if (skill.SkillKnowledge.KnowledgeLevel < skill.SkillRequirement.KnowledgeLevel)
                        {
                            raiting += skill.SkillRequirement.Weight - skill.SkillRequirement.Weight
                                * (skill.SkillRequirement.KnowledgeLevel - skill.SkillKnowledge.KnowledgeLevel)
                                * scaleStep * scaleStep / PERCENT_DIVIDER >> 1;
                        }
                    }
                    else
                    {
                        raiting -= skill.SkillRequirement.Weight >> 1;
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
                if (skill.SkillKnowledge != null)
                {
                    if (skill.SkillKnowledge.KnowledgeLevel >= skill.SkillRequirement.KnowledgeLevel)
                    {
                        raiting += skill.SkillRequirement.Weight + skill.SkillRequirement.Weight
                            * (skill.SkillKnowledge.KnowledgeLevel - skill.SkillRequirement.KnowledgeLevel)
                            * scaleStep / PERCENT_DIVIDER >> 1;

                    }
                    else if (skill.SkillKnowledge.KnowledgeLevel < skill.SkillRequirement.KnowledgeLevel)
                    {
                        raiting += skill.SkillRequirement.Weight - skill.SkillRequirement.Weight
                            * (skill.SkillRequirement.KnowledgeLevel - skill.SkillKnowledge.KnowledgeLevel)
                            * scaleStep * scaleStep / PERCENT_DIVIDER >> 1;
                    }
                }
                else
                {
                    raiting -= skill.SkillRequirement.Weight >> 1;
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
                    if (reqSkill.SkillRequirement.Skill.Id == knowSkill.Skill.Id)
                    {
                        reqSkill.SkillKnowledge = knowSkill;
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
                            SkillRequirement = skillRequests[index]
                        });
                        break;
                    case 2:// SkillType.lang:
                        splitedSkills.LangSkills.Add(new SkillRequestSkillKnowledge()
                        {
                            SkillRequirement = skillRequests[index]
                        });
                        break;
                    case 3://SkillType.soft:
                        splitedSkills.SoftSkills.Add(new SkillRequestSkillKnowledge()
                        {
                            SkillRequirement = skillRequests[index]
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
                        SkillRequirement = splitedSkills.HardSkills[index - 1].SkillRequirement
                    });
                    buf.Remove(splitedSkills.HardSkills[index - 1]);

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
