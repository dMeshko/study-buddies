using System;
using AutoMapper;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Business.ViewModels.Groups
{
    public class CommentViewModel
    {
        public LookupViewModel User { get; set; }
        public LookupViewModel Post { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }

    public class CommentViewModelMappingProfile : Profile
    {
        public CommentViewModelMappingProfile()
        {
            CreateMap<Comment, CommentViewModel>();
        }
    }
}
