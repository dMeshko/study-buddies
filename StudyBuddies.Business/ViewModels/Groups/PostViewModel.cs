using System;
using AutoMapper;
using StudyBuddies.Domain.Groups;
using System.Collections.Generic;

namespace StudyBuddies.Business.ViewModels.Groups
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public LookupViewModel User { get; set; }
        public LookupViewModel Group { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public List<AttachmentViewModel> Attachments { get; set; }
    }

    public class PostViewModelMappingProfile : Profile
    {
        public PostViewModelMappingProfile()
        {
            CreateMap<Post, PostViewModel>();

            CreateMap<Post, LookupViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Content));
        }
    }
}
