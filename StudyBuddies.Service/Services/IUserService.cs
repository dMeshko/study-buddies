using System;
using System.Collections.Generic;
using StudyBuddies.Domain.Users;
using StudyBuddies.Service.Infrastructure;
using StudyBuddies.Service.ViewModels;
using StudyBuddies.Service.ViewModels.Users;

namespace StudyBuddies.Service.Services
{
    public interface IUserService
    {
        UserViewModel GetUserById(Guid id);
        IEnumerable<UserViewModel> GetAllUsers();
        void RegisterUser(RegisterUserViewModel user);
        void AddFriend(Guid currentUserId, Guid buddyId);
        void SendMessage(MessageViewModel messageViewModel);
        IDictionary<Guid, List<MessageViewModel>> GetAllConversations(Guid userId);
        void GetConversation(MessageViewModel messageViewModel);
        void EnrollInstitution(Guid userId, Guid institutionId);
        void Delete(Guid id);
    }
}
