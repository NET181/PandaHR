using FluentValidation;
using PandaHR.Api.Models.Vacancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Validation.Vacancy
{
    public class VacancyValidator: AbstractValidator<VacancyCreationRequestModel>
    {
        public VacancyValidator()
        {
            RuleFor(v => v.UserId)
                .NotNull()
                .WithMessage("Null user id");
            RuleFor(v => v.TechnologyId)
                .NotNull()
                .WithMessage("Null technology id");
            //RuleFor(v => v.Description)
            //    .MaximumLength(255)
            //    .WithMessage("Maximum length is 255");
            RuleFor(v => v.CompanyId)
                .NotNull()
                .WithMessage("Null company id");
            RuleFor(v => v.CityId)
                .NotNull()
                .WithMessage("Null city id");
            RuleFor(v => v.SkillRequirements)
                .NotNull()
                .WithMessage("Empty skill requirements");
            RuleFor(v => v.QualificationId)
                .NotNull()
                .WithMessage("Null qualification id");
        }
    }
}
