using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudyBuddies.Data.Repository;
using StudyBuddies.Data.Repository.Groups;
using StudyBuddies.Data.Repository.Subjects;
using StudyBuddies.Data.Repository.Users;
using StudyBuddies.Domain.Groups;
using StudyBuddies.Service.Infrastructure.Exceptions;
using StudyBuddies.Service.ViewModels.Groups;

namespace StudyBuddies.Service.Services.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISubjectRepository _subjectRepository;

        public GroupService(IGroupRepository groupRepository, IUserRepository userRepository, ISubjectRepository subjectRepository)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
            _subjectRepository = subjectRepository;
        }

        public GroupViewModel GetGroupById(Guid id)
        {
            var group = _groupRepository.GetById(id);
            if (group == null)
                throw new BusinessLayerException(GroupException.GROUP_NOT_FOUND);

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
                throw new BusinessLayerException(UserException.USER_NOT_FOUND);

            var subject = _subjectRepository.GetById(group.Subject.Id);
            if (subject == null)
                throw new BusinessLayerException(SubjectException.SUBJECT_NOT_FOUND);

            var dboGroup = new Group(group.Name, group.Description, group.GroupCapacity, user, subject);
            _groupRepository.Add(dboGroup);
        }
    }
}
