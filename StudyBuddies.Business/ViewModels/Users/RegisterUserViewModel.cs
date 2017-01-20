using AutoMapper;
using FluentValidation;
using FluentValidation.Attributes;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Business.ViewModels.Users
{
    [Validator(typeof(RegisterUserViewModelValidator))]
    public class RegisterUserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserViewModelValidator : AbstractValidator<RegisterUserViewModel>
    {
        public RegisterUserViewModelValidator()
        {
            RuleFor(x => x.Name)
                .Length(1, 255)
                .NotEmpty();

            RuleFor(x => x.Surname)
                .Length(1, 255)
                .NotEmpty();

            RuleFor(x => x.Email)
                .Length(1, 255)
                .NotEmpty();

            RuleFor(x => x.Password)
                .Length(1, 255)
                .NotEmpty();
        }
    }

    public class RegisterUserViewModelMappingProfile : Profile
    {
        public RegisterUserViewModelMappingProfile()
        {
            CreateMap<RegisterUserViewModel, User>();
        }
    }
}
