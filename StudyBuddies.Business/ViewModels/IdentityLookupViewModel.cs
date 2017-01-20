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
            
        }
    }
}
