﻿using System;
using StudyBuddies.Domain.Groups;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StudyBuddies.Domain.Institutions;
using StudyBuddies.Domain.Subjects;

namespace StudyBuddies.Domain.Users
{
    public class User : BaseEntity // IdentityUser
    {
        private string _name;
        private string _surname;
        private string _email;
        // this needs to be encrypted with algorithm that can't be decrypted
        private string _password;
        private string _username;
        private byte[] _coverImage;
        private byte[] _image;
        private bool _isActive;
        private IList<Group> _createdGroups;
        private IList<GroupRequest> _memberInGroups;
        private IList<BuddyRequest> _sentBuddyRequests;
        private IList<BuddyRequest> _receivedBuddyRequests;
        private IList<Message> _sentMessages { get; }
        private IList<Message> _receivedMessages { get; }
        private IList<EnrolledSubject> _enrolledSubjects;
        private IList<EnrolledInstitution> _enrolledInstitutions;
        private IList<Notification> _notifications;
        private IList<UserClaim> _claims;

        protected User() { }

        public User(string name, string surname, string email, string password)
        {
            if (name == null || name.Trim().Length == 0)
                throw new InvalidDataException(nameof(name));

            if (surname == null || surname.Trim().Length == 0)
                throw new InvalidDataException(nameof(surname));

            if (email == null || email.Trim().Length < 5)
                throw new InvalidDataException(nameof(email));

            if (password == null || password.Trim().Length < 6)
                throw new InvalidDataException(nameof(password));

            _name = name;
            _surname = surname;
            _email = email;
            _password = password;

            _username = null;
            _coverImage = new byte[0];
            _image = new byte[0];
            _isActive = true;
            _createdGroups = new List<Group>();
            _memberInGroups = new List<GroupRequest>();
            _sentBuddyRequests = new List<BuddyRequest>();
            _receivedBuddyRequests = new List<BuddyRequest>();
            _sentMessages = new List<Message>();
            _receivedMessages = new List<Message>();
            _enrolledSubjects = new List<EnrolledSubject>();
            _enrolledInstitutions = new List<EnrolledInstitution>();
            _notifications = new List<Notification>();
            _claims = new List<UserClaim>();
        }

        #region Properties

        public virtual string Name => _name;
        public virtual string Surname => _surname;
        public virtual string Email => _email;
        public virtual string Password => _password;
        public virtual string Username => _username;
        public virtual byte[] CoverImage
        {
            get { return _coverImage; }
            set { _coverImage = value; }
        }
        public virtual byte[] Image
        {
            get { return _image; }
            set { _image = value; }
        }
        public virtual bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public virtual IList<Group> CreatedGroups => _createdGroups;
        public virtual IList<GroupRequest> MemberInGroups => _memberInGroups;
        public virtual IList<BuddyRequest> SentBuddyRequests => _sentBuddyRequests;
        public virtual IList<BuddyRequest> ReceivedBuddyRequests => _receivedBuddyRequests;
        public virtual List<BuddyRequest> Buddies => _sentBuddyRequests.Union(_receivedBuddyRequests).Where(x => x.Status == RequestStatus.Accepted).ToList();
        public virtual IDictionary<Guid, List<Message>> Messages
        {
            get
            {
                var res = new SortedDictionary<Guid, List<Message>>();

                foreach (var msg in _sentMessages)
                {
                    var key = msg.UserTo.Id;
                    if (!res.ContainsKey(key))
                        res.Add(key, new List<Message>());

                    res[key].Add(msg);   
                }

                foreach (var msg in _receivedMessages)
                {
                    var key = msg.UserFrom.Id;
                    if (!res.ContainsKey(key))
                        res.Add(key, new List<Message>());

                    res[key].Add(msg);
                }

                return res;
            }
        }

        public virtual IList<Message> SentMessages => _sentMessages;
        public virtual IList<Message> ReceivedMessages => _receivedMessages;
        public virtual IList<EnrolledSubject> EnrolledSubjects => _enrolledSubjects;
        public virtual IList<EnrolledInstitution> EnrolledInstitutions => _enrolledInstitutions;
        public virtual IList<Notification> Notifications => _notifications;
        public virtual IList<UserClaim> Claims => _claims;

        #endregion

        #region Public Methods

        public virtual void SetName(string name)
        {
            if (name == null || name.Trim().Length == 0)
                throw new InvalidDataException(nameof(name));

            _name = name;
        }

