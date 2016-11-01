using StudyBuddies.Domain.Models;
using System;
using System.Collections.Generic;
using StudyBuddies.Service.Infrastructure;

namespace StudyBuddies.Service.Services
{
    public interface IUserService : IService<User>
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(Guid id);
        User GetUserByUsername(string username);
        void SendMessage(User userFrom, User userTo, string content);
        IEnumerable<Message> GetConversation(User userFrom, User userTo);
        IEnumerable<Message> GetAllConversations(User user);
        IEnumerable<User> GetFriends(User user);
        bool GetFriendshipStatus(User userFrom, User userTo);
        void SendFriendRequest(User userFrom, User userTo);
        void AcceptFriend(User userFrom, User userTo);
        void RemoveFriend(User userFrom, User userTo);
        void EnrollSubject(User user, Subject subject);
        void PassSubject(User user, Subject subject, int grade);
        void CreateGroup(User user, Subject subject, string groupName, int maxMembers);
        void JoinGroup(Group group, User user);
        Group GetGroupById(Guid id);
        IEnumerable<Group> GetGroupsByName(string groupName);
        void AcceptGroupMember(Group group, User user);
        void RateGroupMember(User userFrom, User userTo, Group group, int grade);
        void EnrollStudent(User user, Institution institution, DateTime startDate);
        void EnrollGraduatedStudent(User user, Institution institution, DateTime startDate, DateTime endDate);
    }
}
