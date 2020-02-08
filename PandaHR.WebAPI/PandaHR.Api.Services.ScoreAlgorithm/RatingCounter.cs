using PandaHR.Api.Services.ScoreAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlgorithm
{
    internal class RatingCounter
    {
        private const int PERCENT_DIVIDER = 100;

        private readonly int _softKnowledgeScaleStep;
        private readonly int _hardKnowledgeScaleStep;
        private readonly int _languageKnowledgeScaleStep;
        private readonly int _qualificationScaleStep;

        public RatingCounter(KnowledgeScaleSteps knowledgeScaleSteps)
        {
            _softKnowledgeScaleStep = knowledgeScaleSteps.SoftKnowledgeScaleStep;
            _hardKnowledgeScaleStep = knowledgeScaleSteps.HardKnowledgeScaleStep;
            _languageKnowledgeScaleStep = knowledgeScaleSteps.LanguageKnowledgeScaleStep;
            _qualificationScaleStep = knowledgeScaleSteps.QualificationScaleStep;
        }

        public int CountRating(SplitedSkillsAlghorythmModel splitedSkills, CVAlghorythmModel cv, VacancyAlghorythmModel vacancy
             , int middleWeight)
        {
            int raiting = 1;

            raiting += CountOtherSkillScore(splitedSkills.SoftSkills, _softKnowledgeScaleStep);
            raiting += CountMainSkillScore(splitedSkills.MainSkills);
            raiting += CountOtherSkillScore(splitedSkills.HardSkills, _hardKnowledgeScaleStep);
            raiting += CountLanguageSkillScore(splitedSkills, middleWeight);
            raiting = CountRatingWithQualification(raiting, cv, vacancy);

            return raiting;
        }

        private int CountRatingWithQualification(int raiting, CVAlghorythmModel cv
            , VacancyAlghorythmModel vacancy)
        {
            if (cv.Qualification < vacancy.Qualification)
            {
                raiting = raiting - raiting * (vacancy.Qualification - cv.Qualification)
                    * _qualificationScaleStep / PERCENT_DIVIDER;
            }
            else if (cv.Qualification > vacancy.Qualification)
            {
                raiting = raiting - raiting * (cv.Qualification - vacancy.Qualification)
                    * _qualificationScaleStep / PERCENT_DIVIDER;
            }

            return raiting;
        }

        private int CountMainSkillScore(List<SkillRequestSkillKnowledge> mainSkills)
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
                            * _hardKnowledgeScaleStep / PERCENT_DIVIDER;
                    }
                    else if (skill.SkillKnowledge.KnowledgeLevel < skill.SkillRequirement.KnowledgeLevel)
                    {
                        raiting += skill.SkillRequirement.Weight - skill.SkillRequirement.Weight
                            * (skill.SkillRequirement.KnowledgeLevel - skill.SkillKnowledge.KnowledgeLevel)
                            * _hardKnowledgeScaleStep * _hardKnowledgeScaleStep / PERCENT_DIVIDER;
                    }
                }
                else
                {
                    raiting -= skill.SkillRequirement.Weight;
                }
            }

            return raiting;
        }

        private int CountLanguageSkillScore(SplitedSkillsAlghorythmModel splitedSkills, int middleWeight)
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
                                * _languageKnowledgeScaleStep / PERCENT_DIVIDER;
                        }
                        else if (skill.SkillKnowledge.KnowledgeLevel < skill.SkillRequirement.KnowledgeLevel)
                        {
                            raiting += skill.SkillRequirement.Weight - skill.SkillRequirement.Weight
                                * (skill.SkillRequirement.KnowledgeLevel - skill.SkillKnowledge.KnowledgeLevel)
                                * _languageKnowledgeScaleStep * _languageKnowledgeScaleStep / PERCENT_DIVIDER;
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
                                * _languageKnowledgeScaleStep / PERCENT_DIVIDER >> 1;
                        }
                        else if (skill.SkillKnowledge.KnowledgeLevel < skill.SkillRequirement.KnowledgeLevel)
                        {
                            raiting += skill.SkillRequirement.Weight - skill.SkillRequirement.Weight
                                * (skill.SkillRequirement.KnowledgeLevel - skill.SkillKnowledge.KnowledgeLevel)
                                * _languageKnowledgeScaleStep * _languageKnowledgeScaleStep / PERCENT_DIVIDER >> 1;
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
    }
}
