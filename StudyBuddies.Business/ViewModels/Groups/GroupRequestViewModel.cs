using AutoMapper;
using FluentValidation;
using FluentValidation.Attributes;
using StudyBuddies.Domain;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Business.ViewModels.Groups
{
    [Validator(typeof(GroupRequestViewModelValidator))]
    public class GroupRequestViewModel
    {
        public LookupViewModel User { get; set; }
        public LookupViewModel Group { get; set; }
        public IdentityLookupViewModel Status { get; set; }
    }

    public class GroupRequestViewModelValidator : AbstractValidator<GroupRequestViewModel>
    {
        public GroupRequestViewModelValidator()
        {
            RuleFor(x => x.User)
                .NotEmpty();

            RuleFor(x => x.Group)
                .NotEmpty();
        }
    }

    public class GroupRequestViewModelMappingProfile : Profile
    {
        public GroupRequestViewModelMappingProfile()
        {
            CreateMap<GroupRequest, GroupRequestViewModel>();

            CreateMap<RequestStatus, IdentityLookupViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => (int)y))
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.ToString()));
        }
    }
}
