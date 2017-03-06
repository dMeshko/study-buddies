using FluentValidation;
using FluentValidation.Attributes;

namespace StudyBuddies.Business.ViewModels.Users
{
    [Validator(typeof(LoginViewModelValidator))]
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Invalid Password!");
        }
    }
}
