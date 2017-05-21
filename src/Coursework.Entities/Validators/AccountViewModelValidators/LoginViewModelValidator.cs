using Coursework.Entities.ViewModels;
using FluentValidation;

namespace Coursework.Entities.Validators.AccountViewModelValidators
{
  public class LoginViewModelValidator: AbstractValidator<LoginViewModel>
  {
    public LoginViewModelValidator()
    {
      RuleFor(r => r.Username).NotEmpty()
          .WithMessage("Invalid username");

      RuleFor(r => r.Password).NotEmpty()
          .WithMessage("Invalid password");
    }
  }
}