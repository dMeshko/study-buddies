using System.Collections.Generic;
using AutoMapper;
using StudyBuddies.Domain.Institutions;

namespace StudyBuddies.Business.ViewModels.Institutions
{
    public class InstitutionViewModel
    {
        public string Name { get; set; }
        //public IList<LookupViewModel> Locations { get; set; }
        public InstitutionType Type { get; set; }
    }

    public enum InstitutionType
    {
        Faculty = 0,
        Academy = 1
    }

    public class InstitutionViewModelMappingProfile : Profile
    {
        public InstitutionViewModelMappingProfile()
        {
            CreateMap<Institution, InstitutionViewModel>();
            //    .ForMember(x => x.Locations, opt => opt.MapFrom(y => y.Locations));

            CreateMap<Institution, LookupViewModel>();

            CreateMap<Location, LookupViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(y => $"{y.Address}, {y.City}, {y.Country}"));
        }
    }
}
