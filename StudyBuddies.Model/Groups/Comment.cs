using System;
using System.IO;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Domain.Groups
{
    public class Comment : NotificationEntity
    {
        private User _user;
        private Post _post;
        private DateTime _date;
        private string _content;

        protected Comment() { }

        public Comment(User user, Post post, string content)
        {
            if (user == null)
                throw new InvalidDataException(nameof(user));

            if (post == null)
                throw new InvalidDataException(nameof(post));

            if (content == null || content.Trim().Length == 0)
                throw new InvalidDataException(nameof(content));

            _user = user;
            _post = post;
            _date = DateTime.UtcNow;
            _content = content;
        }

        #region Properties

        public virtual User User => _user;
        public virtual Post Post => _post;
        public virtual DateTime Date => _date;
        public virtual string Content => _content;

        #endregion
    }
}
