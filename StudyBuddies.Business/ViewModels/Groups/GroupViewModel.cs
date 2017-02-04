using System;
using AutoMapper;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Business.ViewModels.Groups
{
    public class GroupViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LookupViewModel Admin { get; set; }
        public int OccupiedCapacity { get; set; }
        public int GroupCapacity { get; set; }
        public IdentityLookupViewModel Status { get; set; }
        public LookupViewModel Subject { get; set; }
    }

    public class GroupViewModelMappingProfile : Profile
    {
        public GroupViewModelMappingProfile()
        {
            CreateMap<Group, GroupViewModel>()
                .ForMember(x => x.OccupiedCapacity, opt => opt.MapFrom(y => y.AcceptedMembers.Count));

            CreateMap<Group, LookupViewModel>();
        }
    }
}
