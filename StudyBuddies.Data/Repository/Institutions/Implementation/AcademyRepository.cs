using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Institutions;

namespace StudyBuddies.Data.Repository.Institutions.Implementation
{
    public class AcademyRepository : RepositoryBase<Academy>, IAcademyRepository
    {
        public AcademyRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
