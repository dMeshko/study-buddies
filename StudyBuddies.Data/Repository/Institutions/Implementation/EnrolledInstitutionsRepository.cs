using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Institutions;

namespace StudyBuddies.Data.Repository.Institutions.Implementation
{
    public class EnrolledInstitutionsRepository : RepositoryBase<EnrolledInstitution>, IEnrolledInstitutionsRepository
    {
        public EnrolledInstitutionsRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
