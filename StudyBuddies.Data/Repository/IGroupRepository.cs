using System.Collections.Generic;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Repository
{
    public interface IGroupRepository : IRepository<Group>
    {
        IEnumerable<Group> GetGroupsByName(string name);
    }

}
