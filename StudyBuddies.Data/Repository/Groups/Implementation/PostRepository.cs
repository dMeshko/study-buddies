using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Repository.Groups.Implementation
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
