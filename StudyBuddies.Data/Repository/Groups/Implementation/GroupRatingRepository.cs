using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Repository.Groups.Implementation
{
    public class GroupRatingRepository : RepositoryBase<GroupRating>, IGroupRatingRepository
    {
        public GroupRatingRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
