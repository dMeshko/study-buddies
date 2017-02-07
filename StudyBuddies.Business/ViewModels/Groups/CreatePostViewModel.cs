using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Attributes;

namespace StudyBuddies.Business.ViewModels.Groups
{
    [Validator(typeof(CreatePostViewModelValidator))]
    public class CreatePostViewModel
    {
        public LookupViewModel User { get; set; }
        public LookupViewModel Group { get; set; }
        public string Content { get; set; }
    }

    public class CreatePostViewModelValidator : AbstractValidator<CreatePostViewModel>
    {
        public CreatePostViewModelValidator()
        {
            RuleFor(x => x.User)
                .NotEmpty();

            RuleFor(x => x.Group)
                .NotEmpty();

            RuleFor(x => x.Content)
                .NotEmpty()
                .Length(1, 255);
        }
    }
}
