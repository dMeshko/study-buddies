using System;
using System.Linq;
using NHibernate.Linq;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Institutions;

namespace StudyBuddies.Data.Repository.Institutions.Implementation
{
    public class InstitutionRepository : RepositoryBase<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        
    }
}
