using FluentValidation;
using PandaHR.Api.Services.ScoreAlgorithm.Models;

namespace PandaHR.Api.Services.ScoreAlgorithm.Validation
{
    public class SkillTypeValueValidator : AbstractValidator<SkillTypeValuesw>
    {
        public SkillTypeValueValidator()
        {
            RuleFor(h => h.HardSkillsValue)
                .NotEqual(s => s.SoftSkillsValue)
                .NotEqual(l => l.LanguageSkillsValue)
                .WithMessage("Invalid values");
            RuleFor(s => s.SoftSkillsValue)
                .NotEqual(l => l.LanguageSkillsValue)
                .WithMessage("SoftSkillValue can't be same as LanguageSkillsValue");
        }
    }
}
