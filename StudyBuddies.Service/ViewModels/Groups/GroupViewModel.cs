using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudyBuddies.Domain.Groups;
using StudyBuddies.Service.ViewModels.Users;

namespace StudyBuddies.Service.ViewModels.Groups
{
    public class GroupViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserViewModel Admin { get; set; }
        public int OccupiedCapacity { get; set; }
        public int GroupCapacity { get; set; }
        public IdentityLookupViewModel Status { get; set; }
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
