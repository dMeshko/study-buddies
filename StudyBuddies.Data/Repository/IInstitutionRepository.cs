using System;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Repository
{
    public interface IInstitutionRepository : IRepository<Institution>
    {
        University GetUniversityById(Guid id);
        void AddUniversity(University university);
        void DeleteUniversity(University university);
    }
}
