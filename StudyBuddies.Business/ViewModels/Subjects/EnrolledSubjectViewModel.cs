using AutoMapper;
using StudyBuddies.Domain;
using StudyBuddies.Domain.Subjects;

namespace StudyBuddies.Business.ViewModels.Subjects
{
    public class EnrolledSubjectViewModel
    {
        public LookupViewModel User { get; set; }
        public LookupViewModel Subject { get; set; }
        public IdentityLookupViewModel Status { get; set; }
        public int? Grade { get; set; }
    }

    public class EnrolledSubjectViewModelMappingProfile : Profile
    {
        public EnrolledSubjectViewModelMappingProfile()
        {
            CreateMap<EnrolledSubject, EnrolledSubjectViewModel>();

            CreateMap<SubjectStatus, IdentityLookupViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => (int)y))
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.ToString()));
        }
    }
}
