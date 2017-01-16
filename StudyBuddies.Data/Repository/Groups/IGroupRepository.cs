using System.Collections.Generic;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Repository.Groups
{
    public interface IGroupRepository : IRepository<Group>
    {
        IEnumerable<Group> GetGroupsByName(string name);
    }
}
