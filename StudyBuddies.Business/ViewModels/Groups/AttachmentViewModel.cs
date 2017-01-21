using AutoMapper;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Business.ViewModels.Groups
{
    public class AttachmentViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] File { get; set; }
    }

    public class AttachmentViewModelMappingProfile : Profile
    {
        public AttachmentViewModelMappingProfile()
        {
            CreateMap<Attachment, AttachmentViewModel>();
        }
    }
}
