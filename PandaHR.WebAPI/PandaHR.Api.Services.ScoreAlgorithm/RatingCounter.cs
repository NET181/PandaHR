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
            int rating = 1;

            rating += CountOtherSkillScore(splitedSkills.SoftSkills, _softKnowledgeScaleStep);
            rating += CountMainSkillScore(splitedSkills.MainSkills);
            rating += CountOtherSkillScore(splitedSkills.HardSkills, _hardKnowledgeScaleStep);
            rating += CountLanguageSkillScore(splitedSkills, middleWeight);
            rating = CountRatingWithQualification(rating, cv, vacancy);

            rating = RatingToZeroIfLess(rating);

            return rating;
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

            int rating = 1;

            foreach (var skill in mainSkills)
            {
                if (skill.SkillKnowledge != null)
                {
                    if (skill.SkillKnowledge.KnowledgeLevel >= skill.SkillRequirement.KnowledgeLevel)
                    {
                        rating += skill.SkillRequirement.Weight + skill.SkillRequirement.Weight
                            * (skill.SkillKnowledge.KnowledgeLevel - skill.SkillRequirement.KnowledgeLevel)
                            * _hardKnowledgeScaleStep / PERCENT_DIVIDER;
                    }
                    else if (skill.SkillKnowledge.KnowledgeLevel < skill.SkillRequirement.KnowledgeLevel)
                    {
                        rating = CountWithExpirience(rating, skill);

                        rating += skill.SkillRequirement.Weight - skill.SkillRequirement.Weight
                            * (skill.SkillRequirement.KnowledgeLevel - skill.SkillKnowledge.KnowledgeLevel)
                            * _hardKnowledgeScaleStep * _hardKnowledgeScaleStep / PERCENT_DIVIDER;

                        rating = RatingToZeroIfLess(rating);
                    }
                }
                else
                {
                    rating -= skill.SkillRequirement.Weight;
                }
            }

            return rating;
        }

        private int CountLanguageSkillScore(SplitedSkillsAlghorythmModel splitedSkills, int middleWeight)
        {
            if (splitedSkills.LangSkills.Count == 0)
            {
                return 0;
            }

            int rating = 1;

            foreach (var skill in splitedSkills.LangSkills)
            {
                if (skill.SkillRequirement.Weight > splitedSkills.MainSkills.Last().SkillRequirement.Weight - middleWeight) // lang is main?
                {
                    if (skill.SkillKnowledge != null)
                    {
                        if (skill.SkillKnowledge.KnowledgeLevel >= skill.SkillRequirement.KnowledgeLevel)
                        {
                            rating += skill.SkillRequirement.Weight + skill.SkillRequirement.Weight
                                * (skill.SkillKnowledge.KnowledgeLevel - skill.SkillRequirement.KnowledgeLevel)
                                * _languageKnowledgeScaleStep / PERCENT_DIVIDER;
                        }
                        else if (skill.SkillKnowledge.KnowledgeLevel < skill.SkillRequirement.KnowledgeLevel)
                        {
                            rating = CountWithExpirience(rating, skill);

                            rating += skill.SkillRequirement.Weight - skill.SkillRequirement.Weight
                                * (skill.SkillRequirement.KnowledgeLevel - skill.SkillKnowledge.KnowledgeLevel)
                                * _languageKnowledgeScaleStep * _languageKnowledgeScaleStep / PERCENT_DIVIDER;

                            rating = RatingToZeroIfLess(rating);
                        }
                    }
                    else
                    {
                        rating -= skill.SkillRequirement.Weight;
                    }
                }

                else
                {
                    if (skill.SkillKnowledge != null)
                    {
                        if (skill.SkillKnowledge.KnowledgeLevel >= skill.SkillRequirement.KnowledgeLevel)
                        {
                            rating += skill.SkillRequirement.Weight + skill.SkillRequirement.Weight
                                * (skill.SkillKnowledge.KnowledgeLevel - skill.SkillRequirement.KnowledgeLevel)
                                * _languageKnowledgeScaleStep / PERCENT_DIVIDER >> 1;
                        }
                        else if (skill.SkillKnowledge.KnowledgeLevel < skill.SkillRequirement.KnowledgeLevel)
                        {
                            rating = CountWithExpirience(rating, skill);

                            rating += skill.SkillRequirement.Weight - skill.SkillRequirement.Weight
                                * (skill.SkillRequirement.KnowledgeLevel - skill.SkillKnowledge.KnowledgeLevel)
                                * _languageKnowledgeScaleStep * _languageKnowledgeScaleStep / PERCENT_DIVIDER >> 1;

                            rating = RatingToZeroIfLess(rating);
                        }
                    }
                    else
                    {
                        rating -= skill.SkillRequirement.Weight >> 1;
                    }
                }
            }
            rating /= splitedSkills.LangSkills.Count;

            return rating;
        }

        private int CountWithExpirience(int rating, SkillRequestSkillKnowledge skill)
        {
            if (skill.SkillKnowledge.Expirience < skill.SkillRequirement.Expirience)
            {
                rating -= skill.SkillRequirement.Expirience / skill.SkillKnowledge.Expirience;
            }

            return rating;
        }

        private int CountOtherSkillScore(List<SkillRequestSkillKnowledge> skills, int scaleStep)
        {
            if (skills.Count == 0)
            {
                return 0;
            }

            int rating = 1;

            foreach (var skill in skills)
            {
                if (skill.SkillKnowledge != null)
                {
                    if (skill.SkillKnowledge.KnowledgeLevel >= skill.SkillRequirement.KnowledgeLevel)
                    {
                        rating += skill.SkillRequirement.Weight + skill.SkillRequirement.Weight
                            * (skill.SkillKnowledge.KnowledgeLevel - skill.SkillRequirement.KnowledgeLevel)
                            * scaleStep / PERCENT_DIVIDER >> 1;

                    }
                    else if (skill.SkillKnowledge.KnowledgeLevel < skill.SkillRequirement.KnowledgeLevel)
                    {
                        rating = CountWithExpirience(rating, skill);

                        rating += skill.SkillRequirement.Weight - skill.SkillRequirement.Weight
                            * (skill.SkillRequirement.KnowledgeLevel - skill.SkillKnowledge.KnowledgeLevel)
                            * scaleStep * scaleStep / PERCENT_DIVIDER >> 1;

                        rating = RatingToZeroIfLess(rating);
                    }
                }
                else
                {
                    rating -= skill.SkillRequirement.Weight >> 1;
                }
            }

            return rating;

        }

        private int RatingToZeroIfLess(int rating)
        {
            if (rating < 0)
            {
                rating = 0;
            }

            return rating;
        }
    }
}
