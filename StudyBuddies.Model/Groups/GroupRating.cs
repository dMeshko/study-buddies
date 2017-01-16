using System;
using System.IO;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Domain.Groups
{
    public class GroupRating : BaseEntity
    {
        private User _userFrom;
        private User _userTo;
        private Group _group;
        private DateTime _date;
        private int _grade;

        protected GroupRating() { }

        public GroupRating(User userFrom, User userTo, Group group, int grade)
        {
            if (userFrom == null)
                throw new InvalidDataException(nameof(userFrom));

            if (userTo == null)
                throw new InvalidDataException(nameof(userTo));

            if (group == null)
                throw new InvalidDataException(nameof(group));

            if (grade < 1 || grade > 5)
                throw new InvalidDataException(nameof(grade));

            _userFrom = userFrom;
            _userTo = userTo;
            _group = group;
            _date = DateTime.UtcNow;
            _grade = grade;
        }

        #region Properties

        public virtual User UserFrom => _userFrom;
        public virtual User UserTo => _userTo;
        public virtual Group Group => _group;
        public virtual DateTime Date => _date;
        public virtual int Grade => _grade;

        #endregion

        #region Public Methods

        public virtual void SetGrade(int grade)
        {
            if (grade < 1 || grade > 5)
                throw new InvalidDataException(nameof(grade));

            _grade = grade;
        }

        #endregion
    }
}
