using System;
using AutoMapper;

namespace StudyBuddies.Business.ViewModels
{
    public class IdentityLookupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class IdentityLookupViewModelMappingProfile : Profile
    {
        public IdentityLookupViewModelMappingProfile()
        {
            CreateMap<Enum, IdentityLookupViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => Convert.ToInt32(y)))
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.ToString()));
        }
    }
}
