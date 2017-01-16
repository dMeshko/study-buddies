using System;
using System.Collections.Generic;
using AutoMapper;
using StudyBuddies.Data.Repository;
using StudyBuddies.Data.Repository.Institutions;
using StudyBuddies.Data.Repository.Users;
using StudyBuddies.Domain.Institutions;
using StudyBuddies.Domain.Users;
using StudyBuddies.Service.Infrastructure.Exceptions;
using StudyBuddies.Service.ViewModels.Users;

namespace StudyBuddies.Service.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBuddyRequestRepository _buddyRequestRepository;
        private readonly IInstitutionRepository _institutionRepository;

        public UserService(IUserRepository userRepository, IBuddyRequestRepository buddyRequestRepository, IInstitutionRepository institutionRepository)
        {
            _userRepository = userRepository;
            _buddyRequestRepository = buddyRequestRepository;
            _institutionRepository = institutionRepository;
        }

        public UserViewModel GetUserById(Guid id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
                throw new BusinessLayerException(UserException.USER_NOT_FOUND);

            return Mapper.Map<User, UserViewModel>(user);
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
        }

        public void RegisterUser(RegisterUserViewModel user)
        {
            var dboUser = Mapper.Map<RegisterUserViewModel, User>(user);
            _userRepository.Add(dboUser);
        }

        public void AddFriend(Guid currentUserId, Guid buddyId)
        {
            var currentUser = _userRepository.GetById(currentUserId);
            var otherUser = _userRepository.GetById(buddyId);

            if (currentUser == null || otherUser == null)
                throw new BusinessLayerException(UserException.USER_NOT_FOUND);

            if (_buddyRequestRepository.GetBuddyRequest(currentUserId, buddyId) != null)
                throw new BusinessLayerException(UserException.BUDDY_REQUEST_INITIATED);

            BuddyRequest buddyRequest = new BuddyRequest(currentUser, otherUser);
            currentUser.SaveBuddyRequest(buddyRequest);
        }

        public void SendMessage(MessageViewModel messageViewModel)
        {
            var currentUser = _userRepository.GetById(messageViewModel.UserFromId);
            var otherUser = _userRepository.GetById(messageViewModel.UserToId);

            if (currentUser == null || otherUser == null)
                throw new BusinessLayerException(UserException.USER_NOT_FOUND);

            var message = new Message(currentUser, otherUser, messageViewModel.Content);
            currentUser.SendMessage(message);
            _userRepository.Update(currentUser);
        }

        public IDictionary<Guid, List<MessageViewModel>> GetAllConversations(Guid userId)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
                throw new BusinessLayerException(UserException.USER_NOT_FOUND);

            return Mapper.Map<IDictionary<Guid, List<Message>>, IDictionary<Guid, List<MessageViewModel>>>(user.Messages);
        }

        public void GetConversation(MessageViewModel messageViewModel)
        {
            throw new NotImplementedException();
        }

        public void EnrollInstitution(Guid userId, Guid institutionId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new BusinessLayerException(UserException.USER_NOT_FOUND);

            var institution = _institutionRepository.GetById(institutionId);
            if (institution == null)
                throw new BusinessLayerException(InstitutionException.INSTITUTION_NOT_FOUND);

            var institutionEnrollment = new EnrolledInstitution(user, institution);
            user.EnrollInstitution(institutionEnrollment);
            _userRepository.Update(user);
        }

        public void Delete(Guid id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
                throw new BusinessLayerException(UserException.USER_NOT_FOUND);

            _userRepository.Delete(user);
        }
    }
}
