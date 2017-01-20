using System;
using AutoMapper;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Business.ViewModels.Groups
{
    public class PostViewModel
    {
        public LookupViewModel User { get; set; }
        public LookupViewModel Group { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }

    public class PostViewModelMappingProfile : Profile
    {
        public PostViewModelMappingProfile()
        {
            CreateMap<Post, PostViewModel>();
        }
    }
}
