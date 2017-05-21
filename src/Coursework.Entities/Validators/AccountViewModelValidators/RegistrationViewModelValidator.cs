using Coursework.Entities.ViewModels;
using FluentValidation;

namespace Coursework.Entities.Validators.AccountViewModelValidators
{
  public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
  {
    public RegistrationViewModelValidator()
    {
      RuleFor(r => r.Email).NotEmpty().EmailAddress()
          .WithMessage("Invalid email address");

      RuleFor(r => r.Username).NotEmpty()
          .WithMessage("Invalid username");

      RuleFor(r => r.Password).NotEmpty()
          .WithMessage("Invalid password");
    }
  }
}