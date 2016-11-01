using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyBuddies.Domain.Models;
using StudyBuddies.Web.ViewModels;

namespace StudyBuddies.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Message, SentMessageViewModel>()
                .ForMember(x => x.User, opt => opt.MapFrom(y => y.UserTo))
                .MaxDepth(1);

            CreateMap<Message, ReceivedMessageViewModel>()
                .ForMember(x => x.User, opt => opt.MapFrom(y => y.UserFrom))
                .MaxDepth(1);

            CreateMap<User, UserViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(y => $"{y.Name} {y.Surname}"));
        }
    }
}