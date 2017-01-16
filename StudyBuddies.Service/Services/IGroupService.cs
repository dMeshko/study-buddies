using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyBuddies.Service.ViewModels.Groups;

namespace StudyBuddies.Service.Services
{
    public interface IGroupService
    {
        GroupViewModel GetGroupById(Guid id);
        IEnumerable<GroupViewModel> GetAllGroups();
        void CreateGroup(CreateGroupViewModel group);
    }
}
