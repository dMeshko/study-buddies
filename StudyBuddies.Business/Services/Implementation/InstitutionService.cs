using StudyBuddies.Business.ViewModels.Institutions;
using StudyBuddies.Data.Repository.Institutions;
using StudyBuddies.Domain.Institutions;

namespace StudyBuddies.Business.Services.Implementation
{
    public class InstitutionService : IInstitutionService
    {
        private readonly IInstitutionRepository _institutionRepository;

        public InstitutionService(IInstitutionRepository institutionRepository)
        {
            _institutionRepository = institutionRepository;
        }

        public void CreateInstitution(InstitutionViewModel institutionViewModel)
        {
            var institution = new Academy(institutionViewModel.Name);
            _institutionRepository.Add(institution);
            //called form the admin panel, CREATES NEW INSTITUTION!!

            //Institution institution = null;
            //if (institutionViewModel.Type == InstitutionType.Academy)
            //{
            //    institution = new Academy(institutionViewModel.Name);
            //}
            //else
            //{
            //    institution = new Faculty(institutionViewModel.Name, _institutionRepository.GetUniversityById(institutionViewModel.UniversityId));
            //}
            //foreach (var location in institutionViewModel.Locations)
            //{
            //    var loc = _institutionRepository.GetLocationById(location.Id);
            //    institution.AddLocation(loc);
            //}
        }
    }
}
