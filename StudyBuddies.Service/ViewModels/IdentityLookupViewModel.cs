using AutoMapper;
using StudyBuddies.Domain;

namespace StudyBuddies.Service.ViewModels
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
            
        }
    }
}
