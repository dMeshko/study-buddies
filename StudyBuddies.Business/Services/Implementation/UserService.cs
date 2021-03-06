﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using StudyBuddies.Business.Infrastructure.Exceptions;
using StudyBuddies.Business.Infrastructure.Exceptions.Messages;
using StudyBuddies.Business.ViewModels;
using StudyBuddies.Business.ViewModels.Groups;
using StudyBuddies.Business.ViewModels.Subjects;
using StudyBuddies.Business.ViewModels.Users;
using StudyBuddies.Data.Repository.Groups;
using StudyBuddies.Data.Repository.Institutions;
using StudyBuddies.Data.Repository.Users;
using StudyBuddies.Domain;
using StudyBuddies.Domain.Groups;
using StudyBuddies.Domain.Institutions;
using StudyBuddies.Domain.Subjects;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Business.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBuddyRequestRepository _buddyRequestRepository;
        private readonly IInstitutionRepository _institutionRepository;
        private readonly IPostRepository _postRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupRequestRepository _groupRequestRepository;

        public UserService(IUserRepository userRepository, IBuddyRequestRepository buddyRequestRepository, IInstitutionRepository institutionRepository, IPostRepository postRepository, IGroupRepository groupRepository, IGroupRequestRepository groupRequestRepository)
        {
            _userRepository = userRepository;
            _buddyRequestRepository = buddyRequestRepository;
            _institutionRepository = institutionRepository;
            _postRepository = postRepository;
            _groupRepository = groupRepository;
            _groupRequestRepository = groupRequestRepository;
        }

        #region User

        public UserViewModel GetUserById(Guid userid)
        {
            var user = _userRepository.GetById(userid);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            return Mapper.Map<User, UserViewModel>(user);
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
        }

        public Guid RegisterUser(RegisterUserViewModel user)
        {
            if (user == null)
                throw new BusinessLayerException(AppExceptionMessage.INVALID_INTERNAL_STATE);

            //var dboUser = Mapper.Map<RegisterUserViewModel, User>(user);
            var dboUser = new User(user.Name, user.Surname, user.Email, user.Password);
            _userRepository.Add(dboUser);
            return dboUser.Id;
        }

        public void Delete(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            _userRepository.Delete(user);
        }

        public void UpdateUser(UpdateUserViewModel user)
        {
            throw new NotImplementedException();
        }

        public LookupViewModel Login(LoginViewModel user)
        {
            var userDbo = _userRepository.Get(x => x.Email == user.Email && x.Password == user.Password);
            if (userDbo == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            return Mapper.Map<User, LookupViewModel>(userDbo);
        }

        #endregion

        #region Conversatoin

        public IDictionary<Guid, List<MessageViewModel>> GetAllConversations(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var messages = user.Messages;
            return Mapper.Map<IDictionary<Guid, List<Message>>, IDictionary<Guid, List<MessageViewModel>>>(messages);
        }

        public List<MessageViewModel> GetConversation(Guid userId, Guid otherUserId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            if (!user.Messages.ContainsKey(otherUserId))
                throw new NotFoundException(ConversationExceptionMessage.CONVERSATION_NOT_FOUND);

            var messages = user.Messages[otherUserId];
            return Mapper.Map<List<Message>, List<MessageViewModel>>(messages);
        }

        public void SendMessage(MessageViewModel messageViewModel)
        {
            var currentUser = _userRepository.GetById(messageViewModel.UserFromId);
            var otherUser = _userRepository.GetById(messageViewModel.UserToId);

            if (currentUser == null || otherUser == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var message = new Message(currentUser, otherUser, messageViewModel.Content);
            currentUser.SendMessage(message);
            _userRepository.Update(currentUser);
        }

        public IList<PostViewModel> GetMineGroupsPosts(Guid userId)
        {
            //var posts = _postRepository.GetAll().Where(x => x.User.Id == userId).ToList();
            var posts = from post in _postRepository.GetAll()
                where post.User.Id == userId
                select post;
            return Mapper.Map<IList<Post>, IList<PostViewModel>>(posts.ToList());
        }

        public List<NotificationViewModel> GetAllMessageNotifications(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var messagesNotifications = user.Notifications.Where(x => x.NotificationType == NotificationType.Message);

            throw new NotImplementedException();
        }

        public List<NotificationViewModel> GetAllUnseenMessageNotifications(Guid userId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Buddy

        public List<BuddyRequestViewModel> GetAllBuddies(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            return Mapper.Map<List<BuddyRequest>, List<BuddyRequestViewModel>>(user.Buddies);
        }

        public List<BuddyRequestViewModel> GetAllSentPendingBuddyRequests(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var buddyRequests = user.SentBuddyRequests
                .Where(x => x.Status == RequestStatus.Pending).ToList();
            return Mapper.Map<IList<BuddyRequest>, List<BuddyRequestViewModel>>(buddyRequests);
        }

        public List<BuddyRequestViewModel> GetAllReceivedPendingBuddyRequests(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var buddyRequests = user.ReceivedBuddyRequests
                .Where(x => x.Status == RequestStatus.Pending).ToList();
            return Mapper.Map<IList<BuddyRequest>, List<BuddyRequestViewModel>>(buddyRequests);
        }

        public void SendBuddyRequest(BuddyRequestViewModel model)
        {
            var userFrom = _userRepository.GetById(model.UserFrom.Id);
            var userTo = _userRepository.GetById(model.UserTo.Id);

            if (userFrom == null || userTo == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            if (_buddyRequestRepository.GetBuddyRequest(model.UserFrom.Id, model.UserTo.Id) != null)
                throw new BusinessLayerException(UserExceptionMessage.BUDDY_REQUEST_INITIATED);

            BuddyRequest buddyRequest = new BuddyRequest(userFrom, userTo);
            userFrom.SaveBuddyRequest(buddyRequest);
        }

        public void UpdateBuddyRequest(BuddyRequestViewModel model)
        {
            if (model.Status.Id == (int) RequestStatus.Pending)
                throw new BusinessLayerException(AppExceptionMessage.INVALID_INTERNAL_STATE);

            var buddyRequest = _buddyRequestRepository.GetBuddyRequest(model.UserFrom.Id, model.UserTo.Id);
            if (buddyRequest == null)
                throw new NotFoundException(UserExceptionMessage.BUDDY_REQUEST_NOT_FOUND);

            buddyRequest.Status = (RequestStatus) model.Status.Id;
            buddyRequest.UserTo.UpdateBuddyRequest(buddyRequest);
        }

        public List<NotificationViewModel> GetAllBuddyNotifications(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<NotificationViewModel> GetAllUnseenBuddyNotifications(Guid userId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Subject

        public List<EnrolledSubjectViewModel> GetEnrolledSubjects(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var subjects = user.EnrolledSubjects;
            return Mapper.Map<IList<EnrolledSubject>, List<EnrolledSubjectViewModel>>(subjects);
        }

        public List<SubjectViewModel> GetPassedSubjects(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var subjects = user.EnrolledSubjects
                .Where(x => x.Status == SubjectStatus.Passed)
                .Select(x => x.Subject).ToList();
            return Mapper.Map<List<Subject>, List<SubjectViewModel>>(subjects);
        }

        public List<SubjectViewModel> GetCurrentSubjects(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var subjects = user.EnrolledSubjects
                .Where(x => x.Status == SubjectStatus.Passed)
                .Select(x => x.Subject).ToList();
            return Mapper.Map<List<Subject>, List<SubjectViewModel>>(subjects);
        }

        #endregion

        #region Group

        public List<GroupViewModel> GetAllGroups(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var groups = user.CreatedGroups.Concat(user.MemberInGroups
                .Where(x => x.Status == RequestStatus.Accepted)
                .Select(x => x.Group)
                .ToList())
                .ToList();
            return Mapper.Map<List<Group>, List<GroupViewModel>>(groups);
        }

        public List<GroupViewModel> GetAllGroupsWhereNoRequestIsSent(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var allGroups = _groupRepository.GetMany(x => x.Status == GroupStatus.Assembly && x.Admin.Id != userId);
            var groups = (from x in allGroups
                          let groupRequests = _groupRequestRepository.GetMany(y => y.User.Id == userId).ToList()
                          where !x.Members.Intersect(groupRequests).Any()
                          select x)
                .ToList();
            return Mapper.Map<List<Group>, List<GroupViewModel>>(groups);
        }

        public List<GroupViewModel> GetAllManagedGroups(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var groups = user.CreatedGroups;
            return Mapper.Map<IList<Group>, List<GroupViewModel>>(groups);
        }

        public List<GroupViewModel> GetAllMemberingGroups(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var groups = user.MemberInGroups
                .Where(x => x.Status == RequestStatus.Accepted)
                .Select(x => x.Group)
                .Union(user.CreatedGroups)
                .ToList();
            return Mapper.Map<IList<Group>, List<GroupViewModel>>(groups);
        }

        public List<NotificationViewModel> GetAllGroupNotifications(Guid userid)
        {
            throw new NotImplementedException();
        }

        public List<NotificationViewModel> GetAllUnseenGroupNotifications(Guid userid)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Post

        public List<PostViewModel> GetLatestGroupsPosts(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var posts = _postRepository.GetLatestPosts(GetAllGroups(userId).Select(x => x.Id));
            return Mapper.Map<IList<Post>, List<PostViewModel>>(posts);
        }

        #endregion

        public void EnrollInstitution(Guid userId, Guid institutionId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new BusinessLayerException(UserExceptionMessage.USER_NOT_FOUND);

            var institution = _institutionRepository.GetById(institutionId);
            if (institution == null)
                throw new BusinessLayerException(InstitutionExceptionMessage.INSTITUTION_NOT_FOUND);

            var institutionEnrollment = new EnrolledInstitution(user, institution);
            user.EnrollInstitution(institutionEnrollment);
            _userRepository.Update(user);
        }
    }
}
