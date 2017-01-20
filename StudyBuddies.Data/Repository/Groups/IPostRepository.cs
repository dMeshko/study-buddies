using System;
using System.Collections.Generic;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Repository.Groups
{
    public interface IPostRepository : IRepository<Post>
    {
        IList<Post> GetLatestPosts(IEnumerable<Guid> groupIds);
    }
}
