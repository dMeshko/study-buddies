using System;
using System.Collections.Generic;
using StudyBuddies.Domain.Models;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Data.Repository;
using StudyBuddies.Service.Infrastructure;
using StudyBuddies.Service.Infrastructure.Exceptions;

namespace StudyBuddies.Service.Services.Implementation
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IInstitutionRepository _institutionRepository;

        public UserService(IRepository<User> userRepository, IGroupRepository groupRepository, ISubjectRepository subjectRepository, IInstitutionRepository institutionRepository) : base(userRepository)
        {
            _userRepository = (IUserRepository)userRepository;
            _groupRepository = groupRepository;
            _subjectRepository = subjectRepository;
            _institutionRepository = institutionRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(Guid id)
        {
            User user = _userRepository.GetById(id);

            if (user == null)
                throw new NotFoundException("There is no such user in the database!");

            return user;
        }

        public User GetUserByUsername(string username)
        {
            User user = _userRepository.GetUserByUsername(username);

            if (user == null)
                throw new NotFoundException("There is no such user in the database!");

            return user;
        }

        public void SendMessage(User userFrom, User userTo, string content)
        {
            if (userFrom == null || userTo == null || _userRepository.GetById(userFrom.Id) == null
                || _userRepository.GetById(userTo.Id) == null)
                throw new NotFoundException("Invalid users!");

            GetFriendshipStatus(userFrom, userTo);

            Message message = new Message { UserFrom = userFrom, UserTo = userTo, Content = content, Date = DateTime.Now };
            _userRepository.SaveMessage(message);
        }

        public IEnumerable<Message> GetConversation(User userFrom, User userTo)
        {
            if (userFrom == null || userTo == null || _userRepository.GetById(userFrom.Id) == null
                || _userRepository.GetById(userTo.Id) == null)
                throw new NotFoundException("Invalid users!");

            //do i wanna return empty list of conversation or notFoundException?

            return _userRepository.GetConversation(userFrom, userTo);
        }

        public IEnumerable<User> GetFriends(User user)
        {
            if (user == null || _userRepository.GetById(user.Id) == null)
                throw new NotFoundException("Invalid user!");

            return _userRepository.GetFriends(user);
        }

        public bool GetFriendshipStatus(User userFrom, User userTo)
        {
            if (userFrom == null || userTo == null || _userRepository.GetById(userFrom.Id) == null
                || _userRepository.GetById(userTo.Id) == null)
                throw new NotFoundException("Invalid users!");

            Friendship friendship = _userRepository.GetFriendship(userFrom, userTo);
            if (friendship == null)
                throw new NotFoundException("No such friendship found in the system!");

            return friendship.Status;
        }

        public IEnumerable<Message> GetAllConversations(User user)
        {
            if (user == null || _userRepository.GetById(user.Id) == null)
                throw new NotFoundException("Invalid user!");

            return _userRepository.GetAllConversations(user);
        }

        public void SendFriendRequest(User userFrom, User userTo)
        {
            if (userFrom == null || userTo == null || _userRepository.GetById(userFrom.Id) == null
                || _userRepository.GetById(userTo.Id) == null)
                throw new NotFoundException("Invalid users!");

            Friendship friendship = new Friendship { UserFrom = userFrom, UserTo = userTo, Date = DateTime.Now, Status = false };
            _userRepository.SaveOrUpdateFriendRequest(friendship);
        }

        public void AcceptFriend(User userFrom, User userTo) //try to access the friends directly!
        {
            if (userFrom == null || userTo == null || _userRepository.GetById(userFrom.Id) == null
                || _userRepository.GetById(userTo.Id) == null)
                throw new NotFoundException("Invalid users!");

            Friendship friendship = _userRepository.GetFriendship(userFrom, userTo);
            if (friendship == null)
                throw new NotFoundException("No such friend request found in the system!");

            friendship.Status = true;
            _userRepository.SaveOrUpdateFriendRequest(friendship);
        }

        public void RemoveFriend(User userFrom, User userTo)
        {
            if (userFrom == null || userTo == null || _userRepository.GetById(userFrom.Id) == null 
                || _userRepository.GetById(userTo.Id) == null)
                throw new NotFoundException("Invalid users!");

            Friendship friendship = _userRepository.GetFriendship(userFrom, userTo);
            if (friendship == null)
                throw new NotFoundException("No such friendship found in the system!");

            if (friendship.Status == false)
                throw new BusinessLayerException("The users are not friends yet!");

            _userRepository.RemoveFriend(friendship);
        }

        public void EnrollSubject(User user, Subject subject)
        {
            if (user == null || _userRepository.GetById(user.Id) == null)
                throw new NotFoundException("Invalid user!");

            if (subject == null || _subjectRepository.GetById(subject.Id) == null)
                throw new NotFoundException("Invalid subject!");

            // do i want to check if the suject is being supported/offered by the institution?

            UserSubject userSubject = new UserSubject { User = user, Subject = subject, Grade = 0, Passed = false };
            _userRepository.SaveOrUpdateSubject(userSubject);
        }

        public void PassSubject(User user, Subject subject, int grade)
        {
            if (user == null || _userRepository.GetById(user.Id) == null)
                throw new NotFoundException("Invalid user!");

            if (subject == null || _subjectRepository.GetById(subject.Id) == null)
                throw new NotFoundException("Invalid subject!");

            if (grade <= 5)
                throw new BusinessLayerException("Invalid grade!");

            UserSubject userSubject = _userRepository.GetUserSubject(user, subject);
            if (userSubject == null)
                throw new NotFoundException("The user has not enrolled this subject!");

            userSubject.Passed = true;
            userSubject.Grade = grade;
            _userRepository.SaveOrUpdateSubject(userSubject);
        }

        public void CreateGroup(User user, Subject subject, string groupName, int maxMembers)
        {
            if (user == null || _userRepository.GetById(user.Id) == null)
                throw new NotFoundException("Invalid user!");

            if (subject == null || _subjectRepository.GetById(subject.Id) == null)
                throw new NotFoundException("Invalid subject!");

            if (groupName.Trim().Length == 0)
                throw new BusinessLayerException("Invalid group name!");

            Group group = new Group
            {
                Creator = user,
                CreatedOn = DateTime.Now,
                Subject = subject,
                Name = groupName,
                MaxNumberOfMembers = maxMembers,
                ExpireDate = DateTime.Now.AddDays(7) // the default expiration date is a week from today
            };

            _groupRepository.Add(group);
        }

        public void JoinGroup(Group group, User user)
        {
            if (user == null || _userRepository.GetById(user.Id) == null)
                throw new NotFoundException("Invalid user!");

            if (group == null || _groupRepository.GetById(group.Id) == null)
                throw new NotFoundException("Invalid group!");

            UserGroup userGroup = new UserGroup { Group = group, User = user, Status = false};
            _userRepository.SaveOrUpdateUserGroup(userGroup);
        }

        public Group GetGroupById(Guid id)
        {
            Group group = _groupRepository.GetById(id);
            if (group == null)
                throw new NotFoundException("There is no such group in the system.");

            return group;
        }

        public IEnumerable<Group> GetGroupsByName(string groupName)
        {
            if (groupName.Trim().Length == 0)
                throw new BusinessLayerException("Invalid group name!");

            return _groupRepository.GetGroupsByName(groupName);
        }

        public void AcceptGroupMember(Group group, User user)
        {
            if (user == null || _userRepository.GetById(user.Id) == null)
                throw new NotFoundException("Invalid user!");

            if (group == null || _groupRepository.GetById(group.Id) == null)
                throw new NotFoundException("Invalid group!");

            UserGroup userGroup = _userRepository.GetUserGroup(group, user);
            if (userGroup == null)
                throw new NotFoundException("There is no pending group acceptance request for the given user and group.");

            userGroup.Status = true;
            _userRepository.SaveOrUpdateUserGroup(userGroup);
        }

        #region private method
        private bool UsersInSameGroup(User userFrom, User userTo, Group group)
        {
            // this could have been fixed in more OOP way, but it's fine for now
            UserGroup userGroup1 = _userRepository.GetUserGroup(group, userFrom);
            UserGroup userGroup2 = _userRepository.GetUserGroup(group, userTo);

            if (userGroup1 == null || userGroup2 == null
                || userGroup1.Status == false || userGroup2.Status == false)
                return false;

            return true;
        }
        #endregion

        public void RateGroupMember(User userFrom, User userTo, Group group, int grade)
        {
            if (userFrom == null || userTo == null || _userRepository.GetById(userFrom.Id) == null
                || _userRepository.GetById(userTo.Id) == null)
                throw new NotFoundException("Invalid users!");

            if (group == null || _groupRepository.GetById(group.Id) == null)
                throw new NotFoundException("Invalid group!");

            if (grade > 5 || grade < 1)
                throw new BusinessLayerException("Invalid user rating grade!  It has to be value between 1 and 5");

            if (UsersInSameGroup(userFrom, userTo, group) == false)
                throw new BusinessLayerException("The users are not part of the same group!");

            GroupRating groupRating = new GroupRating { UserFrom = userFrom, UserTo = userTo, Group = group, Date = DateTime.Now, Grade = grade};
            _userRepository.SaveOrUpdateGroupRating(groupRating);
        }

        public void EnrollStudent(User user, Institution institution, DateTime startDate)
        {
            if (user == null || _userRepository.GetById(user.Id) == null)
                throw new NotFoundException("Invalid user!");

            if (user == null || _institutionRepository.GetById(institution.Id) == null)
                throw new NotFoundException("Invalid institution!");

            UserAttendsInstitution studentEnrollemnt = new UserAttendsInstitution
            {
                User = user,
                Institution = institution,
                StartDate = startDate
            };

            _userRepository.SaveOrUpdateUserAttendsInstitution(studentEnrollemnt);
        }

        public void EnrollGraduatedStudent(User user, Institution institution, DateTime startDate, DateTime endDate)
        {
            if (user == null || _userRepository.GetById(user.Id) == null)
                throw new NotFoundException("Invalid user!");

            if (user == null || _institutionRepository.GetById(institution.Id) == null)
                throw new NotFoundException("Invalid institution!");

            if (endDate.CompareTo(startDate) <= 0)
                throw new BusinessLayerException("The graduation date can't be before or the same as the enrollment date!");

            UserAttendsInstitution studentEnrollemnt = new UserAttendsInstitution
            {
                User = user,
                Institution = institution,
                StartDate = startDate,
                EndDate = endDate
            };

            _userRepository.SaveOrUpdateUserAttendsInstitution(studentEnrollemnt);
        }
    }
}
