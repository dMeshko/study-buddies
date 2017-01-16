using System;
using StudyBuddies.Service.Infrastructure;
using StudyBuddies.Service.ViewModels.Institutions;

namespace StudyBuddies.Service.Services
{
    public interface IInstitutionService
    {
        void CreateInstitution(InstitutionViewModel institutionViewModel);
    }
}
