using PandaHR.Api.Services.ScoreAlgorithm.Models;
using PandaHR.Api.Services.ScoreAlgorithm.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlgorithm
{
    public class ScoreAlghorythmBuilder
    {
        private readonly SkillTypeValueValidator _splittedValidator = new SkillTypeValueValidator();
        private readonly KnowledgeScaleStepsValidator _knowledgeValidatior = new KnowledgeScaleStepsValidator();

        public ScoreAlghorythm GetScoreAlghorythm(int hardSkillsValue, int softSkillsValue, int languageSkillsValue
            , int softKnowledgeScaleStep, int hardKnowledgeScaleStep
            , int languageKnowledgeScaleStep, int qualificationScaleStep)
        {
            var skillTypeValues = new SkillTypeValues(hardSkillsValue, softSkillsValue, languageSkillsValue);
            var knowledgeScaleStep = new KnowledgeScaleSteps(softKnowledgeScaleStep
                , hardKnowledgeScaleStep, languageKnowledgeScaleStep, qualificationScaleStep);

            var splitterValidationResult = _splittedValidator.Validate(skillTypeValues);
            var knowledgeScaleStepValidationResult = _knowledgeValidatior.Validate(knowledgeScaleStep);

            if (splitterValidationResult.IsValid && knowledgeScaleStepValidationResult.IsValid)
            {
                var skillSplitter = new SkillSplitter(skillTypeValues);
                var skillMatcher = new SkillsMatcher();
                var ratingCounter = new RatingCounter(knowledgeScaleStep);

                return new ScoreAlghorythm(skillSplitter, ratingCounter, skillMatcher);
            }

            throw new ArgumentException("Arguments is not valid");
        }
    }
}
