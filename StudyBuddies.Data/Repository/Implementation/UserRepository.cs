using StudyBuddies.Domain.Models;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq;
using System;
using StudyBuddies.Data.Infrastructure;

namespace StudyBuddies.Data.Repository.Implementation
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public User GetUserByUsername(string username)
        {
            return Get(x => x.Username == username);
        }

        public void SaveMessage(Message message)
        {
            Session.Save(message);
        }

        public IEnumerable<Message> GetAllConversations(User user)
        {
            /*(SELECT DISTINCT TOP 1000[m].[UserTo_id]
            FROM[StudyBuddiesDb].[dbo].[Message] as [m]
            WHERE[m].[UserFrom_id] = 'EF543716-D87B-451F-AFBD-A6A9014F3EC0')
            UNION
            (SELECT DISTINCT TOP 1000[m].[UserFrom_id]
            FROM[StudyBuddiesDb].[dbo].[Message] as [m]
            WHERE[m].[UserTo_id] = 'EF543716-D87B-451F-AFBD-A6A9014F3EC0')*/
            return null;
        }

        public IEnumerable<Message> GetConversation(User userFrom, User userTo)
        {
            var query = Session.Query<Message>()
                     .Where(x => x.UserFrom.Id == userFrom.Id || x.UserTo.Id == userFrom.Id)
                     .Where(x => x.UserFrom.Id == userTo.Id || x.UserTo.Id == userTo.Id)
                     .OrderBy(x => x.Date);

            return query.ToList();
        }

        public IEnumerable<User> GetFriends(User user)
        {
            var queryAcceptedFriends = Session.Query<Friendship>()
                .Where(x => x.Status == true)
                .Where(x => x.UserTo.Id == user.Id)
                .Select(x => x.UserFrom);

            var queryReqestedFriends = Session.Query<Friendship>()
                .Where(x => x.Status == true)
                .Where(x => x.UserFrom.Id == user.Id)
                .Select(x => x.UserTo);

            var queryFriends = queryAcceptedFriends.Union<User>(queryReqestedFriends);

            return queryFriends.ToList<User>();
        }

        public void SaveOrUpdateFriendRequest(Friendship friendship)
        {
            Session.SaveOrUpdate(friendship);
        }

        public Friendship GetFriendship(User userFrom, User userTo)
        {
            return Session.Query<Friendship>().SingleOrDefault(x => (x.UserFrom == userFrom && x.UserTo == userTo) || (x.UserFrom == userTo && x.UserTo == userFrom));
        }

        public void RemoveFriend(Friendship friendship)
        {
            Session.Delete(friendship);
        }

        public void SaveOrUpdateSubject(UserSubject userSubject)
        {
            Session.SaveOrUpdate(userSubject);
        }

        public UserSubject GetUserSubject(User user, Subject subject)
        {
            return Session
                .Query<UserSubject>()
                .SingleOrDefault(x => x.User == user && x.Subject == subject);
        }

        public UserGroup GetUserGroup(Group group, User user)
        {
            return Session
                .Query<UserGroup>()
                .FirstOrDefault(x => x.Group == group && x.User == user);
        }

        public void SaveOrUpdateUserGroup(UserGroup userGroup)
        {
            Session.SaveOrUpdate(userGroup);
        }

        public void SaveOrUpdateGroupRating(GroupRating groupRating)
        {
            Session.SaveOrUpdate(groupRating);
        }

        public void SaveOrUpdateUserAttendsInstitution(UserAttendsInstitution userAttendsInstitution)
        {
            Session.Save(userAttendsInstitution);
        }
    }
}
