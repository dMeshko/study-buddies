using System;
using AutoMapper;
using FluentValidation;
using StudyBuddies.Domain;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Business.ViewModels.Users
{
    public class BuddyRequestViewModel
    {
        public LookupViewModel UserFrom { get; set; }
        public LookupViewModel UserTo { get; set; }
        public DateTime Date { get; set; }
        public IdentityLookupViewModel Status { get; set; }
    }

    public class BuddyRequestViewModelValidator : AbstractValidator<BuddyRequestViewModel>
    {
        public BuddyRequestViewModelValidator()
        {
            RuleFor(x => x.UserFrom)
                .NotEmpty();

            RuleFor(x => x.UserTo)
                .NotEmpty();
        }
    }

    public class BuddyRequestViewModelMappingProfile : Profile
    {
        public BuddyRequestViewModelMappingProfile()
        {
            CreateMap<BuddyRequest, BuddyRequestViewModel>();
        }
    }
}
