using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using StudyBuddies.Business.Infrastructure.Exceptions;
using StudyBuddies.Business.Infrastructure.Exceptions.Messages;
using StudyBuddies.Business.ViewModels.Groups;
using StudyBuddies.Business.ViewModels.Users;
using StudyBuddies.Data.Repository.Groups;
using StudyBuddies.Data.Repository.Subjects;
using StudyBuddies.Data.Repository.Users;
using StudyBuddies.Domain;
using StudyBuddies.Domain.Groups;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Business.Services.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IGroupRequestRepository _groupRequestRepository;

        public GroupService(IGroupRepository groupRepository, IUserRepository userRepository, ISubjectRepository subjectRepository, IGroupRequestRepository groupRequestRepository)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
            _subjectRepository = subjectRepository;
            _groupRequestRepository = groupRequestRepository;
        }

        #region Group

        public GroupViewModel GetGroupById(Guid groupId)
        {
            var group = _groupRepository.GetById(groupId);
            if (group == null)
                throw new NotFoundException(GroupExceptionMessage.GROUP_NOT_FOUND);

            return Mapper.Map<Group, GroupViewModel>(group);
        }

        public IEnumerable<GroupViewModel> GetAllGroups()
        {
            var groups = _groupRepository.GetAll();
            return Mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(groups);
        }

        public void CreateGroup(CreateGroupViewModel group)
        {
            var user = _userRepository.GetById(group.Admin.Id);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var subject = _subjectRepository.GetById(group.Subject.Id);
            if (subject == null)
                throw new NotFoundException(SubjectExceptionMessage.SUBJECT_NOT_FOUND);

            var dboGroup = new Group(group.Name, group.Description, group.GroupCapacity, user, subject);
            _groupRepository.Add(dboGroup);
        }

        public void UpdateGroup(UpdateGroupViewModel group)
        {
            throw new NotImplementedException();
        }

        public void DeleteGroup(Guid groupId)
        {
            var group = _groupRepository.GetById(groupId);
            if (group == null)
                throw new NotFoundException(GroupExceptionMessage.GROUP_NOT_FOUND);

            _groupRepository.Delete(group);
        }

        #endregion

        #region Post

        public IList<PostViewModel> GetGroupPosts(Guid groupId)
        {
            var group = _groupRepository.GetById(groupId);
            if (group == null)
                throw new NotFoundException(GroupExceptionMessage.GROUP_NOT_FOUND);

            var posts = group.Posts;
            return Mapper.Map<IList<Post>, List<PostViewModel>>(posts);
        }

        #endregion

        #region Member

        public IList<GroupRequestViewModel> GetGroupMembers(Guid groupId)
        {
            var group = _groupRepository.GetById(groupId);
            if (group == null)
                throw new NotFoundException(GroupExceptionMessage.GROUP_NOT_FOUND);

            var members = group.Members;
            return Mapper.Map<IList<GroupRequest>, List<GroupRequestViewModel>>(members);
        }

        public IList<UserViewModel> GetPendingGroupMembers(Guid groupId)
        {
            var group = _groupRepository.GetById(groupId);
            if (group == null)
                throw new NotFoundException(GroupExceptionMessage.GROUP_NOT_FOUND);

            var members = group.PendingMembers.Select(x => x.User).ToList();
            return Mapper.Map<IList<User>, List<UserViewModel>>(members);
        }

        public IList<UserViewModel> GetAcceptedGroupMembers(Guid groupId)
        {
            var group = _groupRepository.GetById(groupId);
            if (group == null)
                throw new NotFoundException(GroupExceptionMessage.GROUP_NOT_FOUND);

            var members = group.AcceptedMembers.Select(x => x.User).ToList();
            return Mapper.Map<IList<User>, List<UserViewModel>>(members);
        }

        public void UpdateGroupMember(GroupRequestViewModel groupRequest)
        {
            var group = _groupRepository.GetById(groupRequest.Group.Id);
            if (group == null)
                throw new NotFoundException(GroupExceptionMessage.GROUP_NOT_FOUND);

            var user = _userRepository.GetById(groupRequest.User.Id);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var groupRequestDto = group.Members.FirstOrDefault(x => x.User.Id == user.Id);
            if (groupRequestDto == null)
                throw new BusinessLayerException(GroupExceptionMessage.GROUP_REQUEST_NOT_FOUND);

            groupRequestDto.Status = (RequestStatus) groupRequest.Status.Id;
            _groupRequestRepository.Update(groupRequestDto);
        }

        #endregion
    }
}
