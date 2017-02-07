using System;
using System.Collections.Generic;
using System.IO;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Domain.Groups
{
    public class Post : BaseEntity
    {
        private User _user;
        private Group _group;
        private DateTime _date;
        private string _content;
        private IList<Attachment> _attachments;
        private IList<Comment> _comments;

        protected Post() { }

        public Post(User user, Group group, string content)
        {
            if (user == null)
                throw new InvalidDataException(nameof(user));

            if (group == null)
                throw new InvalidDataException(nameof(group));

            if (content == null || content.Trim().Length == 0)
                throw new InvalidDataException(nameof(content));

            _user = user;
            _group = group;
            _date = DateTime.UtcNow;
            _content = content;
            _attachments = new List<Attachment>();
            _comments = new List<Comment>();
        }

        #region Properties

        public virtual User User => _user;
        public virtual Group Group => _group;
        public virtual DateTime Date => _date;
        public virtual string Content => _content;
        public virtual IList<Attachment> Attachments => _attachments;
        public virtual IList<Comment> Comments => _comments;

        #endregion

        #region Public Methods

        public virtual void AddAttachment(Attachment attachment)
        {
            if (attachment == null)
                throw new InvalidDataException(nameof(attachment));

            _attachments.Add(attachment);
        }

        public virtual void RemoveAttachment(Attachment attachment)
        {
            if (attachment == null)
                throw new InvalidDataException(nameof(attachment));

            _attachments.Remove(attachment);
        }

        public virtual void AddComment(Comment comment)
        {
            if (comment == null)
                throw new InvalidDataException(nameof(comment));

            _comments.Add(comment);
        }

        public virtual void RemoveComment(Comment comment)
        {
            if (comment == null)
                throw new InvalidDataException(nameof(comment));

            _comments.Remove(comment);
        }

        #endregion
    }
}
