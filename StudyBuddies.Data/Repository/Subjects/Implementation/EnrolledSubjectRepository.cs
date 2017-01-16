using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Subjects;

namespace StudyBuddies.Data.Repository.Subjects.Implementation
{
    public class EnrolledSubjectRepository : RepositoryBase<EnrolledSubject>, IEnrolledSubjectRepository
    {
        public EnrolledSubjectRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    }
}
