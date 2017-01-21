using FluentValidation;
using FluentValidation.Attributes;

namespace StudyBuddies.Business.ViewModels.Groups
{
    [Validator(typeof(CreateCommentViewModelValidator))]
    public class CreateCommentViewModel
    {
        public LookupViewModel User { get; set; }
        public LookupViewModel Post { get; set; }
        public string Content { get; set; }
    }

    public class CreateCommentViewModelValidator : AbstractValidator<CreateCommentViewModel>
    {
        public CreateCommentViewModelValidator()
        {
            RuleFor(x => x.User)
                .NotEmpty();

            RuleFor(x => x.Post)
                .NotEmpty();

            RuleFor(x => x.Content)
                .NotEmpty()
                .Length(1, 255);
        }
    }
}
