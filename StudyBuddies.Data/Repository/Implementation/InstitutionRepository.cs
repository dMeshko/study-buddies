using System;
using System.Linq;
using NHibernate.Linq;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Repository.Implementation
{
    public class InstitutionRepository : RepositoryBase<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public University GetUniversityById(Guid id)
        {
            return Session.Query<University>()
                .FirstOrDefault(x => x.Id == id);
        }

        public void AddUniversity(University university)
        {
            Session.Save(university);
        }

        public void DeleteUniversity(University university)
        {
            Session.Delete(university);
        }
    }
}
