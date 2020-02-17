using PandaHR.Api.Services.ScoreAlgorithm.Models;
using PandaHR.Api.Services.ScoreAlgorithm.Validation;
using System;
using System.Runtime.CompilerServices;

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
        /// Can throw ArgumentExeption in case of negative validation
        /// </summary>
        /// <param name="skillTypeValues">Values for SkillType identification. Must be unique</param>
        /// <param name="knowledgeScaleSteps">Knowledge grab step values. Internal values ​​cannot equal 0</param>
        /// <returns>Rating calculation algorithm</returns>
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
