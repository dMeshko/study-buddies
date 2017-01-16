using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Institutions;

namespace StudyBuddies.Data.Repository.Institutions.Implementation
{
    public class FacultyRepository : RepositoryBase<Faculty>, IFacultyRepository
    {
        public FacultyRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
