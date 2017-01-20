using AutoMapper;
using FluentValidation;
using FluentValidation.Attributes;
using StudyBuddies.Domain.Subjects;

namespace StudyBuddies.Business.ViewModels.Subjects
{
    [Validator(typeof(SubjectViewModelValidator))]
    public class SubjectViewModel
    {
        public string Name { get; set; }
        public LookupViewModel AreaOfStudy { get; set; }
    }

    public class SubjectViewModelValidator : AbstractValidator<SubjectViewModel>
    {
        public SubjectViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 255);

            RuleFor(x => x.AreaOfStudy)
                .NotEmpty();
        }
    }

    public class SubjectViewModelMappingProfile : Profile
    {
        public SubjectViewModelMappingProfile()
        {
            CreateMap<AreaOfStudy, LookupViewModel>();

            CreateMap<Subject, SubjectViewModel>();
        }
    }
}
