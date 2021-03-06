﻿using System;
using System.Collections.Generic;
using StudyBuddies.Business.ViewModels;
using StudyBuddies.Business.ViewModels.Groups;
using StudyBuddies.Business.ViewModels.Subjects;
using StudyBuddies.Business.ViewModels.Users;

namespace StudyBuddies.Business.Services
{
    public interface IUserService
    {
        #region User

        UserViewModel GetUserById(Guid userId);
        IEnumerable<UserViewModel> GetAllUsers();
        Guid RegisterUser(RegisterUserViewModel user);
        void Delete(Guid userId);
        void UpdateUser(UpdateUserViewModel user);
        LookupViewModel Login(LoginViewModel user);

        #endregion

        #region Conversation

        IDictionary<Guid, List<MessageViewModel>> GetAllConversations(Guid userId);
        List<MessageViewModel> GetConversation(Guid userId, Guid otherUserId);
        void SendMessage(MessageViewModel messageViewModel);

            #endregion

        #region Buddy

        List<BuddyRequestViewModel> GetAllBuddies(Guid userId);
        List<BuddyRequestViewModel> GetAllSentPendingBuddyRequests(Guid userId);
        List<BuddyRequestViewModel> GetAllReceivedPendingBuddyRequests(Guid userId);
        void SendBuddyRequest(BuddyRequestViewModel model);
        void UpdateBuddyRequest(BuddyRequestViewModel model);

            #endregion

        #region Subject

        List<EnrolledSubjectViewModel> GetEnrolledSubjects(Guid userId);
        List<SubjectViewModel> GetPassedSubjects(Guid userId);
        List<SubjectViewModel> GetCurrentSubjects(Guid userId);

        #endregion

        #region Group

        List<GroupViewModel> GetAllGroups(Guid userId);
        List<GroupViewModel> GetAllGroupsWhereNoRequestIsSent(Guid userId);
        List<GroupViewModel> GetAllManagedGroups(Guid userId);
        List<GroupViewModel> GetAllMemberingGroups(Guid userId);

        #endregion

        #region Post

        List<PostViewModel> GetLatestGroupsPosts(Guid userId);
        IList<PostViewModel> GetMineGroupsPosts(Guid userId);

        #endregion

        #region Notifications

        List<NotificationViewModel> GetAllMessageNotifications(Guid userId);
        List<NotificationViewModel> GetAllUnseenMessageNotifications(Guid userId);
        List<NotificationViewModel> GetAllBuddyNotifications(Guid userId);
        List<NotificationViewModel> GetAllUnseenBuddyNotifications(Guid userId);
        List<NotificationViewModel> GetAllGroupNotifications(Guid userid);
        List<NotificationViewModel> GetAllUnseenGroupNotifications(Guid userid);

        #endregion
        void EnrollInstitution(Guid userId, Guid institutionId);
    }
}
