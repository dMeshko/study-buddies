using System;
using System.IO;

namespace StudyBuddies.Domain.Users
{
    public class Message : BaseEntity
    {
        private User _userFrom;
        private User _userTo;
        private string _content;
        private DateTime _date;

        protected Message() { }

        public Message(User userFrom, User userTo, string content)
        {
            if (userFrom == null)
                throw new InvalidDataException(nameof(userFrom));

            if (userTo == null)
                throw new InvalidDataException(nameof(userTo));

            if (content == null || content.Trim().Length == 0)
                throw new InvalidDataException(nameof(content));

            _userFrom = userFrom;
            _userTo = userTo;
            _content = content;
            _date = DateTime.UtcNow;
        }

        #region Properties

        public virtual User UserFrom => _userFrom;
        public virtual User UserTo => _userTo;
        public virtual string Content => _content;
        public virtual DateTime Date => _date;

        #endregion
    }
}
