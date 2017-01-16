using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Repository.Groups.Implementation
{
    public class GroupRequestRepository : RepositoryBase<GroupRequest>, IGroupRequestRepository
    {
        public GroupRequestRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
