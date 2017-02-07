using System;
using System.Collections.Generic;
using System.Linq;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Repository.Groups.Implementation
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IList<Post> GetLatestPosts(IEnumerable<Guid> groupIds)
        {
            return GetMany(x => groupIds.Contains(x.Group.Id))
                .OrderByDescending(x => x.Date)
                .ToList();
        }
    }
}
