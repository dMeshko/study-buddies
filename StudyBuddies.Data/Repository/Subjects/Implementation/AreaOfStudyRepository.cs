using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Subjects;

namespace StudyBuddies.Data.Repository.Subjects.Implementation
{
    public class AreaOfStudyRepository : RepositoryBase<AreaOfStudy>, IAreaOfStudyRepository
    {
        public AreaOfStudyRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
