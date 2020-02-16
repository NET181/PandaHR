using PandaHR.Api.Services.ScoreAlgorithm.Models;
using PandaHR.Api.Services.ScoreAlgorithm.Validation;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("PandaHR.Api.UnitTests")]
namespace PandaHR.Api.Services.ScoreAlgorithm
{
    public class ScoreAlghorythmBuilder : IScoreAlghorythmBuilder
    {
        private readonly SkillTypeValueValidator _splittedValidator;
        private readonly KnowledgeScaleStepsValidator _knowledgeValidatior;

        public ScoreAlghorythmBuilder()
        {
            _splittedValidator = new SkillTypeValueValidator();
            _knowledgeValidatior = new KnowledgeScaleStepsValidator();
        }

        /// <summary>
        /// exeption throw
        /// </summary>
        /// <param name="languageKnowledgeScaleStep"></param>
        /// <param name="qualificationScaleStep"></param>
        /// <returns></returns>
        public ScoreAlghorythm GetScoreAlghorythm(SkillTypeValuesw skillTypeValues,
            KnowledgeScaleSteps knowledgeScaleSteps)
        {
            var splitterValidationResult = _splittedValidator.Validate(skillTypeValues);
            var knowledgeScaleStepValidationResult = _knowledgeValidatior.Validate(knowledgeScaleSteps);

            if (splitterValidationResult.IsValid && knowledgeScaleStepValidationResult.IsValid)
            {
                var skillSplitter = new SkillSplitter(skillTypeValues);
                var skillMatcher = new SkillsMatcher();
                var ratingCounter = new RatingCounter(knowledgeScaleSteps);

                return new ScoreAlghorythm(skillSplitter, ratingCounter, skillMatcher);
            }

            throw new ArgumentException($"Arguments is not valid");
        }
    }
}
