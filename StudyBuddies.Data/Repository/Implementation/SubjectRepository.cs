using StudyBuddies.Domain.Models;
using StudyBuddies.Data.Infrastructure;

namespace StudyBuddies.Data.Repository.Implementation
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


    }
}
