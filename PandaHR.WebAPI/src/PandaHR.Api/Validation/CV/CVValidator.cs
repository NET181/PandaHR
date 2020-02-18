using FluentValidation;
using PandaHR.Api.Models.CV;

namespace PandaHR.Api.Validation.CV
{
    public class CVValidator : AbstractValidator<CVCreationRequestModel>
    {
        public CVValidator()
        {
            RuleFor(c => c.Summary)
                .MaximumLength(255)
                .WithMessage("Max length is 255");
            RuleFor(c => c.User.Email).NotEmpty()
                .When(c => c.User.Phone == null)
                .EmailAddress()
                .WithMessage("Email is required");
            RuleFor(c => c.User.Phone)
                .NotEmpty()
                .When(c => c.User.Email == null)
                .Length(10, 13)
                .WithMessage("Invalid phone number");
            RuleFor(c => c.User.FirstName)
                .NotEmpty()
                .WithMessage("First name is required");
            RuleFor(c => c.User.SecondName)
                .NotEmpty()
                .WithMessage("Second name is required");
        }
    }
}
