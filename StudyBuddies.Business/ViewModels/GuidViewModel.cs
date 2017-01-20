using System;
using FluentValidation;
using FluentValidation.Attributes;

namespace StudyBuddies.Business.ViewModels
{
    [Validator(typeof(GuidViewModelValidator))]
    public class GuidViewModel
    {
        public Guid Id { get; set; }
    }

    public class GuidViewModelValidator : AbstractValidator<GuidViewModel>
    {
        public GuidViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