        public virtual void SetSurname(string surname)
        {
            if (surname == null || surname.Trim().Length == 0)
                throw new InvalidDataException(nameof(surname));

            _surname = surname;
        }

        public virtual void SetEmail(string email)
        {
            if (email == null || email.Trim().Length < 5)
                throw new InvalidDataException(nameof(email));

            _email = email;
        }

        public virtual void SetPassword(string password)
        {
            if (password == null || password.Trim().Length < 6)
                throw new InvalidDataException(nameof(password));

            _password = password;
        }

        public virtual void SetUsername(string username)
        {
            if (username == null || username.Trim().Length == 0)
                throw new InvalidDataException(nameof(username));

            _username = username;
        }

        public virtual void CreateGroup(Group group)
        {
            if (group == null)
                throw new InvalidDataException(nameof(group));

            _createdGroups.Add(group);
        }

        public virtual void RemoveGroup(Group group)
        {
            if (group == null)
                throw new InvalidDataException(nameof(group));

            _createdGroups.Remove(group);
        }

        public virtual void SendGroupRequest(GroupRequest groupRequest)
        {
            if (groupRequest == null)
                throw new InvalidDataException(nameof(groupRequest));

            _memberInGroups.Add(groupRequest);
        }

        public virtual void RemoveGroupRequest(GroupRequest groupRequest)
        {
            if (groupRequest == null)
                throw new InvalidDataException(nameof(groupRequest));

            _memberInGroups.Remove(groupRequest);
        }

        public virtual void SaveBuddyRequest(BuddyRequest buddyRequest)
        {
            if (buddyRequest == null)
                throw new InvalidDataException(nameof(buddyRequest));

            buddyRequest.UserTo.AddNotification(this, buddyRequest, NotificationType.BuddyRequest);
            _sentBuddyRequests.Add(buddyRequest);
        }

        public virtual void RemoveBuddyRequest(BuddyRequest buddyRequest)
        {
            if (buddyRequest == null)
                throw new InvalidDataException(nameof(buddyRequest));

            _sentBuddyRequests.Union(_receivedBuddyRequests).ToList().Remove(buddyRequest);
        }

        public virtual void UpdateBuddyRequest(BuddyRequest buddyRequest)
        {
            if (buddyRequest == null)
                throw new InvalidDataException(nameof(buddyRequest));

            buddyRequest.UserFrom.AddNotification(this, buddyRequest, NotificationType.BuddyAcceptance);
        }

        public virtual void SendMessage(Message message)
        {
            if (message == null)
                throw new InvalidDataException(nameof(message));

            message.UserTo.AddNotification(this, message, NotificationType.Message);
            _sentMessages.Add(message);
        }

        public virtual void EnrollSubject(EnrolledSubject enrolledSubject)
        {
            if (enrolledSubject == null)
                throw new InvalidDataException(nameof(enrolledSubject));

            _enrolledSubjects.Add(enrolledSubject);
        }

        public virtual void UnrollSubject(EnrolledSubject enrolledSubject)
        {
            if (enrolledSubject == null)
                throw new InvalidDataException(nameof(enrolledSubject));

            _enrolledSubjects.Remove(enrolledSubject);
        }

        public virtual void EnrollInstitution(EnrolledInstitution enrolledInstitution)
        {
            if (enrolledInstitution == null)
                throw new InvalidDataException(nameof(enrolledInstitution));

            _enrolledInstitutions.Add(enrolledInstitution);
        }

        public virtual void AddNotification(User userFrom, BaseEntity baseEntity, NotificationType notificationType)
        {
            if (userFrom == null)
                throw new InvalidDataException(nameof(userFrom));

            if (baseEntity == null)
                throw new InvalidDataException(nameof(baseEntity));

           var notification = new Notification(userFrom, this, baseEntity, notificationType);
            
            _notifications.Add(notification);
        }

        public virtual void AddClaim(UserClaim claim)
        {
            if (claim == null)
                throw new InvalidDataException(nameof(claim));

            if (!_claims.Contains(claim))
                _claims.Add(claim);
        }

        public virtual void RemoveRole(UserClaim claim)
        {
            if (claim == null)
                throw new InvalidDataException(nameof(claim));

            if (!_claims.Contains(claim))
                _claims.Remove(claim);
        }

        #endregion
    }
}
