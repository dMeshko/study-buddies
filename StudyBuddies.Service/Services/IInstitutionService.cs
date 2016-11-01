using System;
using StudyBuddies.Domain.Models;
using StudyBuddies.Service.Infrastructure;

namespace StudyBuddies.Service.Services
{
    public interface IInstitutionService : IService<Institution>
    {
        void CreateSubject(Subject subject);
        void CreateInstitution(Institution institution);
        University GetUniversityById(Guid id);
        void CreateUniversity(University university);
        void RemoveUniversity(University university);
    }
}
