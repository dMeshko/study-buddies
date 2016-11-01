using System;
using StudyBuddies.Domain.Models;
using System.Collections.Generic;
using StudyBuddies.Data.Infrastructure;

namespace StudyBuddies.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
        void SaveMessage(Message message);
        IEnumerable<Message> GetAllConversations(User user);
        IEnumerable<Message> GetConversation(User userFrom, User userTo);
        IEnumerable<User> GetFriends(User user);
        void SaveOrUpdateFriendRequest(Friendship friendship);
        Friendship GetFriendship(User userFrom, User userTo);
        void RemoveFriend(Friendship friendship);
        void SaveOrUpdateSubject(UserSubject userSubject);
        UserSubject GetUserSubject(User user, Subject subject);
        UserGroup GetUserGroup(Group group, User user);
        void SaveOrUpdateUserGroup(UserGroup userGroup);
        void SaveOrUpdateGroupRating(GroupRating groupRating);
        void SaveOrUpdateUserAttendsInstitution(UserAttendsInstitution userAttendsInstitution);
    }
}
