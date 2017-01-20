using StudyBuddies.Business.ViewModels.Institutions;

namespace StudyBuddies.Business.Services
{
    public interface IInstitutionService
    {
        void CreateInstitution(InstitutionViewModel institutionViewModel);
    }
}
