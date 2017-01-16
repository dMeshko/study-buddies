using AutoMapper;
using FluentValidation;
using FluentValidation.Attributes;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Service.ViewModels.Groups
{
    [Validator(typeof(CreateGroupViewModelValidator))]
    public class CreateGroupViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int GroupCapacity { get; set; }
        public LookupViewModel Admin { get; set; }
        public LookupViewModel Subject { get; set; }
    }

    public class CreateGroupViewModelValidator : AbstractValidator<CreateGroupViewModel>
    {
        public CreateGroupViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 255);

            RuleFor(x => x.GroupCapacity)
                .NotEmpty();

            RuleFor(x => x.Admin)
                .NotEmpty();

            RuleFor(x => x.Subject)
                .NotEmpty();
        }
    }
}
