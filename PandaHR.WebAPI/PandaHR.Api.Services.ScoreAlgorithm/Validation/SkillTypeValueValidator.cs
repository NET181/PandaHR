using FluentValidation;
using PandaHR.Api.Services.ScoreAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
