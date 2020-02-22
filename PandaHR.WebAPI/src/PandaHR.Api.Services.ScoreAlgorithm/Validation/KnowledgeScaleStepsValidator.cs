using FluentValidation;
using PandaHR.Api.Services.ScoreAlgorithm.Models;

namespace PandaHR.Api.Services.ScoreAlgorithm.Validation
{
    public class KnowledgeScaleStepsValidator : AbstractValidator<KnowledgeScaleSteps>
    {
        public KnowledgeScaleStepsValidator()
        {
            RuleFor(v => v.HardKnowledgeScaleStep)
                .Must(v => v > 0)
                .WithMessage("HardKnowledgeScaleStep must be more than 0");
            RuleFor(v => v.LanguageKnowledgeScaleStep)
                .Must(v => v > 0)
                .WithMessage("LanguageKnowledgeScaleStep must be more than 0");
            RuleFor(v => v.QualificationScaleStep)
                .Must(v => v > 0)
                .WithMessage("QualificationScaleStep must be more than 0");
            RuleFor(v => v.SoftKnowledgeScaleStep)
                .Must(v => v > 0)
                .WithMessage("SoftKnowledgeScaleStep must be more than 0");
        }
    }
}
