using System.Collections.Generic;
using System.IO;
using System.Linq;
using StudyBuddies.Domain.Subjects;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Domain.Groups
{
    public class Group : BaseEntity
    {
        private string _name;
        private string _description;
        private int _groupCapacity;
        private User _admin;
        private Subject _subject;
        private IList<GroupRequest> _members;
        private IList<GroupRating> _ratings;
        private GroupStatus _status;
        private IList<Post> _posts;

        protected Group() { }

        public Group(string name, string description, int groupCapacity, User admin, Subject subject, GroupStatus status = GroupStatus.Assembly)
        {
            if (name == null || name.Trim().Length == 0)
                throw new InvalidDataException(nameof(name));

            if (description == null || description.Trim().Length == 0)
                throw new InvalidDataException(nameof(description));

            if (groupCapacity < 1)
                throw new InvalidDataException(nameof(groupCapacity));

            if (admin == null)
                throw new InvalidDataException(nameof(admin));

            if (subject == null)
                throw new InvalidDataException(nameof(subject));

            _name = name;
            _description = description;
            _groupCapacity = groupCapacity;
            _admin = admin;
            _subject = subject;
            _members = new List<GroupRequest>();
            _ratings = new List<GroupRating>();
            _status = status;
            _posts = new List<Post>();
        }

        #region Properties

        public virtual string Name => _name;
        public virtual string Description => _description;
        public virtual int GroupCapacity => _groupCapacity;
        public virtual User Admin => _admin;
        public virtual Subject Subject => _subject;
        public virtual IList<GroupRequest> PendingMembers => _members.Where(x => x.Status == RequestStatus.Pending).ToList();
        public virtual IList<GroupRequest> RejectedMembers => _members.Where(x => x.Status == RequestStatus.Rejected).ToList();
        public virtual IList<GroupRequest> AcceptedMembers => _members.Where(x => x.Status == RequestStatus.Accepted).ToList();
        public virtual IList<GroupRequest> Members => _members;
        public virtual IList<GroupRating> Ratings => _ratings;
        public virtual GroupStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public virtual IList<Post> Posts => _posts;

        #endregion

        #region Public Methods

        public virtual void SetName(string name)
        {
            if (name == null || name.Trim().Length == 0)
                throw new InvalidDataException(nameof(name));

            _name = name;
        }

        public virtual void SetDescription(string description)
        {
            if (description == null || description.Trim().Length == 0)
                throw new InvalidDataException(nameof(description));

            _description = description;
        }

        public virtual void SetGroupCapacity(int groupCapacity)
        {
            if (groupCapacity < 1)
                throw new InvalidDataException(nameof(groupCapacity));

            _groupCapacity = groupCapacity;
        }

        public virtual void SetSubject(Subject subject)
        {
            if (subject == null)
                throw new InvalidDataException(nameof(subject));

            _subject = subject;
        }

        public virtual void AddRating(GroupRating groupRating)
        {
            if (groupRating == null)
                throw new InvalidDataException(nameof(groupRating));

            _ratings.Add(groupRating);
        }

        public virtual void RemoveRating(GroupRating groupRating)
        {
            if (groupRating == null)
                throw new InvalidDataException(nameof(groupRating));

            _ratings.Remove(groupRating);
        }

        public virtual void AddPost(Post post)
        {
            if (post == null)
                throw new InvalidDataException(nameof(post));

            foreach (var groupAcceptedMember in AcceptedMembers)
            {
                groupAcceptedMember.User.AddNotification(post.User, post, NotificationType.Post);
            }

            _posts.Add(post);
        }

        public virtual void RemovePost(Post post)
        {
            if (post == null)
                throw new InvalidDataException(nameof(post));

            _posts.Remove(post);
        }

        public virtual void AddPendingMember(GroupRequest groupRequest)
        {
            if (groupRequest == null)
                throw new InvalidDataException(nameof(groupRequest));

            Admin.AddNotification(groupRequest.User, groupRequest, NotificationType.GroupRequest);
            _members.Add(groupRequest);
        }

        #endregion
    }
}
