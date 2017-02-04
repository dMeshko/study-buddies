using System;
using System.Collections.Generic;
using StudyBuddies.Business.ViewModels.Groups;
using StudyBuddies.Business.ViewModels.Users;

namespace StudyBuddies.Business.Services
{
    public interface IGroupService
    {
        #region Group

        GroupViewModel GetGroupById(Guid groupId);
        IEnumerable<GroupViewModel> GetAllGroups();
        void CreateGroup(CreateGroupViewModel group);
        void UpdateGroup(UpdateGroupViewModel group);
        void DeleteGroup(Guid groupId);

        #endregion

        #region Post

        IList<PostViewModel> GetGroupPosts(Guid groupId);

        #endregion

        #region Member

        IList<GroupRequestViewModel> GetGroupMembers(Guid groupId);
        IList<UserViewModel> GetPendingGroupMembers(Guid groupId);
        IList<UserViewModel> GetAcceptedGroupMembers(Guid groupId);
        void AddGroupMember(GroupRequestViewModel groupRequest);
        void UpdateGroupMember(GroupRequestViewModel groupRequest);

        #endregion
    }
}
