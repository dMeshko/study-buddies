using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Business.ViewModels.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string CoverImage { get; set; }
        public string Image { get; set; }
        public double Rating { get; set; }
        public IList<LookupViewModel> Institutions { get; set; }
    }

    public class UserViewModelMappingProfile : Profile
    {
        public UserViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(y => $"{y.Name} {y.Surname}"))
                .ForMember(x => x.CoverImage, opt => opt.MapFrom(y => Convert.ToBase64String(y.CoverImage)))
                .ForMember(x => x.Image, opt => opt.MapFrom(y => Convert.ToBase64String(y.Image)))
                .ForMember(x => x.Institutions, opt => opt.MapFrom(y => y.EnrolledInstitutions.Select(x => x.Institution)));

            CreateMap<User, LookupViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(y => $"{y.Name} {y.Surname}"));
        }
    }
}
